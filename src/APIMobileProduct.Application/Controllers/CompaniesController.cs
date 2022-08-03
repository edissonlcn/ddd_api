using System;
using System.Net;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Company;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces.Services.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMobileProduct.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private ICompanyService _service;
        public CompaniesController(ICompanyService service)
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
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpGet]
        [Route("{id}", Name = "GetCompanyById")]
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
        public async Task<ActionResult> Post([FromBody] CompanyDtoCreate company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _service.Post(company);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetCompanyById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CompanyDtoUpdate company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(company);
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
