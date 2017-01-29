using demography.api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace demography.api.Controllers
{
    /// <summary>
    /// Handles REST Api Polster Resource
    /// </summary>
    public class PollstersController : ApiController
    {
        /// <summary>
        /// HTTP GET ../api/pollsters/
        /// </summary>
        /// <returns>Gets a list of all Pollster resources</returns>
        public IEnumerable<Pollster> Get()
        {
            return PollsterMockData.Instance.GetAllPollsters().OrderBy(p => p.Name);
        }

        /// <summary>
        /// HTTP GET ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific Pollster resource</returns>
        public Pollster Get(Guid id)
        {
            Pollster p = null;

            foreach (var pollster in PollsterMockData.Instance.GetAllPollsters())
            {
                if (pollster.Id.Equals(id))
                {
                    p = pollster;
                }
            }

            return p;
        }

        /// <summary>
        /// HTTP POST ..//api/pollsters/
        /// </summary>
        /// <param name="value">Adds a Pollster resource</param>
        public Pollster Post([FromBody] Pollster value)
        {
            try
            {
                var p = PollsterMockData.Instance.GetPollster(value.Id);
            }
            finally
            {
                PollsterMockData.Instance.AddPollster(value);                
            }
            return value;
        }
        /// <summary>
        /// HTTP PUT ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id">Identifier for a Pollster resource</param>
        /// <param name="value">Pollster data to update</param>
        public Pollster Put(Guid id, [FromBody] Pollster value)
        {
            try
            {
                var oldPollster = PollsterMockData.Instance.GetPollster(id);
                PollsterMockData.Instance.DeletePollster(oldPollster.Id);
                var newPollster = oldPollster.Update(value);
                PollsterMockData.Instance.AddPollster(newPollster);
                return newPollster;
            }
            finally
            {
                // do nothing
            }
            return PollsterMockData.Instance.GetPollster(value.Id);
        }

        /// <summary>
        /// HTTP DELETE ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id">Identifier of the Pollster resource to be deleted</param>
        public string Delete(Guid id)
        {
            if (PollsterMockData.Instance.DeletePollster(id))
            {
                return $"Deleted Id:[{id.ToString()}]";
            }
            else
            {
                return $"Id:[{id.ToString()}] was not found.";
            }
        }
    }
}
