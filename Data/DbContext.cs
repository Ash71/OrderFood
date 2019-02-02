using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFood.Data
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _db;
        public DbContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<FoodItem> FoodItem => _db.GetCollection<FoodItem>("FoodItems");

        //IMongoCollection<FoodItem> IDbContext.FoodItem => throw new NotImplementedException();
    }

}
