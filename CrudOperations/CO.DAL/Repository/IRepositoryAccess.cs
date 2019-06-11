using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CO.DAL.Repository
{
   public interface IRepositoryAccess<T> where T : class, new()
   {
      T Get(int ID);
      IEnumerable<T> GetAll();
      void Insert(T entity);
      void Update(T entity);
      void Delete(T entity);
   }
}
