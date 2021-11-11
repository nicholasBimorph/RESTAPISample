using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Interfaces;
using Newtonsoft.Json;

namespace HB.RestAPI.Core.Models.Types
{
    public class HbArea : IHbObject
    {
        
        public IList<Property> Properties { get; }

        /// <summary>
        /// The total area in sq mm of this <see cref="HbArea"/>.
        /// </summary>
        public double Area { get; set; }

        [JsonConstructor]
        public HbArea(double area, IList<Property> properties = null)
        {
             this.Area = area;

             this.Properties = properties ?? new List<Property>();
        }

        /// <summary>
        /// WARNING: DO NOT REMOVE NEEDED FOR JSON
        /// </summary>
        public HbArea(){}
     



    }
}
