using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace HB.RestAPI.Core.Services
{
    /// <summary>
    /// This class directly interacts with the data base collection,
    /// and has all the methods which will map to HTTP request's
    /// in the controller.
    /// </summary>
    public class DataNodeCollectionServices : IDbCollectionServices
    {
        private readonly IMongoCollection<WeatherForecast> _dataNodes;

        /// <summary>
        /// Construct a <see cref="DataNodeCollectionServices"/>.
        /// </summary>
        /// <param name="dbClient">A data base client.</param>
        public DataNodeCollectionServices(IDbClient dbClient)
        {
            _dataNodes = dbClient.GetDataNodeCollection();
        }

        /// <summary>
        /// This method will add the <paramref name="weatherForecast"/>
        /// to the Mongo DB, as an async HTTP POST request by the controller.
        /// </summary>
        public async Task<WeatherForecast> Create(WeatherForecast weatherForecast)
        {
          var task =  _dataNodes.InsertOneAsync(weatherForecast);

          await task;

          return weatherForecast;
        }
    }
}
