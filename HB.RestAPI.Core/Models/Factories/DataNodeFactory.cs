using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Interfaces;

namespace HB.RestAPI.Core.Models.Factories
{
    /// <summary>
    /// A class which encapsulates the
    /// creation of <see cref="DataNode" />'s.
    /// </summary>
    public class DataNodeFactory
    {
        private readonly ISerializer _serializer;

        /// <summary>
        /// Construct a <see cref="DataNodeFactory" />.
        /// </summary>
        public DataNodeFactory(ISerializer serializer) => _serializer = serializer;
       
        /// <summary>
        /// Creates a <see cref="DataNode" /> from an
        /// <see cref="EntityObject" />.
        /// </summary>
        public DataNode Create(IHbObject entity)
        {
            string jsonEntity = _serializer.Serialize(entity);

            return new DataNode(jsonEntity, entity.GetType());
        }
    }
}
