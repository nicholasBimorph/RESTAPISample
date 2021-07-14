using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Interfaces;
using HB.RestAPI.Core.Types;

namespace HB.RestAPI.Core.Models
{
    /// <summary>
    /// A class that creates <see cref="IHbObject"/>'s.
    /// </summary>
    public class HbObjectFactory : IHbFactory<IHbObject>
    {
        private readonly ISerializer _serializer;

        /// <summary>
        /// Create a new <see cref="HbObjectFactory"/>.
        /// </summary>
        /// <param name="serializer"></param>
        public HbObjectFactory(ISerializer serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Creates a  <see cref="IHbObject"/>
        /// which is stored in the <paramref name="dataNode"/>.
        /// </summary>
        public IList<IHbObject> Create(IList<DataNode> dataNodes)
        {
            var hbObjects = new List<IHbObject>();

            foreach (var dataNode in dataNodes)
            {
                var storageType = dataNode.GetObjectType();

                string rawData = dataNode.RawData;

                if (storageType == typeof(HbMesh))
                {
                    var hbMesh = _serializer.Deserialize<HbMesh>(rawData);

                    hbObjects.Add(hbMesh);
                }

                throw new NotSupportedException();
            }

            return hbObjects;

        }
    }
}
