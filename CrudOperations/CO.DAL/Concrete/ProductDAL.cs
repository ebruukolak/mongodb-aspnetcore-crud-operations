using CO.DAL.Abstract;
using CO.DAL.Repository;
using CO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CO.DAL.Concrete
{
   public class ProductDAL : RepositoryAccess<Product>, IProductDAL
   {
   }
}
