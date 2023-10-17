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
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
    {
        private readonly ApiVetContext _context;
        public MedicamentoRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Medicamentos  as IQueryable<Medicamento>;
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

        public async Task<IEnumerable<Medicamento>> GetMedicamentoLaboratorioGenfar()
        {
            var medicamentoGenfar = await _context.Medicamentos
            .Where(t=>t.Laboratorio.Nombre == "Genfar")
            .ToListAsync();

            return medicamentoGenfar;
        }

        public async Task<IEnumerable<Medicamento>> MedicamentoPrecioMayor50K()
        {
            var medicamento50K = await _context.Medicamentos
            .Where(t=> t.Precio >= 50000)
            .ToListAsync();

            return medicamento50K;
        }
    }
}