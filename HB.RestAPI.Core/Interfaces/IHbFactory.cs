using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Models;

namespace HB.RestAPI.Core.Interfaces
{
    public interface IHbFactory
    {
        /// <summary>
        /// Creates a  <see cref="IHbObject"/>
        /// which is stored in the <paramref name="dataNode"/>.
        /// </summary>
        IList<IHbObject> Create(IList<DataNode> dataNode);
    }
}
