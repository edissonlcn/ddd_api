using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Offlinemap;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces.Services.Offlinemap;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APIMobileProduct.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OfflinemapsController : ControllerBase
    {
        private IOfflinemapService _service;
        private IConfiguration _configuration;
        public OfflinemapsController(IOfflinemapService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [Authorize("Bearer")]
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
        [Route("GetPending", Name = "GetPendingById")]
        public async Task<ActionResult> GetPending()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                return Ok(await _service.GetPending());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("GetPending/{id}", Name = "GetPending")]
        public async Task<ActionResult> GetPending(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            try
            {
                return Ok(await _service.GetPendingById(id));
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("getallOfflinemapsbycompanyid", Name = "GetAllOfflinemapsByCompanyId")]
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
        [HttpGet]
        [Route("{id}", Name = "GetOfflinemapById")]
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

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] OfflinemapDtoCreate Offlinemap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var folderDestination = _configuration.GetSection("UploadFolder").Value;
                if (!Directory.Exists(folderDestination))
                    Directory.CreateDirectory(folderDestination);
                if (Offlinemap.File != null)
                {
                    Offlinemap.Filename = Offlinemap.File.FileName;

                    string filePath = Path.Combine(folderDestination, Offlinemap.File.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Offlinemap.File.CopyToAsync(fileStream);
                    }
                }
                var company = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(company);
                if (Offlinemap.CompanyId == null || Offlinemap.CompanyId == Guid.Empty)
                {
                    Offlinemap.CompanyId = companyGuid;
                }
                var result = await _service.Post(Offlinemap);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetOfflinemapById", new { id = result.Id })), result);
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

        public async Task<ActionResult> Put([FromForm] OfflinemapDtoUpdate Offlinemap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var folderDestination = _configuration.GetSection("UploadFolder").Value;
                if (!Directory.Exists(folderDestination))
                    Directory.CreateDirectory(folderDestination);
                if (Offlinemap.File != null)
                {
                    Offlinemap.Filename = Offlinemap.File.FileName;

                    string filePath = Path.Combine(folderDestination, Offlinemap.File.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Offlinemap.File.CopyToAsync(fileStream);
                    }
                }
                var company = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(company);
                if (Offlinemap.CompanyId == null || Offlinemap.CompanyId == Guid.Empty)
                {
                    Offlinemap.CompanyId = companyGuid;
                }
                var result = await _service.Put(Offlinemap);
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
        [HttpPut]
        [Route("PutCoords", Name = "PutCoords")]
        public async Task<ActionResult> PutCoords([FromForm] OfflinemapDtoUpdateCoords Offlinemap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var folderDestination = _configuration.GetSection("UploadFolder").Value;
                if (!Directory.Exists(folderDestination))
                    Directory.CreateDirectory(folderDestination);
                if (Offlinemap.File != null)
                {
                    string filePath = Path.Combine(folderDestination, Offlinemap.File.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Offlinemap.File.CopyToAsync(fileStream);
                    }
                }
                var result = await _service.PutCoords(Offlinemap);
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
