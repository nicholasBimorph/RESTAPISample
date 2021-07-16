using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Interfaces;

namespace HB.RestAPI.Core.Settings
{
    public class MongoDbSettings: IDataBaseSettings
    {
        /// <summary>
        /// The connection string to the DB.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// The name of the DB to connect to.
        /// </summary>
        public string DatabaseName { get;}

        /// <summary>
        /// The name of the collection in the data base
        /// </summary>
        public string CollectionName { get; }

        public MongoDbSettings()
        {
            this.DatabaseName = "HBRest";

            this.CollectionName = "DataNodeCollection";


            this.ConnectionString = "mongodb+srv://jackstewart:1234abcd@js1.zytju.mongodb.net/HBRest?retryWrites=true&w=majority";
        }




    }
}
