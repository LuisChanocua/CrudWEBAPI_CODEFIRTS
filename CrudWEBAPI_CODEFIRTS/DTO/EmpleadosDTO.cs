using CrudWEBAPI_CODEFIRTS.Entities;

namespace CrudWEBAPI_CODEFIRTS.DTO
{
    public class EmpleadosDTO
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public int Sueldo { get; set; }
        public int IdPerfil { get; set; }
        public string? NombrePerfil { get; set; }
    }
}
