using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Services;
using HB.RestAPI.Core.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HB.RestAPI.Core.Models
{
    public class ApplicationDataContainer
    {
        /// <summary>
        /// The unique Id assigned to this <see cref="ApplicationDataContainer"/>
        /// by Mongo DB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DbId { get; set; }

        public string ProjectStream { get; set; }

        /// <summary>
        /// The collected data from an applciation.
        /// </summary>
        public IList<DataNode> ApplicationData { get; set; }

        // TODO: DateTime

        [BsonConstructor]
        public ApplicationDataContainer(IList<DataNode> applicationData, string projectStream)
        {
            this.ApplicationData = applicationData;

            this.ProjectStream = projectStream;


        }

        public ApplicationDataContainer(){}
    }
}
