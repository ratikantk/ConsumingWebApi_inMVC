using EmployeeDataMVC.Helper;
using EmployeeDataMVC.Models;
using EmployeeDataWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeDataMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeAPI _api = new EmployeeAPI();
        public async Task<IActionResult> Index()
        {
            
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage getData = await client.GetAsync("Employee");
            List<mvcEmployee> modelList = new List<mvcEmployee>();
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<mvcEmployee>>(results);
            }
            return View(modelList);
        }

        public async Task<IActionResult> Details(int Id)
        {
           
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage getData = await client.GetAsync($"Employee/{Id}");
            var employee = new mvcEmployee();
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<mvcEmployee>(results);
            }
            return View(employee);

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(mvcEmployee employee)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var postEmployee = await client.PostAsJsonAsync<mvcEmployee>("Employee", employee);
            //postEmployee.Wait();

            var result =  postEmployee;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    //    [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var employee = new mvcEmployee();
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage putData = await client.GetAsync($"Employee/{id}");
            var employee = new mvcEmployee();
            if (putData.IsSuccessStatusCode)
            {
                string results = putData.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<mvcEmployee>(results);
            }
            return View("Edit",employee);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(mvcEmployee employee)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var editData = await client.PutAsJsonAsync<mvcEmployee>("Employee", employee);
            //postEmployee.Wait();

            var result = editData;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        //[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id )
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            
            // HttpResponseMessage delData = await client.DeleteAsync($"DeleteEmployee?empId={Id}");
            HttpResponseMessage delData = await client.DeleteAsync($"Employee/{Id}");
            var employee = new Employee();
            if (delData.IsSuccessStatusCode)
            {
                string results = delData.Content.ReadAsStringAsync().Result;
               
            }
            return RedirectToAction("Index");

        }
    }
}
