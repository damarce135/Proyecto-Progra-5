using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class CursoCarrerasController : Controller
    {
        string baseURL = "http://localhost:51725/";

        // GET: CursoCarreras
        public async Task<IActionResult> Index()
        {
            List<CursoCarrera> aux = new List<Models.CursoCarrera>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/CursoCarrera");
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.CursoCarrera>>(auxR);
                }
            }
            return View(aux);
        }

        // GET: CursoCarreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoCarrera = await GetById(id);
            if (cursoCarrera == null)
            {
                return NotFound();
            }

            return View(cursoCarrera);
        }

        // GET: CursoCarreras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCursoCarrera,IdCurso,IdCarrera")] CursoCarrera cursoCarrera)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseURL);
                    var content = JsonConvert.SerializeObject(cursoCarrera   );
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage res = await cl.PostAsync("api/CursoCarrera", byteContent);
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(cursoCarrera);
        }

        // GET: CursoCarreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoCarrera = await GetById(id);
            if (cursoCarrera == null)
            {
                return NotFound();
            }
            return View(cursoCarrera);
        }

        // POST: CursoCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCursoCarrera,IdCurso,IdCarrera")] CursoCarrera cursoCarrera)
        {
            if (id != cursoCarrera.IdCursoCarrera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(baseURL);
                        var content = JsonConvert.SerializeObject(cursoCarrera);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        HttpResponseMessage res = await cl.PutAsync("api/CursoCarrera/" + id, byteContent);
                        if (res.IsSuccessStatusCode)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (Exception ee)
                {
                    var temp = await GetById(id);
                    if (temp == null)
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
            return View(cursoCarrera);
        }

        // GET: CursoCarreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoCarrera = await GetById(id);
            if (cursoCarrera == null)
            {
                return NotFound();
            }

            return View(cursoCarrera);
        }

        // POST: CursoCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/CursoCarrera/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<CursoCarrera> GetById(int? id)
        {
            CursoCarrera aux = new CursoCarrera();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/CursoCarrera/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.CursoCarrera>(auxR);
                }
            }
            return aux;
        }
    }
}
