using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SayaGym.Data;
using SayaGym.Models;

namespace SayaGym.Controllers
{
    [Authorize]
    public class SaludController : Controller
    {
        private readonly Contexto _context;
        private Usuario _usuario;
        private IHttpContextAccessor _contextAccessor;

        //metodo para obtener la informacion del usuario logueado
        private Usuario GetInfoUsuario(int id)
        {
            Usuario Usuario = _context.Usuario.Find(id);
            Usuario.EnfermedadesUsuario = _context.EnfermedadesUsuario.Where(e => e.IdUsuario == Usuario.IdUsuario).ToList();
            Usuario.AreasATrabajar = _context.AreasATrabajarUsuario.Where(e => e.IdUsuario == Usuario.IdUsuario).ToList();

            foreach (var enfermedadUsuario in Usuario.EnfermedadesUsuario)
            {
                enfermedadUsuario.Enfermedad = _context.Enfermedad.Find(enfermedadUsuario.IdEnfermedad);
            }

            var Rutina = _context.Rutina.Where(r => r.IdUsuario == Usuario.IdUsuario).FirstOrDefault();
            if (Rutina != null)
            {
                //si tiene rutina, cargar los ejercicios
                Rutina.EjerciciosRutina = _context.EjercicioRutina.Where(e => e.IdRutina == Rutina.IdRutina).ToList();
                foreach (EjercicioRutina ejercicio in Rutina.EjerciciosRutina)
                {
                    ejercicio.Ejercicio = _context.Ejercicio.Find(ejercicio.IdEjercicio);
                }

                Usuario.Rutina = Rutina;
            }

            return Usuario;
        }

        public SaludController(Contexto context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
            int UserId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            if (UserId > 0) {
                //guardar la info del usuario que esta logueado
                _usuario = GetInfoUsuario(UserId);
            }
        }

        

        public async Task<IActionResult> Index()
        {
            return View(_usuario);
        }

        private List<Enfermedad> GetEnfermedades()
        {
            _context.Enfermedad.ToList();

            return _context.Enfermedad.ToList();
        }

        [HttpGet]
        public IActionResult Edit()
        {

            ViewBag.Enfermedades = GetEnfermedades();
            return View(_usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuarioEditado)
        {
            Usuario Usuario = GetInfoUsuario(usuarioEditado.IdUsuario);//obtener el usuario actual de la base de datos

            bool GenerarNuevaRutina = false;

            //solo tomar en cuenta campos que se pueden editar
            Usuario.Nombre = usuarioEditado.Nombre;
            Usuario.Teléfono = usuarioEditado.Teléfono;
            Usuario.Dirección = usuarioEditado.Dirección;
            Usuario.Peso = usuarioEditado.Peso;
            Usuario.Estatura = usuarioEditado.Estatura;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //estos datos los tomo del formulario ya que estos campos no vienen como tal en el modelo de Usuario
                    var FormCollection = Request.Form;
                    var AreasForm = FormCollection["AreasATrabajar[]"];
                    var EnfermedadesForm = FormCollection["Enfermedades[]"];

                    if (AreasForm.Count() < 2)
                    {
                        throw new Exception("Eliga almenos 2 areas a trabajar");
                    }

                    //en caso de que el length del array de enfermedades o areas es distinto significa que cambiaron
                    GenerarNuevaRutina |= Usuario.EnfermedadesUsuario.Count() != EnfermedadesForm.Count() || Usuario.AreasATrabajar.Count() != AreasForm.Count();


                    //verificamos que no exista usuario con la misma cedula
                    bool findedUser = _context.Usuario.Any(u => u.Cedula == Usuario.Cedula && Usuario.IdUsuario != u.IdUsuario);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con esa cédula");
                    }

                    //verificamos que no exista usuario con el mismo correo
                    findedUser = _context.Usuario.Any(u => u.Correo == Usuario.Correo && Usuario.IdUsuario != u.IdUsuario);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con ese correo");
                    }

                    List<EnfermedadUsuario> EnfermedadesUsuario = new List<EnfermedadUsuario>();

