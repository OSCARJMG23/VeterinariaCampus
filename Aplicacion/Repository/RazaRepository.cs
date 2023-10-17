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
    public class RazaRepository : GenericRepository<Raza>, IRazaRepository
    {
        private readonly ApiVetContext _context;
        public RazaRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Razas  as IQueryable<Raza>;
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
        
        public async Task<IEnumerable<object>> GetCantidadMascotaXraza()
        {
            var mascotasXraza = await _context.Razas
                .Select(r=> new
                {
                    Raza = r.Nombre,
                    CantidadMascotas = r.Mascotas.Count
                })
                .ToListAsync();

            return mascotasXraza;
        }
    }
}