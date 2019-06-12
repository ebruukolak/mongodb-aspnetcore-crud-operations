using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CO.DAL.Abstract
{
    public interface IMongoContext
    {
      IMongoDatabase mongoDatabase { get; }
    }
}
