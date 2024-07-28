namespace CrudWEBAPI_CODEFIRTS.Entities
{
    public class Empleados
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public int Sueldo { get; set; }
        public int IdPerfil { get; set; }

        public virtual Perfiles PerfilReferencia{ get; set; }
    }
}
