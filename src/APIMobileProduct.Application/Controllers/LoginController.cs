using System;
using System.Net;
using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos;
using APIMobileProduct.Domain.Interfaces.Services.Company;
using Microsoft.AspNetCore.Mvc;

namespace APIMobileProduct.Application.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida
            }

            if (loginDto == null)
            {
                return BadRequest(); //400 bad request - solicitação invalida
            }

            try
            {
                var result = await service.FindByLogin(loginDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
