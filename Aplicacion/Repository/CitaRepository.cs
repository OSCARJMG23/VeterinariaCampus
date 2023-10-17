using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        private readonly ApiVetContext _context;
        public CitaRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }
    }
}