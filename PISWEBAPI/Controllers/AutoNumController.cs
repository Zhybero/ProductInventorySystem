using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PISWEBAPI.FldrClass;

namespace PISWEBAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AutoNumController : ControllerBase
    {

        [HttpGet]
        [Route("v1/product/AutoNumber/ProductAutoNum")]
        public Task<string> ProductAutoNum()
        {
            return new ClsAutoNumber().ProductAutoNum();
        }
         
        [HttpGet]
        [Route("v1/product/AutoNumber/ProductTypeAutoNum")]
        public Task<string> ProductTypeAutoNum()
        {
            return new ClsAutoNumber().ProductTypeAutoNum();
        }
         
    }
}
