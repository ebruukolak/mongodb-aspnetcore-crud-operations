using CO.DAL.Abstract;
using CO.Entity;
using CO.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CO.Manager.Concrete
{
   public class ProductManager : IProductManager
   {
      IProductDAL _productDAL;
      public ProductManager(IProductDAL productDAL)
      {
         _productDAL = productDAL;
      }

      public async Task<Product> GetByID(string Id)
      {
         if (!string.IsNullOrEmpty(Id))
         {
            return await _productDAL.Get(Id);
         }
         return null;
      }

      public async Task<IEnumerable<Product>> GetProducts()
      {
         return await _productDAL.GetAll();
      }
      public void Add(Product p)
      {
         _productDAL.Add(p);
      }

      public void Delete(string Id)
      {
         _productDAL.Delete(Id);
      }
      
      public void Update(Product p,string Id)
      {
         _productDAL.Update(p,Id);
      }

      public void AddManyProducts(List<Product> products)
      {
         _productDAL.AddRange(products);
      }
   }
}
