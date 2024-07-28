using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudWEBAPI_CODEFIRTS.Context;
using CrudWEBAPI_CODEFIRTS.Entities;
using CrudWEBAPI_CODEFIRTS.DTO;
using CrudWEBAPI_CODEFIRTS.Services;


namespace CrudWEBAPI_CODEFIRTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesController : ControllerBase
    {
        private readonly PerfilesServices _perfilesServices;

        public PerfilesController(PerfilesServices perfilesServices)
        {
            _perfilesServices = perfilesServices;
        }

        #region GET
        [HttpGet]
        [Route("getperfiles")]
        public async Task<ActionResult<List<PerfilesDTO>>> getPerfiles()
        {
            var perfilesDTO = await _perfilesServices.getPerfiles();
            
            if (perfilesDTO != null)
            {
                return Ok(perfilesDTO);
            }
            return NotFound("Perfiles no encontrados");
        }
        #endregion
    }
}
