using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Services;
using Monilyzer.Data;

namespace Monilyzer.API.Controllers
{
    [Route("api/v1/token")]
    public class ToeknController : Controller
    {
        public ToeknController(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        private MonilyzerContext MonilyzerContext { get; }

        // POST api/v1/token
        [HttpPost]
        public string Post()
        {
            return new TokenService(MonilyzerContext).GetToken("Test", "Test"); 
        }
    }
}
