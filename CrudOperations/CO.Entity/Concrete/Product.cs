using CO.Entity.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace CO.Entity
{
   public class Product : BaseEntity
   {
      [BsonElement("Name")]
      public string Name { get; set; }
      [BsonElement("Value")]
      public string Value { get; set; }
   }
}
