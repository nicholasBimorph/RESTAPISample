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

        string Serialize( IHbObject data);

        T Deserialize<T>(string json);
    }
}
