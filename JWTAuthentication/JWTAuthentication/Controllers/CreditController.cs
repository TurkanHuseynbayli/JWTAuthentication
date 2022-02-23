using JWTAuthentication.Interfaces;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly IMounthPrice mounthPrice;
        public CreditController(IMounthPrice mounthPrice)
        {
            this.mounthPrice = mounthPrice;
        }

        [HttpPost("Test")]
        public IActionResult Test(string jsonContent)
        {
            return Ok(jsonContent);
        }
       

        [HttpPost("CreditReport")]
        public IActionResult CreditReport([FromBody]Credit credit)
        {
            Response response = new Response();

            if (credit.Money <= 0 || credit.Mounth <= 0 || credit.Percent <= 0)
            {
                response.Status = "Error";
                response.Message = "Please enter valid value!";
                return BadRequest(response);
            }

            response.Status = "Success";
            response.Message = mounthPrice.CalculateData(credit).ToString();


            return Ok(response);
        }

        [HttpGet("GetSome")]
        [Authorize(Roles =UserRoles.Admin)]
        public IActionResult GetData()
        {
           return Ok("432432");
        }
    }
}
