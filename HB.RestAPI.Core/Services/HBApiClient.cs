using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HB.RestAPI.Core.Interfaces;
using HB.RestAPI.Core.Models;

namespace HB.RestAPI.Core.Services
{
    public class HBApiClient
    {
        public event EventHandler<string> RequestFinished;

        private readonly ISerializer _serializer;

        public HBApiClient(ISerializer serializer)
        {
            _serializer = serializer;
        }

        private void OnRequestFinished(string response)
        {
            var handler = this.RequestFinished;

            handler?.Invoke(this, response);
        }

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
        public async Task<string> AsyncPostRequest(string url, ApplicationDataContainer applicationDataContainer)
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
                this.OnRequestFinished(responseString);
            }



            this.OnRequestFinished(responseString);

            return responseString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">
        /// The Url endpoint to perform the request to
        /// </param>
        public async Task<string> GetRequest(string url)
        {
            var request = WebRequest.Create(url);

            request.ContentType = _serializer.ContentType;

            request.Method = "GET";

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

                this.OnRequestFinished(responseString);
            }

            this.OnRequestFinished(responseString);

            return responseString;
        }


    }
}
