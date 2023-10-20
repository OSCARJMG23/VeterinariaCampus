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
    public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {
        private readonly ApiVetContext _context;
        public MovimientoRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Movimiento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Movimientos  as IQueryable<Movimiento>;
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Id.Equals(int.Parse(search)));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query   
                                    .Include(t=>t.TipoMovimiento)                 
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return (totalRegistros, registros);
        }

        public async Task<IEnumerable<object>> GetMovimientosYvalorTotalXmovimiento()
        {
            var movimientos = await _context.Movimientos
            .Include(m=>m.MovimientosMedicamentos)
            .ThenInclude(m=>m.Medicamento)
            .ToListAsync();

            var resultado = movimientos.Select(m => new
            {
                MovimientoId = m.Id,
                CantidadM = m.Cantidad,
                PrecioM = m.Precio,
                ValorTotal = m.Cantidad * m.Precio,
                Medicamento = m.MovimientosMedicamentos.Select(m=>m.Medicamento.Nombre)
            });

            return resultado;
        }
    }
}