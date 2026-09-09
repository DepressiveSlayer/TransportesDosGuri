using Microsoft.AspNetCore.Mvc;

namespace TransportesDosGuri.API.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class CustomControllerBase : Controller
    {
    }
}
