using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Services;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    /// <summary>
    /// Controller for interacting with Node objects.
    /// </summary>
    [Authorize]
    [Route("api/v1/nodes")]
    public class NodeController : Controller
    {
        public NodeController(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        MonilyzerContext MonilyzerContext { get; set; }

        // GET api/v1/nodes
        [HttpGet]
        public IEnumerable<Node> Get()
        {
            return new NodeService(MonilyzerContext).GetNodes(); 
        }

        // GET api/v1/nodes/<Guid>
        [HttpGet("{guid}")]
        public Node Get(Guid guid)
        {
            return new NodeService(MonilyzerContext).GetNode(guid);
        }

        // POST api/v1/nodes
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Node Post([FromBody]Node node)
        {
            return new NodeService(MonilyzerContext).CreateNode(node); 
        }

        // PUT api/v1/nodes/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpPut("{guid}")]
        public Node Put(Guid guid,[FromBody]Node node)
        {
            return new NodeService(MonilyzerContext).UpdateNode(guid, node); 
        }

        // DELETE api/v1/nodes/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            new NodeService(MonilyzerContext).DeleteNode(guid); 
        }
    }
}