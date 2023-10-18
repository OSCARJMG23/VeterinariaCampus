using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
    {
        private readonly ApiVetContext _context;
        public ProveedorRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Proveedores  as IQueryable<Proveedor>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Nombre.ToLower().Contains(search));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                    /* .Include(u =>u.Proveedor) */
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return (totalRegistros, registros);
        }

        public async Task<IEnumerable<Proveedor>> GetProveedoresXmedicamento(string medicamentoConsulta)
        {
            var proveedoresXMedicamento = await _context.Proveedores
            .Where(t=>t.MedicamentosProveedores
                .Any(t=>t.Medicamento.Nombre == medicamentoConsulta))
                .Include(t=>t.Medicamentos)
                .ToListAsync();

            return proveedoresXMedicamento;
        }
    }
}