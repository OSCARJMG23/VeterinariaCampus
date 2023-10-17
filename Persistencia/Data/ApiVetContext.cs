using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class ApiVetContext : DbContext
    {
        public ApiVetContext(DbContextOptions<ApiVetContext> options) : base(options)
        {
        }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MedicamentoProveedor> MedicamentosProveedores { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<TratamientoMedico> TratamientosMedicos { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UsersRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}