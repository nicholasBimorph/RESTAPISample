using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Data;
using MongoDB.Driver;

namespace HB.RestAPI.Core.Interfaces
{
    /// <summary>
    /// A contract to define a data base client.
    /// </summary>
    public interface IDbClient
    {
        /// <summary>
        /// Gets the collection object which defines the
        /// data base.
        /// </summary>
        IMongoCollection<ApplicationDataContainer> GetApplicationDataContainer();
    }
}
