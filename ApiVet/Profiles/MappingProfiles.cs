using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVet.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace ApiVet.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cita,CitaDto>().ReverseMap();

            CreateMap<Especie, EspecieDto>().ReverseMap();
            CreateMap<Especie, EspeciesDto>().ReverseMap();

            CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();
            CreateMap<Laboratorio, LaboratoriosDto>().ReverseMap();

            CreateMap<Mascota, MascotaDto>().ReverseMap();
            CreateMap<Mascota, MascotasDto>().ReverseMap();

            CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
            CreateMap<Medicamento, MedicamentosDto>().ReverseMap();

            CreateMap<Movimiento, MovimientoDto>().ReverseMap();

            CreateMap<Propietario, PropietarioDto>().ReverseMap();
            CreateMap<Propietario, PropietariosDto>().ReverseMap();

            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
            CreateMap<Proveedor, ProveedoresDto>().ReverseMap();

            CreateMap<Raza, RazaDto>().ReverseMap();
            CreateMap<Raza, RazasDto>().ReverseMap();

            CreateMap<TratamientoMedico, TratamientoMedicoDto>().ReverseMap();

            CreateMap<Veterinario, VeterinarioDto>().ReverseMap();
            CreateMap<Veterinario, VeterinariosDto>().ReverseMap();
            
            CreateMap<TipoMovimiento, TipoMovimientoDto>().ReverseMap();

        }
    }
}