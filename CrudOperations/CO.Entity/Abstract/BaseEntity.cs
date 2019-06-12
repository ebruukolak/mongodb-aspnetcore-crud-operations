using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CO.Entity.Abstract
{
   public abstract class BaseEntity
   {
      //[BsonId]
      //public ObjectId id { get; set; }

      [BsonId]
      public ObjectId objectId { get; set; }

      public string Id { get; set; }
   }
}
