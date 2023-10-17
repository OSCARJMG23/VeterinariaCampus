using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        ICitaRepository Citas { get; }
        IEspecieRepository Especies { get; }
        ILaboratorioRepository Laboratorios { get; }
        IMascotaRepository Mascotas { get; }
        IMedicamentoRepository Medicamentos { get; }
        IMovimientoRepository Movimientos { get; }
        IPropietarioRepository Propietarios { get; }
        IProveedorRepository Proveedores { get; }
        IRazaRepository Razas { get; }
        ITipoMovimientoRepository TipoMovimientos { get; }
        ITratamientoMedicoRepository TratamientosMedicos { get; }
        IVeterinarioRepository Veterinarios { get; }
        IRolRepository Roles { get; }
        IUserRepository Users { get; }
        

        Task<int> SaveAsync();
    }
}