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
    public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorioRepository
    {
        private readonly ApiVetContext _context;
        public LaboratorioRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Laboratorio> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Laboratorios  as IQueryable<Laboratorio>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Nombre.ToLower().Contains(search) || p.Id.Equals(int.Parse(search)));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query                    
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return (totalRegistros, registros);
        }
    }
}