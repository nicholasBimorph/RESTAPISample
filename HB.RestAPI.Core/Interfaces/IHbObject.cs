using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Models;

namespace HB.RestAPI.Core.Interfaces
{
    public interface IHbObject
    {
        IList<Property> Properties { get; }
    }
}
