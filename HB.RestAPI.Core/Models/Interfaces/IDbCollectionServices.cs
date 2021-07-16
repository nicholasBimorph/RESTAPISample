using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HB.RestAPI.Core.Data;

namespace HB.RestAPI.Core.Interfaces
{
    /// <summary>
    /// A contract for all data base collection services.
    /// This <see cref="IDbCollectionServices"/> will be used by
    /// a controller.
    /// </summary>
    public interface IDbCollectionServices
    {
        /// <summary>
        /// This method will add the <paramref name="applicationDataContainer"/>
        /// to the Mongo DB, as an async HTTP POST request by the controller.
        /// </summary>
        Task<ApplicationDataContainer> Create(ApplicationDataContainer applicationDataContainer);
    }
}
