using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HB.RestAPI.Core.Data
{
    public class ApplicationDataContainer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DbId { get; set; }

        public string Name { get; set; }

        //[BsonConstructor]
        //public ApplicationDataContainer(string name)
        //{
        //    this.Name = name;


        //}


    }
}