                    foreach (var EnfermedadForm in EnfermedadesForm)
                    {
                        int IdEnfermedad = int.Parse(EnfermedadForm);
                        var EnfermedadActualUsuario =
                            (from enfermedad in Usuario.EnfermedadesUsuario.ToList()
                             where enfermedad.IdEnfermedad == IdEnfermedad
                             select enfermedad).FirstOrDefault();

                        if (EnfermedadActualUsuario != null)
                        {
                            EnfermedadesUsuario.Add((EnfermedadUsuario)EnfermedadActualUsuario);
                        }
                        else
                        {
                            GenerarNuevaRutina = true;//si hay nueva enfermedad directamente generar nueva rutina
                            Enfermedad Enfermedad = _context.Enfermedad.Find(IdEnfermedad);
                            EnfermedadUsuario NuevaEnfermedad = new EnfermedadUsuario
                            {
                                IdUsuario = Usuario.IdUsuario,
                                IdEnfermedad = IdEnfermedad,
                                Usuario = Usuario,
                                Enfermedad = Enfermedad
                            };
                            EnfermedadesUsuario.Add(NuevaEnfermedad);
                        }
                    }

                    Usuario.EnfermedadesUsuario = EnfermedadesUsuario;

                    List<AreasATrabajarUsuario> AreasUsuario = new();
                    foreach (var AreaForm in AreasForm)
                    {
                        var AreaActualUsuario =
                            (from area in Usuario.AreasATrabajar.ToList()
                             where area.AreaATrabajar == AreaForm
                             select area).FirstOrDefault();

                        if (AreaActualUsuario != null)
                        {
                            AreasUsuario.Add(AreaActualUsuario);
                        }
                        else
                        {
                            GenerarNuevaRutina = true;//si hay nueva area directamente generar nueva rutina
                            AreasATrabajarUsuario Area = new AreasATrabajarUsuario
                            {
                                IdUsuario = Usuario.IdUsuario,
                                AreaATrabajar = AreaForm,
                                Usuario = Usuario
                            };

                            AreasUsuario.Add(Area);
                        }
                    }

                    Usuario.AreasATrabajar = AreasUsuario;

                    if (GenerarNuevaRutina && Usuario.Rol == 2)
                    {
                        Usuario.Rutina = GenerarRutina(Usuario);
                    }

                    //guardamos el usuario en la base de datos
                    _context.Usuario.Update(Usuario);
                    _context.SaveChanges();

