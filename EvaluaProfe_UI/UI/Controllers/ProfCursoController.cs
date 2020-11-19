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
    public class ProfCursoController : Controller
    {
        string baseURL = "http://localhost:51725/";

        // GET: ProfCurso
        public async Task<IActionResult> Index()
        {
            List<ProfCurso> aux = new List<Models.ProfCurso>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/ProfCurso");
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.ProfCurso>>(auxR);
                }
            }
            return View(aux);
        }

        // GET: ProfCurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profCurso = await GetById(id);
            if (profCurso == null)
            {
                return NotFound();
            }

            return View(profCurso);
        }

        // GET: ProfCurso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfCurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfCurso,IdProfesor,IdCurso")] ProfCurso profCurso)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseURL);
                    var content = JsonConvert.SerializeObject(profCurso);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage res = await cl.PostAsync("api/ProfCurso", byteContent);
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(profCurso);
        }

        // GET: ProfCurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profCurso = await GetById(id);
            if (profCurso == null)
            {
                return NotFound();
            }
            return View(profCurso);
        }

        // POST: ProfCurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfCurso,IdProfesor,IdCurso")] ProfCurso profCurso)
        {
            if (id != profCurso.IdProfCurso)
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
                        var content = JsonConvert.SerializeObject(profCurso);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        HttpResponseMessage res = await cl.PutAsync("api/ProfCurso/" + id, byteContent);
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
            return View(profCurso);
        }

        // GET: ProfCurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profCurso = await GetById(id);
            if (profCurso == null)
            {
                return NotFound();
            }

            return View(profCurso);
        }

        // POST: ProfCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/ProfCurso/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<ProfCurso> GetById(int? id)
        {
            ProfCurso aux = new ProfCurso();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/ProfCurso/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.ProfCurso>(auxR);
                }
            }
            return aux;
        }
    }
}
