using CrudWEBAPI_CODEFIRTS.Context;
using CrudWEBAPI_CODEFIRTS.DTO;
using Microsoft.EntityFrameworkCore;

namespace CrudWEBAPI_CODEFIRTS.Services
{
    public class PerfilesServices
    {
        private readonly AppDBContext _dbContext;
        public PerfilesServices(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        
        //Obtener perfiles
        public async Task<List<PerfilesDTO>> getPerfiles()
        {
            var perfilesDTO = new List<PerfilesDTO>();
            var perfilesData = await _dbContext.Perfiles.ToListAsync();

            foreach (var item in perfilesData)
            {
                perfilesDTO.Add(new PerfilesDTO
                {
                    IdPerfil = item.IdPerfil,
                    Nombre = item.Nombre
                });
            }
            return (perfilesDTO);
        }
    }
}
