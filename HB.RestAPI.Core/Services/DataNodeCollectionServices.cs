using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HB.RestAPI.Core.Models;
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
        private readonly IMongoCollection<ApplicationDataContainer> _dataNodes;
        private readonly FilterDefinition<ApplicationDataContainer> _emptyFilter;

        /// <summary>
        /// Construct a <see cref="DataNodeCollectionServices"/>.
        /// </summary>
        /// <param name="dbClient">A data base client.</param>
        public DataNodeCollectionServices(IDbClient dbClient)
        {
            _dataNodes = dbClient.GetDataNodeCollection();
            _emptyFilter = Builders<ApplicationDataContainer>.Filter.Empty;
        }

        /// <summary>
        /// This method will add the <paramref name="applicationDataContainer"/>
        /// to the Mongo DB, as an async HTTP POST request by the controller.
        /// </summary>
        public async Task<ApplicationDataContainer> Create(ApplicationDataContainer applicationDataContainer)
        {
          var task =  _dataNodes.InsertOneAsync(applicationDataContainer);

          await task;

          return applicationDataContainer;
        }

        /// <summary>
        /// Get the most recent uploaded <see cref="ApplicationDataContainer"/>
        /// to the HB REST API data base.
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationDataContainer> GetLatest()
        {
            var filter = _emptyFilter;

            var foundContainers = await _dataNodes.FindAsync(filter);

            var list = await foundContainers.ToListAsync();

            var latestContainer = list.OrderByDescending(d => d.UploadTime).FirstOrDefault();

            return latestContainer;
        }

        /// <summary>
        /// Deletes all entries from the SybariteSync data base.
        /// </summary>
        /// <returns>
        /// <see langword="true" /> if all the <see cref="ProjectStream" /> where
        /// deleted succesfully , otherwise <see langword="false" />.
        /// </returns>
        public async Task<bool> DeleteAllEntries()
        {
            try
            {
                var deleteResult = await _dataNodes.DeleteManyAsync(_emptyFilter);

                bool isAcknowledged = deleteResult.IsAcknowledged;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
