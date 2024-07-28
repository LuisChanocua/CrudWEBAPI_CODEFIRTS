﻿// <auto-generated />
using CrudWEBAPI_CODEFIRTS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudWEBAPI_CODEFIRTS.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudWEBAPI_CODEFIRTS.Entities.Empleados", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sueldo")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("CrudWEBAPI_CODEFIRTS.Entities.Perfiles", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerfil"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfiles");

                    b.HasData(
                        new
                        {
                            IdPerfil = 1,
                            Nombre = "Dev jr"
                        },
                        new
                        {
                            IdPerfil = 2,
                            Nombre = "Dev sr"
                        },
                        new
                        {
                            IdPerfil = 3,
                            Nombre = "Dev tr"
                        });
                });

            modelBuilder.Entity("CrudWEBAPI_CODEFIRTS.Entities.Empleados", b =>
                {
                    b.HasOne("CrudWEBAPI_CODEFIRTS.Entities.Perfiles", "PerfilReferencia")
                        .WithMany("EmpleadoReferencia")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilReferencia");
                });

            modelBuilder.Entity("CrudWEBAPI_CODEFIRTS.Entities.Perfiles", b =>
                {
                    b.Navigation("EmpleadoReferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
