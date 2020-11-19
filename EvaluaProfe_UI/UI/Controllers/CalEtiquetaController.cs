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
    public class CalEtiquetaController : Controller
    {
        string baseURL = "http://localhost:51725/";

        // GET: CalEtiqueta
        public async Task<IActionResult> Index()
        {
            List<CalEtiqueta> aux = new List<Models.CalEtiqueta>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/CalEtiqueta");
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.CalEtiqueta>>(auxR);
                }
            }
            return View(aux);
        }

        // GET: CalEtiqueta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calEtiqueta = await GetById(id);
            if (calEtiqueta == null)
            {
                return NotFound();
            }

            return View(calEtiqueta);
        }

        // GET: CalEtiqueta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalEtiqueta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalEtiqueta,IdCalificacion,IdEtiqueta")] CalEtiqueta calEtiqueta)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(baseURL);
                    var content = JsonConvert.SerializeObject(calEtiqueta);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage res = await cl.PostAsync("api/CalEtiqueta", byteContent);
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error, Please contact administrator");
            return View(calEtiqueta);
        }

        // GET: CalEtiqueta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calEtiqueta = await GetById(id);
            if (calEtiqueta == null)
            {
                return NotFound();
            }
            return View(calEtiqueta);
        }

        // POST: CalEtiqueta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalEtiqueta,IdCalificacion,IdEtiqueta")] CalEtiqueta calEtiqueta)
        {
            if (id != calEtiqueta.IdCalEtiqueta)
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
                        var content = JsonConvert.SerializeObject(calEtiqueta);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        HttpResponseMessage res = await cl.PutAsync("api/CalEtiqueta/" + id, byteContent);
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
            return View(calEtiqueta);
        }

        // GET: CalEtiqueta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calEtiqueta = await GetById(id);
            if (calEtiqueta == null)
            {
                return NotFound();
            }

            return View(calEtiqueta);
        }

        // POST: CalEtiqueta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/CalEtiqueta/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<CalEtiqueta> GetById(int? id)
        {
            CalEtiqueta aux = new CalEtiqueta();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/CalEtiqueta/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.CalEtiqueta>(auxR);
                }
            }
            return aux;
        }
    }
}
