using CO.DAL.Abstract;
using CO.DAL.Repository;
using CO.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CO.DAL.Concrete
{
   public class ProductDAL : MongoRepository<Product>, IProductDAL
   {
      public ProductDAL(IOptions<DatabaseSettings> settings) : base(settings)
      {
      }
   }
}
