using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Models;

namespace HB.RestAPI.Core.Interfaces
{
    public interface IHbFactory<T>
    {

        /// <summary>
        /// Creates a  <see cref="IHbObject"/>
        /// which is stored in the <paramref name="dataNode"/>.
        /// </summary>
        IList<T> Create(IList<DataNode> dataNode);
    }
}
