using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Event;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces.Services.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMobileProduct.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventAliasController : ControllerBase
    {
        private IEventAliasService _service;
        public EventAliasController(IEventAliasService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                var companyId = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(companyId);
                return Ok(await _service.GetAll(companyGuid));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetEventAliasById")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("getallEventAliasbycompanyid", Name = "GetAllEventAliasByCompanyId")]
        public async Task<ActionResult> GetAllByCompanyId(Guid companyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                return Ok(await _service.GetAllByCompanyId(companyId));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventAliasDtoCreate EventAlias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var company = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(company);

                if (EventAlias.CompanyId == null || EventAlias.CompanyId == Guid.Empty)
                {
                    EventAlias.CompanyId = companyGuid;
                }


                var result = await _service.Post(EventAlias);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetEventAliasById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EventAliasDtoUpdate EventAlias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var company = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(company);

                if (EventAlias.CompanyId == null || EventAlias.CompanyId == Guid.Empty)
                {
                    EventAlias.CompanyId = companyGuid;
                }
                var result = await _service.Put(EventAlias);
                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

    }
}
