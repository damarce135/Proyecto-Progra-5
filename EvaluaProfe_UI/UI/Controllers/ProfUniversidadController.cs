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
    public class ProfUniversidadController : Controller
    {
        string baseURL = "http://localhost:51725/";

        // GET: ProfUniversidad
        public async Task<IActionResult> Index()
        {
            List<ProfUniversidad> aux = new List<Models.ProfUniversidad>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/ProfUniversidad");
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.ProfUniversidad>>(auxR);
                }
            }
            return View(aux);
        }

        // GET: ProfUniversidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profUniversidad = await GetById(id);
            if (profUniversidad == null)
            {
                return NotFound();
            }

            return View(profUniversidad);
        }

        // GET: ProfUniversidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfUniversidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfUniversidad,IdProfesor,IdProfUniversidad")] ProfUniversidad profUniversidad)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseURL);
                    var content = JsonConvert.SerializeObject(profUniversidad);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage res = await cl.PostAsync("api/ProfUniversidad", byteContent);
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(profUniversidad);
        }

        // GET: ProfUniversidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profUniversidad = await GetById(id);
            if (profUniversidad == null)
            {
                return NotFound();
            }
            return View(profUniversidad);
        }

        // POST: ProfUniversidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfUniversidad,IdProfesor,IdProfUniversidad")] ProfUniversidad profUniversidad)
        {
            if (id != profUniversidad.IdProfUniversidad)
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
                        var content = JsonConvert.SerializeObject(profUniversidad);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        HttpResponseMessage res = await cl.PutAsync("api/ProfUniversidad/" + id, byteContent);
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
            return View(profUniversidad);
        }

        // GET: ProfUniversidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profUniversidad = await GetById(id);
            if (profUniversidad == null)
            {
                return NotFound();
            }

            return View(profUniversidad);
        }

        // POST: ProfUniversidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/ProfUniversidad/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<ProfUniversidad> GetById(int? id)
        {
            ProfUniversidad aux = new ProfUniversidad();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/ProfUniversidad/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.ProfUniversidad>(auxR);
                }
            }
            return aux;
        }
    }
}
