using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Softplan.TaxaJuros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMetheCodeController : Controller
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> ShowMeCode()
        {
            return Ok(new ShowCodeModel());
        }
    }
}