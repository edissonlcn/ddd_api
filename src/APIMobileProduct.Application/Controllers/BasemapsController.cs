using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos.Basemap;
using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Interfaces.Services.Basemap;
using APIMobileProduct.Domain.Interfaces.Services.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APIMobileProduct.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasemapsController : ControllerBase
    {
        private IBasemapService _service;
        private ICompanyService _companyService;
        private IConfiguration _configuration;
        public BasemapsController(IBasemapService service, ICompanyService companyService, IConfiguration configuration)
        {
            _service = service;
            _companyService = companyService;
            _configuration = configuration;
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
        [Route("getallBasemapsbycompanyid", Name = "GetAllBasemapsByCompanyId")]
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
        [Route("{id}", Name = "GetBasemapById")]
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
        public async Task<ActionResult> Post([FromForm] BasemapDtoCreate Basemap)
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

                // Creates the uploaded file on the company folder

                if (Basemap.File != null)
                {
                    Basemap.Filename = Basemap.File.FileName;
                    string filePath = Path.Combine(folderDestination, Basemap.File.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Basemap.File.CopyToAsync(fileStream);
                    }
                }


                var company = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(company);

                if (Basemap.CompanyId == null || Basemap.CompanyId == Guid.Empty)
                {
                    Basemap.CompanyId = companyGuid;
                }

                var result = await _service.Post(Basemap);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetBasemapById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromForm] BasemapDtoUpdate Basemap)
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
                if (Basemap.File != null)
                {
                    Basemap.Filename = Basemap.File.FileName;

                    string filePath = Path.Combine(folderDestination, Basemap.File.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Basemap.File.CopyToAsync(fileStream);
                    }
                }
                var company = User.Claims.FirstOrDefault(claim => claim.Type == "sid")?.Value;
                Guid companyGuid = Guid.Parse(company);

                if (Basemap.CompanyId == null || Basemap.CompanyId == Guid.Empty)
                {
                    Basemap.CompanyId = companyGuid;
                }
                var result = await _service.Put(Basemap);
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
