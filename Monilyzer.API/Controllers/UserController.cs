using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Data;
using Monilyzer.API.HostedServices;
using Monilyzer.API.Services;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    /// <summary>
    /// Controller for interacting with User objects.
    /// </summary>
    [Authorize]
    [Route("api/v1/users")]
    public class UserController : Controller
    {
        public UserController(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        MonilyzerContext MonilyzerContext { get; set; }

        // GET api/v1/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new UserRepository(MonilyzerContext).GetUsers(); 
        }

        // GET api/v1/users/<Guid>
        [HttpGet("{guid}")]
        public User Get(Guid guid)
        {
            return new UserRepository(MonilyzerContext).GetUser(guid);
        }

        // POST api/v1/users
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public User Post([FromBody]User user)
        {
            return new UserRepository(MonilyzerContext).CreateUser(user); 
        }

        // PUT api/v1/users/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpPut("{guid}")]
        public User Put(Guid guid,[FromBody]User user)
        {
            return new UserRepository(MonilyzerContext).UpdateUser(guid, user); 
        }

        // DELETE api/v1/users/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            new UserRepository(MonilyzerContext).DeleteUser(guid); 
        }
    }
}