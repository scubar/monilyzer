using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Monilyzer.API.Services;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    [Route("api/v1/token")]
    public class TokenController : Controller
    {
        public TokenController(MonilyzerContext monilyzerContext, IConfiguration configuration)
        {
            MonilyzerContext = monilyzerContext;
            Configuration = configuration;

        }

        private MonilyzerContext MonilyzerContext { get; }

        private IConfiguration Configuration { get; }

        // POST api/v1/token
        [HttpPost]
        public string Post([FromBody]UsernamePassword usernamePassword)
        {
            return new TokenService(MonilyzerContext,Configuration).GetToken(usernamePassword); 
        }
    }
}
