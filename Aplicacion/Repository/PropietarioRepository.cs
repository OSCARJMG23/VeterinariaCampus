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
    public class PropietarioRepository : GenericRepository<Propietario>, IPropietarioRepository
    {
        private readonly ApiVetContext _context;
        public PropietarioRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Propietarios  as IQueryable<Propietario>;
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
        
        public async Task<IEnumerable<Propietario>> GetPropietariosWhitMascotas()
        {
            var propietariosWhitMascotas = await _context.Propietarios
                /* .Include(t=>t.Mascotas) */
                .ToListAsync();
            return propietariosWhitMascotas;
        }
    }
}