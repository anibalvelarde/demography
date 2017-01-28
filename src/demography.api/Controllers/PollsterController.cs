using demography.api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace demography.api.Controllers
{
    /// <summary>
    /// Handles REST Api Polster Resource
    /// </summary>
    public class PollsterController : ApiController
    {
        /// <summary>
        /// HTTP GET ../api/pollsters/
        /// </summary>
        /// <returns>Gets a list of all Pollster resources</returns>
        public IEnumerable<Pollster> Get()
        {
            return PollsterMockData.Instance.GetAllPollsters();
        }

        /// <summary>
        /// HTTP GET ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific Pollster resource</returns>
        public string Get(Guid id)
        {
            return "value";
        }

        /// <summary>
        /// HTTP POST ..//api/pollsters/
        /// </summary>
        /// <param name="value">Adds a Pollster resource</param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// HTTP PUT ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id">Identifier for a Pollster resource</param>
        /// <param name="value">Pollster data to update</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// HTTP DELETE ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id">Identifier of the Pollster resource to be deleted</param>
        public void Delete(int id)
        {
        }
    }
}
