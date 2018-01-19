using ActiveCampaign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ActiveCampaign.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(NewContactModel model)
        {
            var url = "https://majesova.api-us1.com/admin/api.php?api_key=6275b2ca28d56f573f932cf9f64fdd6e7a29a02da005423f5c15cdafe7ba811c81da2755&api_action=contact_add&api_output=json";

            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("email", model.Email));
            values.Add(new KeyValuePair<string, string>("lastName", model.FirstName));
            values.Add(new KeyValuePair<string, string>("firstName", model.LastName));
            values.Add(new KeyValuePair<string, string>("phone", model.Phone));
            values.Add(new KeyValuePair<string, string>("orgname", model.OrgName));
            //Se agrega a una lista
            values.Add(new KeyValuePair<string, string>("tags", "api"));
            values.Add(new KeyValuePair<string, string>("p[1]", "1"));

            var result = await PostFormUrlEncoded<AddContactResponse>(url, values);

            if (result.result_code == 1)
            {
                ViewBag.Message = $"Contacto agregado con éxito id={result.subscriber_id}";
            }
            else {
                ViewBag.Message = result.result_message;
            }
            return View(model);
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


        public static async Task<TResult> PostFormUrlEncoded<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    return await response.Content.ReadAsAsync<TResult>();
                }
            }
        }
    }
}