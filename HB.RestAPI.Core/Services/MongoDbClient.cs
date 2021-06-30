using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace HB.RestAPI.Core.Services
{

    /// <summary>
    /// This <see cref="MongoDbClient"/> makes
    /// the connection with Mongo DB
    /// </summary>
    public class MongoDbClient : IDbClient
    {
        private readonly IMongoCollection<ApplicationDataContainer> _dataNodes;

        /// <summary>
        /// Construct a <see cref="MongoDbClient"/>.
        /// </summary>
        public MongoDbClient(IOptions<DataBaseSettings> dataBaseSettings)
        {
            var client = new MongoClient(dataBaseSettings.Value.ConnectionString);

            var database = client.GetDatabase(dataBaseSettings.Value.DatabaseName);

            _dataNodes = database.GetCollection<ApplicationDataContainer>(dataBaseSettings.Value.CollectionName);
        }

        /// <summary>
        /// Gets the collection object which defines the
        /// data base.
        /// </summary>
        public IMongoCollection<ApplicationDataContainer> GetDataNodeCollection() => _dataNodes;
    }
}
