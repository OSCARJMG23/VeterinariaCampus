using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IProveedorRepository : IGenericRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> GetProveedoresXmedicamento(string medicamentoConsulta);
    }
}