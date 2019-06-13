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

      public IActionResult CreateProduct()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
      {
         if (!ModelState.IsValid)
            return View(productViewModel);

         using (HttpClient client = new HttpClient())
         {
            var productData = JsonConvert.SerializeObject(productViewModel);
            HttpContent content = new StringContent(productData, System.Text.Encoding.UTF8, "application/json");

            await client.PostAsync("http://localhost:3986/api/mongoapi/", content);

            return RedirectToAction("GetList");
         }

      }

      [HttpPost]
      public async Task<IActionResult> CreateProducts()
      {
         List<ProductViewModel> products = new List<ProductViewModel>();
         for (int i = 0; i < 1000; i++)
         {
            products.Add(new ProductViewModel
            {
               Id = Guid.NewGuid().ToString(),
               Name = "name",
               Value = "value"
            });

         }
         using (HttpClient client = new HttpClient())
         {
            var productData = JsonConvert.SerializeObject(products);
            HttpContent content = new StringContent(productData, System.Text.Encoding.UTF8, "application/json");

            await client.PostAsync("http://localhost:3986/api/mongoapi/CreateProducts", content);

            return RedirectToAction("GetList");
         }

      }


      [HttpPut]
      public async Task<IActionResult> EditProduct(ProductViewModel productViewModel)
      {
         using (HttpClient client = new HttpClient())
         {
            var productData = JsonConvert.SerializeObject(productViewModel);
            HttpContent content = new StringContent(productData, System.Text.Encoding.UTF8, "application/json");

            await client.PutAsync("http://localhost:3986/api/mongoapi/", content);

            return RedirectToAction("GetList");
         }
      }

      [HttpDelete]
      public async Task<IActionResult> DeleteProduct(string id)
      {
         using (HttpClient client = new HttpClient())
         {
            var result = await client.DeleteAsync($"http://localhost:3986/api/mongoapi/{id}");

            if (result.IsSuccessStatusCode)
            {
               return RedirectToAction("GetList");
            }
            return null;
         }
      }
   }
}