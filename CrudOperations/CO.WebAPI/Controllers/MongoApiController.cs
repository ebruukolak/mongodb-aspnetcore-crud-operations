using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CO.Entity;
using CO.Manager.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CO.WebAPI.Controllers
{
   [Produces("application/json")]
   [Route("api/[controller]")]
   public class MongoApiController : Controller
   {
      IProductManager _productManager;

      public MongoApiController(IProductManager productManager)
      {
         _productManager = productManager;

      }

      [HttpGet]
      public async Task<IEnumerable<Product>> Get()
      {
         return await _productManager.GetProducts();
      }

      [HttpGet("{id}")]
      public async Task<Product> Get(string id)
      {
         return await _productManager.GetByID(id);
      }


      [HttpPost]
      public void Post(Product product)
      {
         _productManager.Add(new Product
         {
            Id = product.Id,
            Name = product.Name,
            Value = product.Value
         });
      }

      [HttpPut("{id}")]
      public void Put(Product product, string id)
      {
         _productManager.Update(product, id);
      }

      [HttpDelete("{id}")]
      public void Delete(string id)
      {
         _productManager.Delete(id);
      }
   }
}