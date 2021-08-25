using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using HB.RestAPI.Core.Interfaces;
using Newtonsoft.Json;

namespace HB.RestAPI.Core.Services
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _serializerSettings;

        private const Formatting Formatting = Newtonsoft.Json.Formatting.Indented;

        /// <summary>
        /// The format type this <see cref="ISerializer"/>
        /// will use.
        /// </summary>
        public string ContentType { get; }

        public JsonSerializer()
        {
            this.ContentType = "application/json";

            _serializerSettings = new JsonSerializerSettings
            {
                //this needs to be enabled for serializing interfaces
                TypeNameHandling = TypeNameHandling.All 
            };
        }


        public string SerializeToServer<T>(T data)
        {
            string serialized = JsonConvert.SerializeObject(data, Formatting);

            return serialized;

            //try
            //{
            //    string serialized = JsonConvert.SerializeObject(data, Formatting);

            //    return serialized;
            //}
            //catch (Exception e)
            //{
            //    throw new SerializationException(e.Message, e.InnerException);
            //}
        }


        public string Serialize(IHbObject data)
        {
            // TODO: Handle serializing exception.

            return JsonConvert.SerializeObject(data, Formatting, _serializerSettings);
        }

        public T Deserialize<T>(string json)
        {
           return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
