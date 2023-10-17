using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
    {
        private readonly ApiVetContext _context;
        public MascotaRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Mascotas  as IQueryable<Mascota>;
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

        public async Task<IEnumerable<Mascota>> GetMascotasFelinas()
        {
            var mascotaFelina = await _context.Mascotas
            .Where(t=> t.Raza.Especie.Nombre == "Felina")
            .ToListAsync();

            return mascotaFelina;
        }

        public async Task<IEnumerable<Mascota>> MascotaCitaXvacunacion2023()
        {
            var primerTrimestreInicio = new DateTime(2023, 1, 1);
            var primerTrimestreFin = new DateTime(2023, 3, 31);

            var mascotaVacuna = await _context.Citas
            .Where(t=>t.Motivo == "Vacunacion" &&
                    t.Fecha >= primerTrimestreInicio &&
                    t.Fecha <= primerTrimestreFin)
            .Select(t=>t.Mascota)
            .Distinct()
            .ToListAsync();

            return mascotaVacuna;
        }

        public async Task<IEnumerable<object>> GetMascotasAgrupadasXespecie()
        {
            var mascotasXespecie = await _context.Mascotas
            .GroupBy(m=>m.Raza.Especie.Nombre)
            .Select(g=> new
            {
                NombreEspecie = g.Key,
                Mascotas = g.ToList()
            })
            .ToListAsync();

            return mascotasXespecie;
        }

        public async Task<IEnumerable<Mascota>> GetMascotaAtendidaXveterinario(string veterinarioConsulta)
        {
            var mascotasXveterinario = await _context.Citas
            .Where(t=> t.Veterinario.Nombre == veterinarioConsulta)
            .Select(t=>t.Mascota)
            .Distinct()
            .ToListAsync();

            return mascotasXveterinario;
        }

        public async Task<IEnumerable<Mascota>> GetMascotaYpropietarioGoldenRetriver()
        {
            var mascotasGolden = await _context.Mascotas
            .Where(t=>t.Raza.Nombre == "Golden Retriever")
            .Include(t=>t.Propietario)
            .Include(t=>t.Raza)
            .ThenInclude(t=>t.Especie)
            .ToListAsync();

            return mascotasGolden;
        }
    }
}