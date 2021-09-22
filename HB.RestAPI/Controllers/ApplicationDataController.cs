using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.RestAPI.Core;
using HB.RestAPI.Core.Models;
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
    public class ApplicationDataController : ControllerBase
    {
        private readonly IDbCollectionServices _dbCollectionServices;

        /// <summary>
        /// Construct a <see cref="ApplicationDataController"/>.
        /// </summary>
        public ApplicationDataController(IDbCollectionServices dbCollectionServices)
        {
            _dbCollectionServices = dbCollectionServices;
        }

        /// <summary>
        /// and HTTP POST method to add the <paramref name="applicationDataContainer"/> object
        /// in the data base.
        /// </summary>
        /// <param name="applicationDataContainer"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateEntry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(ApplicationDataContainer applicationDataContainer)
        {
           var task = await _dbCollectionServices.Create(applicationDataContainer);

           return this.CreatedAtRoute("CreateEntry", task);

        }

        /// <summary>
        /// Deletes all the  existing <see cref="ProjectStream"/>'s
        /// in the data base.
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpDelete]
        [ActionName("DeleteAllContentInDb")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAllContentInDb()
        {
            var dbCollectionServicesResult = await _dbCollectionServices.DeleteAllEntries();

            return this.StatusCode(200, dbCollectionServicesResult);

        }

    }
}
