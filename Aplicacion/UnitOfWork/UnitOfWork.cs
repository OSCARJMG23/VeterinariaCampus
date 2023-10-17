using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiVetContext _context;
        private CitaRepository _citas;
        private EspecieRepository _especies;
        private LaboratorioRepository _laboratorios;
        private MascotaRepository _mascotas;
        private MedicamentoRepository _medicamentos;
        private MovimientoRepository _movimientos;
        private PropietarioRepository _propietarios;
        private ProveedorRepository _proveedores;
        private RazaRepository _razas;
        private TipoMovimientoRepository _tipoMovimientos;
        private TratamientoMedicoRepository _tratamientosMedicos;
        private VeterinarioRepository _veterinarios;
        private IRolRepository _roles;
        private IUserRepository _users;

        public UnitOfWork(ApiVetContext context)
        {
            _context = context;
        }

        public ICitaRepository Citas
        {
            get{
                if (_citas == null)
                {
                    _citas = new CitaRepository(_context);
                }
                return _citas;
            }
        }
        public IEspecieRepository Especies
        {
            get{
                if (_especies == null)
                {
                    _especies = new EspecieRepository(_context);
                }
                return _especies;
            }
        }
        public ILaboratorioRepository Laboratorios
        {
            get{
                if (_laboratorios == null)
                {
                    _laboratorios = new LaboratorioRepository(_context);
                }
                return _laboratorios;
            }
        }
        public IMascotaRepository Mascotas
        {
            get{
                if (_mascotas == null)
                {
                    _mascotas = new MascotaRepository(_context);
                }
                return _mascotas;
            }
        }
        public IMedicamentoRepository Medicamentos
        {
            get{
                if (_medicamentos == null)
                {
                    _medicamentos = new MedicamentoRepository(_context);
                }
                return _medicamentos;
            }
        }
        public IMovimientoRepository Movimientos
        {
            get{
                if (_movimientos == null)
                {
                    _movimientos = new MovimientoRepository(_context);
                }
                return _movimientos;
            }
        }
        public IPropietarioRepository Propietarios
        {
            get{
                if (_propietarios == null)
                {
                    _propietarios = new PropietarioRepository(_context);
                }
                return _propietarios;
            }
        }
        public IProveedorRepository Proveedores
        {
            get{
                if (_proveedores == null)
                {
                    _proveedores = new ProveedorRepository(_context);
                }
                return _proveedores;
            }
        }
        public IRazaRepository Razas
        {
            get{
                if (_razas == null)
                {
                    _razas = new RazaRepository(_context);
                }
                return _razas;
            }
        }
        public ITipoMovimientoRepository TipoMovimientos
        {
            get{
                if (_tipoMovimientos == null)
                {
                    _tipoMovimientos = new TipoMovimientoRepository(_context);
                }
                return _tipoMovimientos;
            }
        }
        public ITratamientoMedicoRepository TratamientosMedicos
        {
            get{
                if (_tratamientosMedicos == null)
                {
                    _tratamientosMedicos = new TratamientoMedicoRepository(_context);
                }
                return _tratamientosMedicos;
            }
        }
        public IVeterinarioRepository Veterinarios
        {
            get{
                if (_veterinarios == null)
                {
                    _veterinarios = new VeterinarioRepository(_context);
                }
                return _veterinarios;
            }
        }
        public IRolRepository Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}