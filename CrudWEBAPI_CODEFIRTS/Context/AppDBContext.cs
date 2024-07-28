using CrudWEBAPI_CODEFIRTS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CrudWEBAPI_CODEFIRTS.Context
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        //Tablas de la BD
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Perfiles>(p =>
            {
                p.HasKey(col => col.IdPerfil);
                p.Property(col => col.IdPerfil).UseIdentityColumn().ValueGeneratedOnAdd();
                p.Property(col => col.Nombre).HasMaxLength(50);
                p.HasData(
                    new Perfiles { IdPerfil = 1, Nombre = "Dev jr" },
                    new Perfiles { IdPerfil = 2, Nombre = "Dev sr" },
                    new Perfiles { IdPerfil = 3, Nombre = "Dev tr" }
                    );
            });

            modelBuilder.Entity<Empleados>(p =>
            {
                p.HasKey(col => col.IdEmpleado);
                p.Property(col => col.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();
                p.Property(col => col.Nombre).HasMaxLength(50);
                p.HasOne(col => col.PerfilReferencia).WithMany(p => p.EmpleadoReferencia).
                HasForeignKey(col => col.IdPerfil);
            });
        }
    }
}
