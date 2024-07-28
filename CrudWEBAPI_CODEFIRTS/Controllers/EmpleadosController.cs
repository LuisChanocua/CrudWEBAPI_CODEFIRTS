using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudWEBAPI_CODEFIRTS.Context;
using CrudWEBAPI_CODEFIRTS.Entities;
using CrudWEBAPI_CODEFIRTS.DTO;

namespace CrudWEBAPI_CODEFIRTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public EmpleadosController(AppDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        #region GET
        [HttpGet]
        [Route("getempleados")]
        public async Task<ActionResult<List<EmpleadosDTO>>> getEmpleados()
        {
            try
            {
                var empleadosDTO = new List<EmpleadosDTO>();
                var empleadosData = await _dbContext.Empleados.Include(p => p.PerfilReferencia).ToListAsync();

                foreach (var item in empleadosData)
                {
                    empleadosDTO.Add(new EmpleadosDTO
                    {
                        IdEmpleado = item.IdEmpleado,
                        Nombre = item.Nombre,
                        Sueldo = item.Sueldo,
                        IdPerfil = item.IdPerfil,
                        NombrePerfil = item.PerfilReferencia.Nombre,
                    });
                }
                return Ok(empleadosDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getempleado/{IdEmpleado}")]
        public async Task<ActionResult<List<EmpleadosDTO>>> getEmpleado(int IdEmpleado)
        {
            try
            {
                var empleadoDTO = new List<EmpleadosDTO>();
                var empleadoData = await _dbContext.Empleados.Include(p => p.PerfilReferencia).Where(x => x.IdEmpleado == IdEmpleado).FirstOrDefaultAsync();

                if (empleadoData != null)
                {
                    empleadoDTO.Add(new EmpleadosDTO
                    {
                        IdEmpleado = empleadoData.IdEmpleado,
                        Nombre = empleadoData.Nombre,
                        Sueldo = empleadoData.Sueldo,
                        IdPerfil = empleadoData.IdPerfil,
                        NombrePerfil = empleadoData.PerfilReferencia.Nombre,
                    });
                    return Ok(empleadoDTO);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion

        #region POST

        [HttpPost]
        [Route("addempleado")]
        public async Task<ActionResult<EmpleadosDTO>> addEmpleado(EmpleadosDTO empleadoDTO)
        {
            try
            {
                var empleado = new Empleados
                {
                    Nombre = empleadoDTO.Nombre,
                    Sueldo = empleadoDTO.Sueldo,
                    IdPerfil = empleadoDTO.IdPerfil,
                };

                await _dbContext.Empleados.AddAsync(empleado);
                await _dbContext.SaveChangesAsync();
                return Ok("Empleado Agregado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region PUT
        [HttpPut]
        [Route("updateempleado")]
        public async Task<ActionResult<EmpleadosDTO>> updateEmpleado(EmpleadosDTO empleadoDTO)
        {
            try
            {
                var empleadoData = await _dbContext.Empleados.Include(p => p.PerfilReferencia).Where(x => x.IdEmpleado == empleadoDTO.IdEmpleado).FirstOrDefaultAsync();

                if (empleadoData != null)
                {

                    empleadoData.Nombre = empleadoDTO.Nombre;
                    empleadoData.Sueldo = empleadoDTO.Sueldo;
                    empleadoData.IdPerfil = empleadoDTO.IdPerfil;


                    _dbContext.Empleados.Update(empleadoData);
                    await _dbContext.SaveChangesAsync();

                    return Ok("Empleado actualizado");
                }
                else
                {
                    return NotFound("Empleado no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region DELETE
        [HttpDelete]
        [Route("deleteempleado/{IdEmpleado}")]
        public async Task<ActionResult> deleteEmpleado(int IdEmpleado)
        {
            try
            {
                var empleadoData = await _dbContext.Empleados.FindAsync(IdEmpleado);

                if (empleadoData != null)
                {
                    _dbContext.Empleados.Remove(empleadoData);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Empleado eliminado");
                }
                else
                {
                    return NotFound("Empleado no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Empleado no eliminado: {ex.Message}");
            }
        }
        #endregion
    }
}
