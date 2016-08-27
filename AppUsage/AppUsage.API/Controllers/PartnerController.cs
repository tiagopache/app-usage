using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppUsage.Application.Contract.Contracts;
using AppUsage.Application.Contract.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AppUsage.API.Controllers
{
    [Route("api/[controller]")]
    public class PartnerController : Controller
    {
        private IPartnerApplicationService _partnerService;

        public PartnerController(IPartnerApplicationService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<PartnerViewModel> Get()
        {
            return this._partnerService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PartnerViewModel Get(int id)
        {
            return this._partnerService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public PartnerViewModel Post([FromBody]PartnerViewModel value)
        {
            return this._partnerService.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PartnerViewModel value)
        {
            var partnerFound = this._partnerService.GetById(id);
            if (partnerFound != null && partnerFound == value)
                return Ok(this._partnerService.Save(value));
            else
                return BadRequest(new { msg = "Partner not found!" });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._partnerService.Remove(id);
        }
    }
}
