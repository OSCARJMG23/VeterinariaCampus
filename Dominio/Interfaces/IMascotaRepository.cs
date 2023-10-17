using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IMascotaRepository : IGenericRepository<Mascota>
    {
        Task<IEnumerable<Mascota>> GetMascotasFelinas();
        Task<IEnumerable<Mascota>> MascotaCitaXvacunacion2023();
        Task<IEnumerable<object>> GetMascotasAgrupadasXespecie();
        Task<IEnumerable<Mascota>> GetMascotaAtendidaXveterinario(string veterinarioConsulta);
        Task<IEnumerable<Mascota>> GetMascotaYpropietarioGoldenRetriver();
    }
}