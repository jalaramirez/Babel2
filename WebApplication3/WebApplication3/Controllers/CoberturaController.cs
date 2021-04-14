using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class CoberturaController : Controller

    {
        string Baseurl = "https://localhost:44369/api/";
        // GET: Cobertura
        public async Task<ActionResult> Coberturas()
        {
            List<Cobertura> CliInfo = new List<Cobertura>();

            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                API.DefaultRequestHeaders.Clear();
                //Define request data format  
                API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await API.GetAsync("COBERTURAs");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CliInfo = JsonConvert.DeserializeObject<List<Cobertura>>(EmpResponse);

                }
            }
            return View(CliInfo);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cobertura Cobertura)
        {
            if (Cobertura.DESCRIPCION == string.Empty
                )
            {
                ModelState.AddModelError(string.Empty, "Error, Se debe llenar todo los campos");
                return View(Cobertura);
            }
            if (Cobertura.DESCRIPCION == null
                )
            {
                ModelState.AddModelError(string.Empty, "Error, Se debe llenar todo los campos");
                return View(Cobertura);
            }
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                var postTask = API.PostAsJsonAsync<Cobertura>("Coberturas", Cobertura);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Coberturas");

                }
            }

            ModelState.AddModelError(string.Empty, "Error, Contate al administrador");
            return View(Cobertura);
        }

        public ActionResult Edit(int id)
        {
            Cobertura Cobertura = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("CoberturaS/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Cobertura>();
                    readTask.Wait();
                    Cobertura = readTask.Result;
                }

            }

            return View(Cobertura);
        }

        [HttpPost]
        public ActionResult Edit(Cobertura Cobertura)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.PutAsJsonAsync("CoberturaS/" + Cobertura.IDCOBERTURA + "", Cobertura);
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Coberturas");
                }
            }

            return View(Cobertura);
        }

        public ActionResult Delete(int id)
        {
            Cobertura Cobertura = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("CoberturaS/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Cobertura>();
                    readTask.Wait();
                    Cobertura = readTask.Result;
                }

            }

            return View(Cobertura);
        }

        [HttpPost]
        public ActionResult Delete(Cobertura Cobertura, int id)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.DeleteAsync("CoberturaS/" + id + "");
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Coberturas");
                }
            }

            return View(Cobertura);
        }
    }
}