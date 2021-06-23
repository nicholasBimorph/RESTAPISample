using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HB.RestAPI.Core
{
    /// <summary>
    /// A contract for all data base collection services.
    /// </summary>
    public interface IDbCollectionServices
    {
        /// <summary>
        /// This method will add the <paramref name="weatherForecast"/>
        /// to the Mongo DB, as an async HTTP POST request by the controller.
        /// </summary>
        Task<WeatherForecast> Create(WeatherForecast weatherForecast);
    }
}
