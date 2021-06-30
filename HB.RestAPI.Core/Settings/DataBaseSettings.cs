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

            //mongodb+srv://<username>:<password>@bimorphcluster.pw37o.mongodb.net/myFirstDatabase?retryWrites=true&w=majority

            this.ConnectionString = "mongodb+srv://nicholasrawitscher:1234@bimorphcluster.pw37o.mongodb.net/HBREST?retryWrites=true&w=majority";
        }

      
    }
}
