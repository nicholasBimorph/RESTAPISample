using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace HB.RestAPI.Core.Models
{
    public class DataNode
    {
        /// <summary>
        /// A json string which represents the entity this
        /// <see cref="DataNode"/> stores.
        /// </summary>
        public string RawData { get; set; }

        /// <summary>
        /// The concrete <see cref="Type"/>
        /// this <see cref="DataNode"/> stores.
        /// </summary>
        public string EntityType { get; set; }

        [BsonConstructor]
        public DataNode(string rawData, Type entityType)
        {
            this.RawData = rawData;

            this.EntityType = entityType.ToString();
        }

        public DataNode(){}

        /// <summary>
        /// Default constructor needed for Mongo DB.
        /// WARNING: Do not remove!
        /// </summary>
       // public DataNode() { }

        /// <summary>
        /// Gets the <see cref="Type"/> of the
        /// <see cref="IEntity"/> stored in this <see cref="DataNode"/>.
        /// </summary>
        public Type GetObjectType()
        {
            string assemblyName = Assembly.GetAssembly(this.GetType()).FullName;

            var realType = Type.GetType($"{this.EntityType},{assemblyName}");

            return realType;
        }
    }
}
