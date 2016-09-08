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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
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
        /// Get a list of registered partners
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
        /// Get a specific partner details based on Id
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
        /// <summary>
        /// Add a new partner
        /// </summary>
        /// <param name="value"><see cref="PartnerViewModel"/> Partner details to add</param>
        /// <returns><see cref="PartnerViewModel"/> Partner details which was added</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public IHttpActionResult Post([FromBody]PartnerViewModel value)
        {
            var partner = this._partnerService.Save(value);

            return Created<PartnerViewModel>($"/api/partner/{partner.Id}", partner);
        }

        // PUT: api/Partner/5
        /// <summary>
        /// Update a partner by Id
        /// </summary>
        /// <param name="id">Id of Partner to update</param>
        /// <param name="value"><see cref="PartnerViewModel"/> Partner details to update</param>
        /// <returns><see cref="PartnerViewModel"/> Partner details updated</returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]PartnerViewModel value)
        {
            if (id != value.Id)
                return BadRequest("Id sent don't match with Partner details Id");

            var partnerFound = this._partnerService.GetById(id);

            if (partnerFound != null && (partnerFound.Id == value.Id))
                return Ok(this._partnerService.Save(value));
            else
                return BadRequest("Partner not found!");
        }

        // DELETE: api/Partner/5
        /// <summary>
        /// Delete a partner by Id
        /// </summary>
        /// <param name="id">Id of Partner to delete</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        public void Delete(int id)
        {
            this._partnerService.Remove(id);
        }
    }
}
