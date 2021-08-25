using System;
using System.Collections.Generic;
using System.Text;

namespace HB.RestAPI.Core.Interfaces
{
    public interface ISerializer
    {
        /// <summary>
        /// The format type this <see cref="ISerializer"/>
        /// will use.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Serializes the given <paramref name="data" />
        /// to the server.
        /// </summary>
        string SerializeToServer<T>(T data);

        string Serialize( IHbObject data);

        T Deserialize<T>(string json);
    }
}
