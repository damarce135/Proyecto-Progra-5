using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UI.Models;
using data = UI.Models; 

namespace UI.Controllers
{
    [Authorize]
    public class CalificacionController : Controller
    {
        string baseurl = "http://localhost:59634/";

        // GET: Calificacion
        public async Task<IActionResult> Index()
        {
            List<data.Calificacion> aux = new List<data.Calificacion>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Calificacion");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Calificacion>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: Calificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = GetById(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        [AllowAnonymous]
        // GET: Calificacion/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(GetAllCursos(), "IdCurso", "NombreCurso");
            ViewData["IdEtiqueta"] = new SelectList(GetAllEtiquetas(), "IdEtiqueta", "NombreEtiqueta");
            ViewData["IdProfesor"] = new SelectList(GetAllProfesors(), "IdProfesor", "Fullname");
            ViewData["IdCarrera"] = new SelectList(GetAllCarreras(), "IdCarrera", "NombreCarrera");
            return View();
        }

        [AllowAnonymous]
        // POST: Calificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalificacion,IdProfesor,IdCurso,IdCarrera,Facilidad,Apoyo,Claridad,Estado,Comentario,IdEtiqueta,Recomienda,Puntaje")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    calificacion.Estado = false;
                    calificacion.Puntaje = (byte?)((calificacion.Apoyo + calificacion.Claridad + calificacion.Facilidad) / 3);
                    cl.BaseAddress = new Uri(baseurl);
                    var content = JsonConvert.SerializeObject(calificacion);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Calificacion", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            ViewData["IdCarrera"] = new SelectList(GetAllCarreras(), "IdCarrera", "NombreCarrera", calificacion.IdCarrera);
            ViewData["IdCurso"] = new SelectList(GetAllCursos(), "IdCurso", "NombreCurso", calificacion.IdCurso);
            ViewData["IdEtiqueta"] = new SelectList(GetAllEtiquetas(), "IdEtiqueta", "NombreEtiqueta", calificacion.IdEtiqueta);
            ViewData["IdProfesor"] = new SelectList(GetAllProfesors(), "IdProfesor", "Fullname", calificacion.IdProfesor);
            return View(calificacion);
        }

        // GET: Calificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = GetById(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["IdCarrera"] = new SelectList(GetAllCarreras(), "IdCarrera", "NombreCarrera", calificacion.IdCarrera);
            ViewData["IdCurso"] = new SelectList(GetAllCursos(), "IdCurso", "NombreCurso", calificacion.IdCurso);
            ViewData["IdEtiqueta"] = new SelectList(GetAllEtiquetas(), "IdEtiqueta", "NombreEtiqueta", calificacion.IdEtiqueta);
            ViewData["IdProfesor"] = new SelectList(GetAllProfesors(), "IdProfesor", "Fullname", calificacion.IdProfesor);
            return View(calificacion);
        }

        // POST: Calificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalificacion,IdProfesor,IdCurso,IdCarrera,Facilidad,Apoyo,Claridad,Estado,Comentario,IdEtiqueta,Recomienda,Puntaje")] Calificacion calificacion)
        {
            if (id != calificacion.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseurl);
                        var content = JsonConvert.SerializeObject(calificacion);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/Calificacion/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCarrera"] = new SelectList(GetAllCarreras(), "IdCarrera", "NombreCarrera", calificacion.IdCarrera);
            ViewData["IdCurso"] = new SelectList(GetAllCursos(), "IdCurso", "NombreCurso", calificacion.IdCurso);
            ViewData["IdEtiqueta"] = new SelectList(GetAllEtiquetas(), "IdEtiqueta", "NombreEtiqueta", calificacion.IdEtiqueta);
            ViewData["IdProfesor"] = new SelectList(GetAllProfesors(), "IdProfesor", "Fullname", calificacion.IdProfesor);
            return View(calificacion);
        }

        // GET: Calificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = GetById(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/Calificacion/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private data.Calificacion GetById(int? id)
        {
            data.Calificacion aux = new data.Calificacion();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
               
                HttpResponseMessage res = cl.GetAsync("api/Calificacion/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<data.Calificacion>(auxres);
                }
            }
            return aux;
        }

        private List<data.Carrera> GetAllCarreras()
        {
            List<data.Carrera> aux = new List<data.Carrera>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Carrera").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<data.Carrera>>(auxres);
                }
            }
            return aux;
        }

        private List<data.Curso> GetAllCursos()
        {
            List<data.Curso> aux1 = new List<data.Curso>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Curso").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux1 = JsonConvert.DeserializeObject<List<data.Curso>>(auxres);
                }
            }
            return aux1;
        }

        private List<data.Profesor> GetAllProfesors()
        {
            List<data.Profesor> aux1 = new List<data.Profesor>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Profesor").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux1 = JsonConvert.DeserializeObject<List<data.Profesor>>(auxres);
                }
            }
            return aux1;
        }

        private List<data.Etiqueta> GetAllEtiquetas()
        {
            List<data.Etiqueta> aux1 = new List<data.Etiqueta>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Etiquetum").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux1 = JsonConvert.DeserializeObject<List<data.Etiqueta>>(auxres);
                }
            }
            return aux1;
        }

    }
}
