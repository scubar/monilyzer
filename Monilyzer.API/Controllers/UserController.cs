using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Services;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    /// <summary>
    /// Controller for interacting with User objects.
    /// </summary>
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
            return new UserService(MonilyzerContext).GetUsers(); 
        }

        // GET api/v1/users/<Guid>
        [HttpGet("{guid}")]
        public User Get(Guid guid)
        {
            return new UserService(MonilyzerContext).GetUser(guid);
        }

        // POST api/v1/users
        [HttpPost]
        public User Post([FromBody]User user)
        {
            return new UserService(MonilyzerContext).CreateUser(user); 
        }

        // PUT api/v1/users/<Guid>
        [HttpPut("{guid}")]
        public User Put(Guid guid,[FromBody]User user)
        {
            return new UserService(MonilyzerContext).UpdateUser(guid, user); 
        }

        // DELETE api/v1/users/<Guid>
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            new UserService(MonilyzerContext).DeleteUser(guid); 
        }
    }
}