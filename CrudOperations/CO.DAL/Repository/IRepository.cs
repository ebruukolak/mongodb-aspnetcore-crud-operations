using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CO.DAL.Repository
{
   public interface IRepository<T> where T : class
   {
      Task<T> Get(string id);
      Task<IEnumerable<T>> GetAll();      
      void Add(T entity);
      void AddRange(List<T> list);
      void Update(T entity, string id);
      void Delete(string id);    
   }
}
