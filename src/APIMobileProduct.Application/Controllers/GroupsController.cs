using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Group;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces.Services.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMobileProduct.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private IGroupService _service;
        public GroupsController(IGroupService service)
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

        [HttpGet]
        [Route("getallgroupsbycompanyid", Name = "GetAllGroupsByCompanyId")]
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


        [HttpGet]
        [Route("{id}", Name = "GetGroupById")]
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


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GroupDtoCreate Group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var companyId = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(companyId);

                if (Group.CompanyId == null || Group.CompanyId == Guid.Empty)
                {
                    Group.CompanyId = companyGuid;
                }
                Group.CompanyId = companyGuid;
                var result = await _service.Post(Group);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetGroupById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] GroupDtoUpdate Group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var companyId = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(companyId);

                if (Group.CompanyId == null || Group.CompanyId == Guid.Empty)
                {
                    Group.CompanyId = companyGuid;
                }
                var result = await _service.Put(Group);
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



        [HttpGet]
        [Route("GetAllOfflinemaps", Name = "GetAllOfflinemaps")]
        public async Task<ActionResult> GetAllOfflinemaps(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAllOfflinemaps(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


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
