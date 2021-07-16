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
        
    }
}
