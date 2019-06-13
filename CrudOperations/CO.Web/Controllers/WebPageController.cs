using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CO.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CO.Web.Controllers
{
   public class WebPageController : Controller
   {
      public async Task<IActionResult> GetList()
      {
         using (HttpClient client = new HttpClient())
         {
            var productData = await client.GetAsync("http://localhost:3986/api/mongoapi/");
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(productData.Content.ReadAsStringAsync().Result);

            return View(products);
         }
      }

      public async Task<IActionResult> GetProduct(string id)
      {
         using (HttpClient client = new HttpClient())
         {
            var productData = await client.GetAsync($"http://localhost:3986/api/mongoapi/{id}");
            var product = JsonConvert.DeserializeObject<ProductViewModel>(productData.Content.ReadAsStringAsync().Result);

            return View(product);
         }
      }
   }
}