                    transaction.Commit(); // Confirmar la transacción
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    transaction.Rollback(); // Revertir la transacción
                }
            }
            ViewBag.Enfermedades = GetEnfermedades();
            return View(Usuario);
        }



        //metodo para generar la rutina del usuario dependiendo de las enfermedades y objetivos y areas a trabajar que tenga
        private Rutina GenerarRutina(Usuario usuario)
        {
            Rutina Rutina = new Rutina
            {
                IdUsuario = usuario.IdUsuario,
                Usuario = usuario,
                FechaRutina = DateTime.Now,
            };

            //guardar en la db para generar un id
            _context.Rutina.Add(Rutina);
            _context.SaveChanges();

            //meter los idsEnfermedades del usuario en una lista
            List<int> IdsEnfermedadesUsuario = new List<int>();
            foreach (EnfermedadUsuario enfermedad in _context.EnfermedadesUsuario.Where(u => u.IdUsuario == usuario.IdUsuario).ToList())
            {
                IdsEnfermedadesUsuario.Add(enfermedad.IdEnfermedad);
            }

            //meter las Areas a trabajar del usuario en una lista
            List<string> AreasATrabajarUsuario = new List<string>();
            foreach (AreasATrabajarUsuario area in _context.AreasATrabajarUsuario.Where(u => u.IdUsuario == usuario.IdUsuario).ToList())
            {
                AreasATrabajarUsuario.Add(area.AreaATrabajar);
            }


            List<Ejercicio> ListaEjercicios = _context.Ejercicio.Where(e => !IdsEnfermedadesUsuario.Contains(e.IdEjercicio)).ToList();//obtener ejercicios que no tengan las enfermedades del usuario
            int CantidadCardioInicio;
            int CantidadTonificacion;
            int CantidadCardioFinal;
            switch (usuario.Objetivo)
            {
                case 1://bajar de peso
                    //metemos mas ejercicios de cardio
                    CantidadCardioInicio = 2;
                    CantidadTonificacion = 4;
                    CantidadCardioFinal = 2;
                    break;
                case 2://Tonificar
                    //metemos mas ejercicios de tonificacion
                    CantidadCardioInicio = 1;
                    CantidadTonificacion = 6;
                    CantidadCardioFinal = 1;
                    break;
                case 0://Mantenerse
                default:
                    CantidadCardioInicio = 1;
                    CantidadTonificacion = 4;
                    CantidadCardioFinal = 1;
                    break;
            }

            //guardar todos los ejercicios de tipo Cardio en una lista aparte
            List<Ejercicio> EjerciciosCardio =
                    (from ejercicio in ListaEjercicios
                     where ejercicio.AreaATrabajar == "Cardio"
                     select ejercicio).ToList();
            //lista para guardar los ejercicios del dia anterior con el fin de no repetir ejercicios
            List<int> IdEjerciciosDiaAnterior = new List<int>();

            //ejercicios que se van a agregar a la rutina
            List<EjercicioRutina> EjerciciosRutinaAgregar = new List<EjercicioRutina>();
            int IndexAreasATrabajar = 0;

            //generar los ejercicios para 4 dias
            for (int i = 1; i < 5; i++)
            {
                List<Ejercicio> EjerciciosRutina = new List<Ejercicio>();
                List<Ejercicio> EjerciciosCardioEsteDia = new List<Ejercicio>(EjerciciosCardio);
                List<string> AreasATrabajarEsteDia = new List<string>();

                //agregar los ejercicios de cardio para iniciar la rutina
                for (int j = 0; j < CantidadCardioInicio; j++)
                {
                    EjerciciosRutina.Add(GetRandomElement(EjerciciosCardioEsteDia));
                }

                //obtener que areas a trabajar vamos a tomar en cuenta para este dia
                //solo seleccionar 2 partes por dia
                for (int j = 0; j < 2; j++)
                {
                    if (IndexAreasATrabajar > AreasATrabajarUsuario.Count)
                    {
                        //empezar desde el inicio otra vez
                        IndexAreasATrabajar = 0;
                    }

                    AreasATrabajarEsteDia.Add(AreasATrabajarUsuario[j]);
                    IndexAreasATrabajar++;
                }

                //teniendo ya las areas que queremos trabajar este dia, procedemos a tomar los ejercicios
                foreach (string area in AreasATrabajarEsteDia)
                {
                    //primero tomamos todos los ejercicios de esa area
                    List<Ejercicio> EjerciciosAConsiderarEsteDia =
                        (from ejercicio in ListaEjercicios
                         where ejercicio.AreaATrabajar == area
                         select ejercicio).ToList();

                    //ahora tomamos unos ejercicios aleatorios para hoy
                    //dividimos entre 2 para meter la mitad de ejercicios de una zona y la mitad de otra
                    for (int j = 0; j < CantidadTonificacion / 2; j++)
                    {
                        EjerciciosRutina.Add(GetRandomElement(EjerciciosAConsiderarEsteDia));
                    }
                }


                //agregar los ejercicios de cardio para finalizar la rutina
                for (int j = 0; j < CantidadCardioFinal; j++)
                {
                    EjerciciosRutina.Add(GetRandomElement(EjerciciosCardioEsteDia));
                }



                foreach (Ejercicio ejercicio in EjerciciosRutina)
                {
                    EjerciciosRutinaAgregar.Add(new EjercicioRutina
                    {
                        IdRutina = Rutina.IdRutina,
                        IdEjercicio = ejercicio.IdEjercicio,
                        DiaEjercicio = i,
                        Ejercicio = ejercicio
                    });
                }

            }//fin foreach de dias
            Rutina.EjerciciosRutina = EjerciciosRutinaAgregar;
            return Rutina;
        }

        //metodo para obtener un elemento aleatorio de una lista sin repeticion
        public static T GetRandomElement<T>(List<T> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            T element = list[index];
            list.RemoveAt(index);
            return element;
        }
    }
}
