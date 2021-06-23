using System;
using System.Collections.Generic;
using System.Text;

namespace HB.RestAPI.Core
{
    public interface IDataBaseSettings
    {
        /// <summary>
        /// The connection string to the DB.
        /// </summary>
        string  ConnectionString { get; set; }

        /// <summary>
        /// The name of the DB to connect to.
        /// </summary>
        string DatabaseName { get; set; }

        /// <summary>
        /// The name of the collection in the data base
        /// </summary>
        string CollectionName { get; set; }
    }
}
