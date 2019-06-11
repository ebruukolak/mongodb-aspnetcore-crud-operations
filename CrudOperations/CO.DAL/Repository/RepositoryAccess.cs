using System;
using System.Collections.Generic;
using System.Text;

namespace CO.DAL.Repository
{
   public class RepositoryAccess<TEntity> : IRepositoryAccess<TEntity> where TEntity : class, new()
   {
      public TEntity Get(int ID)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<TEntity> GetAll()
      {
         throw new NotImplementedException();
      }
      public void Insert(TEntity entity)
      {
         throw new NotImplementedException();
      }
      public void Update(TEntity entity)
      {
         throw new NotImplementedException();
      }
      public void Delete(TEntity entity)
      {
         throw new NotImplementedException();
      }
   }
}
