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
         var objID=new ObjectId(id);
         return await collection.Find<TEntity>(x => x.id== objID).FirstOrDefaultAsync();
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
         var objId = new ObjectId(id);
         collection.ReplaceOne(x => x.id == objId, entity);
      }

      public void Delete(string id)
      {
         var objId = new ObjectId(id);
         collection.DeleteOne(m => m.id == objId);
      }
   }
}
