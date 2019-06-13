using CO.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CO.Manager.Abstract
{
   public interface IProductManager
   {
      Task<Product> GetByID(string Id);
      Task<IEnumerable<Product>> GetProducts();
      void Add(Product p);
      void AddManyProducts(List<Product> products);
      void Update(Product p, string Id);
      void Delete(string Id);
   }
}
