using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HB.RestAPI.Core.Models
{
    public class Property
    {
        public string Name { get; set; }

        public object Value { get; set; }

        [JsonConstructor]
        public Property(string name, object value)
        {
            this.Name = name;

            this.Value = value;
        }

        public Property(){}
    }
}
