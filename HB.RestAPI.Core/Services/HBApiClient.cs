﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HB.RestAPI.Core.Models;

namespace HB.RestAPI.Core.Services
{
    public class HBApiClient
    {
        /// <summary>
        /// Posts the <paramref name="applicationDataContainer" /> to
        /// the SybSync API web server.
        /// </summary>
        /// <param name="url">
        /// The endpoint request
        /// </param>
        /// <param name="applicationDataContainer"></param>
        /// <returns>
        /// Returns the unique identifier of the <paramref name="applicationDataContainer" />.
        /// Use this Id to fetch the object back when needed.
        /// </returns>
        public async Task<string> AsyncPostRequest(
            string url,
            ApplicationDataContainer applicationDataContainer)
        {
            string serializedData = _serializer.SerializeToServer(applicationDataContainer);

            var request = WebRequest.Create(url);

            request.ContentType = _serializer.ContentType;

            request.Method = "POST";

            var stream = await request.GetRequestStreamAsync();

            using (var streamWriter = new StreamWriter(stream))
            {
                await streamWriter.WriteAsync(serializedData);

                await streamWriter.FlushAsync();
            }

            string responseString = null;

            try
            {
                // Here is where the connection with the SybSync API happens.
                var response = await request.GetResponseAsync();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
              
            }


            return responseString;
        }
    }
}
