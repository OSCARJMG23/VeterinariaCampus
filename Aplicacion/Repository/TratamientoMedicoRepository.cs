using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedicoRepository
    {
        private readonly ApiVetContext _context;
        public TratamientoMedicoRepository(ApiVetContext context) : base(context)
        {
            _context = context;
        }
    }
}