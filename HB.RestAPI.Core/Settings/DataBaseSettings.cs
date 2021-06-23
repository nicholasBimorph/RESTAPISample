using System;
using System.ComponentModel;

namespace HB.RestAPI.Core
{
    public class DataBaseSettings : IDataBaseSettings
    {
        
       /// <summary>
       /// The connection string to the DB.
       /// </summary>
       public string ConnectionString { get; set; }

       /// <summary>
        /// The name of the DB to connect to.
        /// </summary>
        public string DatabaseName { get; set; }

       /// <summary>
       /// The name of the collection in the data base
       /// </summary>
        public string CollectionName { get; set; }

        
        public DataBaseSettings()
        {
            this.DatabaseName = "HBREST";

            this.CollectionName = "DataNodeCollection";

            this.ConnectionString = AddingNewEventArgs your connection string!;
        }

      
    }
}
