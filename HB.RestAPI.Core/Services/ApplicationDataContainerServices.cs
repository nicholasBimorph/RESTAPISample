using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HB.RestAPI.Core.Data;
using HB.RestAPI.Core.Interfaces;
using MongoDB.Driver;

namespace HB.RestAPI.Core.Services
{
    /// <summary>
    /// This class directly interacts with the data base collection,
    /// and has all the methods which will map to HTTP request's
    /// in the controller.
    /// </summary>
    public class ApplicationDataContainerServices: IDbCollectionServices
    {
        private readonly IMongoCollection<ApplicationDataContainer> _applicationDataContainer;

        /// <summary>
        /// Construct a <see cref="DataNodeCollectionServices"/>.
        /// </summary>
        /// <param name="dbClient">A data base client.</param>
        public ApplicationDataContainerServices(IDbClient dbClient)
        {
            _applicationDataContainer = dbClient.GetApplicationDataContainer();
        }

        /// <summary>
        /// This method will add the <paramref name="applicationDataContainer"/>
        /// to the Mongo DB, as an async HTTP POST request by the controller.
        /// </summary>
        public async Task<ApplicationDataContainer> Create(ApplicationDataContainer applicationDataContainer)
        {
            var task = _applicationDataContainer.InsertOneAsync(applicationDataContainer);

            await task;

            return applicationDataContainer;
        }
    }
}
