using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFood.Models
{
    public class FoodItem
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        
    }
}
