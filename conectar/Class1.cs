using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
using tablas_atributos;
using subclases;
using System.Diagnostics.Metrics;
namespace conexionaSQL
{
    //Update-Database
    //Add-Migration
    //Add-Migration Inicial -Project conectar -StartupProject mainProyecto
    //Update-Database -Project conectar -StartupProject mainProyecto

    public class TablaDbContent : DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rutas> Rutas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<viaje> Viajes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6NJP2S7\\SQLEXPRESS;Database=ProyectoCarro;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>().ToTable("VEHICULOS");

            //Meter implicitamemte las herecnias
            modelBuilder.Entity<VehiculoLiguero>().HasBaseType<Vehiculo>();
            modelBuilder.Entity<VehiculoPesado>().HasBaseType<Vehiculo>();


            modelBuilder.Entity<Empleado>().ToTable("EMPLEADOS");
            //Meter implicitamemte las herecnias

            modelBuilder.Entity<Conductor>().HasBaseType<Empleado>();
            modelBuilder.Entity<Mecanico>().HasBaseType<Empleado>();


            modelBuilder.Entity<Rutas>().ToTable("RUTAS");
            modelBuilder.Entity<Producto>().ToTable("PRODUCTOS");
            modelBuilder.Entity<viaje>().ToTable("VIAJES");
        }
    }
}
