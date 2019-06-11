using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CO.Entity.Abstract
{
    public abstract class BaseEntity
    {
      public ObjectId id { get; set; }
   }
}
