using CO.DAL.Abstract;
using CO.DAL.Concrete;
using CO.Entity;
using CO.Entity.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CO.DAL.Repository
{
   public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
   {
      private readonly MongoContext mongoContext = null;
      private IMongoCollection<TEntity> collection { get; }

      public MongoRepository(IOptions<DatabaseSettings> settings)
      {
         mongoContext = new MongoContext(settings);
         collection = mongoContext.mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
      }

      public async Task<TEntity> Get(string id)
      {
         ObjectId objId = GetInternalId(id);
         return await collection.Find<TEntity>(x => x.Id == id || x.objectId == objId).FirstOrDefaultAsync();
      }

      public async Task<IEnumerable<TEntity>> GetAll()
      {
         return await collection.Find(x => true).ToListAsync();
      }

      public void Add(TEntity entity)
      {
         collection.InsertOne(entity);
      }

      public void AddRange(IEnumerable<TEntity> list)
      {
         collection.InsertMany(list);
      }

      public void Update(TEntity entity, string id)
      {
         collection.ReplaceOne(x => x.Id == id, entity);
      }

      public void Delete(string id)
      {
         var objId = new ObjectId(id);
         collection.DeleteOne(m => m.Id == id);
      }

      private ObjectId GetInternalId(string id)
      {
         ObjectId internalId;
         if (!ObjectId.TryParse(id, out internalId))
            internalId = ObjectId.Empty;

         return internalId;
      }


   }
}
