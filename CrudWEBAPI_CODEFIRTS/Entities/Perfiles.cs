namespace CrudWEBAPI_CODEFIRTS.Entities
{
    public class Perfiles
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Empleados> EmpleadoReferencia { get; set; }
    }
}
