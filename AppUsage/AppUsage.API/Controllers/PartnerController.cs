using AppUsage.Application.Contract.Contracts;
using AppUsage.Application.Contract.ViewModels;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web.Http;

namespace AppUsage.API.Controllers
{
    /// <summary>
    /// API to manage Partners
    /// </summary>
    public class PartnerController : ApiController
    {
        // [Dependency]
        private IPartnerApplicationService _partnerService { get; set; }

        public PartnerController() { }

        [InjectionConstructor]
        public PartnerController(IPartnerApplicationService partnerService)
        {
            this._partnerService = partnerService;
        }

        // GET: api/Partner
        /// <summary>
        /// Get a List of Registered Partners
        /// </summary>
        /// <returns><see cref="IEnumerable{PartnerViewModel}"/></returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        public IEnumerable<PartnerViewModel> Get()
        {
            return this._partnerService.Get();
        }

        // GET: api/Partner/5
        /// <summary>
        /// Get a specific Partner Details based on it's Id
        /// </summary>
        /// <param name="id">Id of the partner</param>
        /// <returns><see cref="PartnerViewModel"/></returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        public PartnerViewModel Get(int id)
        {
            return this._partnerService.GetById(id);
        }

        // POST: api/Partner
        [HttpPost]
        public PartnerViewModel Post([FromBody]PartnerViewModel value)
        {
            return this._partnerService.Save(value);
        }

        // PUT: api/Partner/5
        [HttpPut()]
        public IHttpActionResult Put(int id, [FromBody]PartnerViewModel value)
        {
            var partnerFound = this._partnerService.GetById(id);
            if (partnerFound != null && partnerFound == value)
                return Ok(this._partnerService.Save(value));
            else
                return BadRequest("Partner not found!");
        }

        // DELETE: api/Partner/5
        [HttpDelete()]
        public void Delete(int id)
        {
            this._partnerService.Remove(id);
        }
    }
}
