using System;
using System.Collections.Generic;
using System.Text;

namespace HB.RestAPI.Core.Settings
{
    /// <summary>
    /// Contains all the endpoints needed to make requests
    /// to the HB web server.
    /// </summary>
    public class HbApiEndPoints
    {

        public const string AsyncPostEndPoint = "https://localhost:44313/ApplicationData";

        public const string GetLatestEndPoint = "https://localhost:44313/ApplicationData/GetLatest";
    }
}
