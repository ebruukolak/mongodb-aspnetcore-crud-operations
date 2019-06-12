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
      void Update(Product p,string Id);
      void Delete(string Id);
   }
}
