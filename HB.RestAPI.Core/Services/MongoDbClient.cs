using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Data;
using HB.RestAPI.Core.Interfaces;
using HB.RestAPI.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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
        public MongoDbClient(IOptions<MongoDbSettings> dataBaseSettings)
        {
          
            var client = new MongoClient(dataBaseSettings.Value.ConnectionString);

            var database = client.GetDatabase(dataBaseSettings.Value.DatabaseName);

            _dataNodes = database.GetCollection<ApplicationDataContainer>(dataBaseSettings.Value.CollectionName);
        }

        /// <summary>
        /// Gets the collection object which defines the
        /// data base.
        /// </summary>
        public IMongoCollection<ApplicationDataContainer> GetApplicationDataContainer() => _dataNodes;
    }
}
