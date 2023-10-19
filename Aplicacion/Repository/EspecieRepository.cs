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
    public class EspecieRepository : GenericRepository<Especie>, IEspecieRepository
    {
        private readonly ApiVetContext _context;
        public EspecieRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Especie> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Especies  as IQueryable<Especie>;
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
       /*  public async Task<IEnumerable<Especie>> GetNormally()
        {
            var especie = await _context.Especies
            .ToListAsync();
            return especie;
        } */
    }
}