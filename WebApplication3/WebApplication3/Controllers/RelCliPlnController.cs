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
    public class RelCliPlnController : Controller
    {
        string Baseurl = "https://localhost:44369/api/";
        // GET: RelCliPln
        public async Task<ActionResult> Index()
        {
            List<RelCliPln> CliInfo = new List<RelCliPln>();

            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                API.DefaultRequestHeaders.Clear();
                //Define request data format  
                API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await API.GetAsync("REL_CLIENTE_PLAN");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CliInfo = JsonConvert.DeserializeObject<List<RelCliPln>>(EmpResponse);

                }
            }
            return View(CliInfo);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RelCliPln RelCliPln)
        {
           
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                var postTask = API.PostAsJsonAsync<RelCliPln>("REL_CLIENTE_PLAN", RelCliPln);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            ModelState.AddModelError(string.Empty, "Error, Contate al administrador");
            return View(RelCliPln);
        }

        public ActionResult Edit(int id)
        {
            RelCliPln RelCliPln = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("REL_CLIENTE_PLAN/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RelCliPln>();
                    readTask.Wait();
                    RelCliPln = readTask.Result;
                }

            }

            return View(RelCliPln);
        }

        [HttpPost]
        public ActionResult Edit(RelCliPln RelCliPln)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.PutAsJsonAsync("REL_CLIENTE_PLAN/" + RelCliPln.IDCP + "", RelCliPln);
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(RelCliPln);
        }

        public ActionResult Delete(int id)
        {
            RelCliPln RelCliPln = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("REL_CLIENTE_PLAN/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RelCliPln>();
                    readTask.Wait();
                    RelCliPln = readTask.Result;
                }

            }

            return View(RelCliPln);
        }

        [HttpPost]
        public ActionResult Delete(RelCliPln RelCliPln, int id)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.DeleteAsync("REL_CLIENTE_PLAN/" + id + "");
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(RelCliPln);
        }
    }
}