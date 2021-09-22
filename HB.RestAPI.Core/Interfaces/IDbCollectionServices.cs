using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HB.RestAPI.Core.Models;

namespace HB.RestAPI.Core
{
    /// <summary>
    /// A contract for all data base collection services.
    /// </summary>
    public interface IDbCollectionServices
    {
        /// <summary>
        /// This method will add the <paramref name="applicationDataContainer"/>
        /// to the Mongo DB, as an async HTTP POST request by the controller.
        /// </summary>
        Task<ApplicationDataContainer> Create(ApplicationDataContainer applicationDataContainer);

        Task<bool> DeleteAllEntries();
    }

}
