using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.User;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMobileProduct.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        public UsersController(IUserService service)
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
        [Route("getallUsersbycompanyid", Name = "GetAllUsersByCompanyId")]
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
        [Route("{id}", Name = "GetUserById")]
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
        public async Task<ActionResult> Post([FromBody] UserDtoCreate User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var companyId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(companyId);

                if (User.CompanyId == null || User.CompanyId == Guid.Empty)
                {
                    User.CompanyId = companyGuid;
                }

                var result = await _service.Post(User);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetUserById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDtoUpdate User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var companyId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(companyId);

                if (User.CompanyId == null || User.CompanyId == Guid.Empty)
                {
                    User.CompanyId = companyGuid;
                }
                var result = await _service.Put(User);
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
