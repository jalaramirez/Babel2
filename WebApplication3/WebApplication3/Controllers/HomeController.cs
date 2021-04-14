using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Clientes");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        string Baseurl = "https://localhost:44369/api/";
        // GET: CLientes
        public async Task<ActionResult> Clientes()
        {
            List<Cliente> CliInfo = new List<Cliente>();

            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                API.DefaultRequestHeaders.Clear();
                //Define request data format  
                API.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await API.GetAsync("CLIENTES");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CliInfo = JsonConvert.DeserializeObject<List<Cliente>>(EmpResponse);

                }
            }
            return View(CliInfo);
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente Cliente)
        {
            if (Cliente.APMATERNO == string.Empty||
                Cliente.APPATERNO == string.Empty ||
                Cliente.NOMBRE== string.Empty
                ) {
                ModelState.AddModelError(string.Empty, "Error, Se debe llenar todo los campos");
                return View(Cliente);
            }
            if (Cliente.APMATERNO == null ||
                Cliente.APPATERNO == null ||
                Cliente.NOMBRE == null
                )
            {
                ModelState.AddModelError(string.Empty, "Error, Se debe llenar todo los campos");
                return View(Cliente);
            }
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);

                var postTask = API.PostAsJsonAsync<Cliente>("CLIENTES", Cliente);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Clientes");

                }
                if (result.ReasonPhrase == "Conflict")
                {
                    ModelState.AddModelError(string.Empty, "Error, El Cliente ya existe");

                }
            }

            ModelState.AddModelError(string.Empty,"Error, Contate al administrador");
            return View(Cliente);
        }

        public ActionResult Details(int id)
        {
            Cliente cliente = null;
            List <Plan> CP = new List<Plan>();
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("CLIENTES/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Cliente>();
                    readTask.Wait();
                    cliente = readTask.Result;
                }
                foreach (RelCliPln i in cliente.REL_CLIENTE_PLAN ) {
                    CP.Add(i.PLANES);
                }

            }

            return View(cliente);
        }
        public ActionResult Edit(int id)
        {
            Cliente cliente = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("CLIENTES/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask =  result.Content.ReadAsAsync<Cliente>();
                    readTask.Wait();
                    cliente = readTask.Result;
                }

            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente Cliente)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.PutAsJsonAsync("CLIENTES/" + Cliente.IDCLIENTE + "", Cliente);
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Clientes");
                }
            }

            return View(Cliente);
        }

        public ActionResult Delete(int id)
        {
            Cliente cliente = null;
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.GetAsync("CLIENTES/" + id.ToString());
                responstask.Wait();

                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Cliente>();
                    readTask.Wait();
                    cliente = readTask.Result;
                }

            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(Cliente Cliente,int id)
        {
            using (var API = new HttpClient())
            {
                API.BaseAddress = new Uri(Baseurl);
                var responstask = API.DeleteAsync("CLIENTES/" + id + "");
                responstask.Wait();
                var result = responstask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Clientes");
                }
            }

            return View(Cliente);
        }


    }
}