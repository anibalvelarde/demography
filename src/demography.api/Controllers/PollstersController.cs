using demography.api.Models;
using demography.plugins.contracts.Repositories;
using demography.plugins.contracts.Repositories.Pollsters;
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
        private readonly IRepository<PollsterDto> _repository;

        public PollstersController(IRepository<PollsterDto> repo)
        {
            _repository = repo;
        }

        private IRepository<PollsterDto> Repo { get { return _repository; } }


        /// <summary>
        /// HTTP GET ../api/pollsters/
        /// </summary>
        /// <returns>Gets a list of all Pollster resources</returns>
        public IEnumerable<Pollster> Get()
        {
            return MakeListOfRealPollsters();
        }

        private IEnumerable<Pollster> MakeListOfRealPollsters()
        {
            var pollsters = new List<Pollster>();

            foreach (var pollsterData in Repo.GetAll().OrderBy(p => p.Name))
            {
                pollsters.Add(MakeSingleRealPollster(pollsterData));
            }

            return pollsters;
        }

        private static Pollster MakeSingleRealPollster(PollsterDto pollsterData)
        {
            return new Pollster(pollsterData);
        }

        /// <summary>
        /// HTTP GET ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific Pollster resource</returns>
        public Pollster Get(Guid id)
        {
            Pollster p = null;

            foreach (var pollsterData in Repo.GetAll())
            {
                if (pollsterData.Id.Equals(id))
                {
                    p = new Pollster(pollsterData);
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
                var p = Repo.Get(value.Id);
            }
            finally
            {
                var newPollsterData = MakePollsterData(value);
                Repo.Add(newPollsterData);
            }
            return value;
        }

        private PollsterDto MakePollsterData(Pollster value)
        {
            return new PollsterDto() { Id = value.Id, Name = value.Name };
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
                var oldPollster = MakeSingleRealPollster(Repo.Get(id));
                Repo.Delete(oldPollster.Id);
                var newPollster = oldPollster.Update(value);
                Repo.Add(MakePollsterData(newPollster));
                return newPollster;
            }
            finally
            {
                // do nothing
            }
            return MakeSingleRealPollster(Repo.Get(value.Id));
        }

        /// <summary>
        /// HTTP DELETE ..//api/pollsters/{id}/
        /// </summary>
        /// <param name="id">Identifier of the Pollster resource to be deleted</param>
        public string Delete(Guid id)
        {
            if (Repo.Delete(id))
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
