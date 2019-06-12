using CO.DAL.Abstract;
using CO.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CO.DAL.Concrete
{
   public class MongoContext : IMongoContext
   {
      public IMongoDatabase mongoDatabase { get; }

      public MongoContext(IOptions<DatabaseSettings> settings)
      {
         var client = new MongoClient(settings.Value.ConnectionString);
         if (client != null)
            mongoDatabase = client.GetDatabase(settings.Value.Database);
      }
      //public MongoContext(string connectionString)
      //{
      //   mongoDatabase = new MongoClient(connectionString).GetDatabase(new MongoUrl(connectionString).DatabaseName);
      //}
   }
}
