using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.RestAPI.Core;
using HB.RestAPI.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HB.RestAPI.Controllers
{
    /// <summary>
    /// This class contains all the HTTP requests to interact
    /// with the data base in the cloud.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDbCollectionServices _dbCollectionServices;

        /// <summary>
        /// Construct a <see cref="WeatherForecastController"/>.
        /// </summary>
        public WeatherForecastController(IDbCollectionServices dbCollectionServices)
        {
            _dbCollectionServices = dbCollectionServices;
        }

        /// <summary>
        /// and HTTP POST method to add the <paramref name="weatherForecast"/> object
        /// in the data base.
        /// </summary>
        /// <param name="weatherForecast"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateEntry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(WeatherForecast weatherForecast)
        {
           var task = await _dbCollectionServices.Create(weatherForecast);

           return this.CreatedAtRoute("CreateEntry", task);

        }
       
    }
}
