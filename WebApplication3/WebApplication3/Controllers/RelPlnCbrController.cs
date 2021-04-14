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
    public class RelPlnCbrController : Controller
    {
        // GET: RelPlnCbr
        string Baseurl = "https://localhost:44369/api/";
        // GET: RelPlcCbr
        public async Task<ActionResult> Index()
        {
            List<RelPlcCbr> CliInfo = new List<RelPlcCbr>();

            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                API.DefaultRequestHeaders.Clear();
                //Define request data format  
                API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await API.GetAsync("REL_PLAN_COBER");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CliInfo = JsonConvert.DeserializeObject<List<RelPlcCbr>>(EmpResponse);

                }
            }
            return View(CliInfo);
        }

        public async Task<ActionResult> Create()
        {
            List<Cobertura> CliInfo = new List<Cobertura>();
            List<Plan> planInfo = new List<Plan>();

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
                HttpResponseMessage Res2 = await API.GetAsync("PLANES");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res2.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    planInfo = JsonConvert.DeserializeObject<List<Plan>>(EmpResponse);

                }
                ViewBag.Coberturas = CliInfo;
                ViewBag.planes = planInfo;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(RelPlcCbr RelPlcCbr)
        {

            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                var postTask = API.PostAsJsonAsync<RelPlcCbr>("REL_PLAN_COBER", RelPlcCbr);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            ModelState.AddModelError(string.Empty, "Error, Contate al administrador");
            return View(RelPlcCbr);
        }

        public ActionResult Edit(int id)
        {
            RelPlcCbr RelPlcCbr = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("REL_PLAN_COBER/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RelPlcCbr>();
                    readTask.Wait();
                    RelPlcCbr = readTask.Result;
                }

            }

            return View(RelPlcCbr);
        }

        [HttpPost]
        public ActionResult Edit(RelPlcCbr RelPlcCbr)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.PutAsJsonAsync("REL_PLAN_COBER/" + RelPlcCbr.IDpc + "", RelPlcCbr);
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(RelPlcCbr);
        }

        public ActionResult Delete(int id)
        {
            RelPlcCbr RelPlcCbr = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("REL_PLAN_COBER/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RelPlcCbr>();
                    readTask.Wait();
                    RelPlcCbr = readTask.Result;
                }

            }

            return View(RelPlcCbr);
        }

        [HttpPost]
        public ActionResult Delete(RelPlcCbr RelPlcCbr, int id)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.DeleteAsync("REL_PLAN_COBER/" + id + "");
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(RelPlcCbr);
        }
    }
}