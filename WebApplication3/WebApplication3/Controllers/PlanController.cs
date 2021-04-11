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
    public class PlanController : Controller
    {
        string Baseurl = "https://localhost:44369/api/";
        // GET: Plan
        public async Task<ActionResult> Planes()
        {
            List<Plan> CliInfo = new List<Plan>();

            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                API.DefaultRequestHeaders.Clear();
                //Define request data format  
                API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await API.GetAsync("PLANES");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CliInfo = JsonConvert.DeserializeObject<List<Plan>>(EmpResponse);

                }
            }
            return View(CliInfo);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Plan Plan)
        {
            if (Plan.DESCRIPCION == string.Empty
                )
            {
                ModelState.AddModelError(string.Empty, "Error, Se debe llenar todo los campos");
                return View(Plan);
            }
            if (Plan.DESCRIPCION == null 
                )
            {
                ModelState.AddModelError(string.Empty, "Error, Se debe llenar todo los campos");
                return View(Plan);
            }
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                var postTask = API.PostAsJsonAsync<Plan>("PLANES", Plan);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Plans");

                }
            }

            ModelState.AddModelError(string.Empty, "Error, Contate al administrador");
            return View(Plan);
        }

        public ActionResult Edit(int id)
        {
            Plan Plan = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("PLANES/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Plan>();
                    readTask.Wait();
                    Plan = readTask.Result;
                }

            }

            return View(Plan);
        }

        [HttpPost]
        public ActionResult Edit(Plan Plan)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.PutAsJsonAsync("PLANES/" + Plan.IDPLAN  + "", Plan);
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Planes");
                }
            }

            return View(Plan);
        }
        public ActionResult Delete(int id)
        {
            Plan Plan1 = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("PLANES/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Plan>();
                    readTask.Wait();
                    Plan1 = readTask.Result;
                }

            }

            return View(Plan1);
        }

        [HttpPost]
        public ActionResult Delete(Plan Plan, int id)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.DeleteAsync("PLANES/" + id + "");
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Planes");
                }
            }

            return View(Plan);
        }
    }
}