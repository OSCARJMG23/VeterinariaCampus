using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiVet.Dtos;
using ApiVet.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVet.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MascotaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MascotaDto>>> Get([FromQuery]Params mascotaParams)
        {
            var mascota = await _unitOfWork.Mascotas.GetAllAsync(mascotaParams.PageIndex,mascotaParams.PageSize, mascotaParams.Search);
            var listaMascotasDto= _mapper.Map<List<MascotaDto>>(mascota.registros);
            return new Pager<MascotaDto>(listaMascotasDto, mascota.totalRegistros,mascotaParams.PageIndex,mascotaParams.PageSize,mascotaParams.Search);
        }

        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> Get1()
        {
           var mascotas = await _unitOfWork.Mascotas.GetNormally();

           return _mapper.Map<List<MascotaDto>>(mascotas);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotasDto>> Get(int id)
        {
            var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
            return _mapper.Map<MascotasDto>(mascota);
        }

        [HttpGet("especie-felina")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotaFelina(int id)
        {
            var mascota = await _unitOfWork.Mascotas.GetMascotasFelinas();
            return _mapper.Map<List<MascotaDto>>(mascota);
        }

        [HttpGet("cita-vacunacion-2023")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotasDto>>> GetMascotaCitaVacunacion2023()
        {
            var mascota = await _unitOfWork.Mascotas.MascotaCitaXvacunacion2023();
            return _mapper.Map<List<MascotasDto>>(mascota);
        }

        [HttpGet("mascotaXespecie")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetMascotaXespecie()
        {
            var mascota = await _unitOfWork.Mascotas.GetMascotasAgrupadasXespecie();
            return Ok(mascota);
        }

        [HttpGet("mascota-atendidaXveterinario/{veterinarioConsulta}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotasDto>>> GetMascotaAntendidaXveterinario(string veterinarioConsulta)
        {
            var mascota = await _unitOfWork.Mascotas.GetMascotaAtendidaXveterinario(veterinarioConsulta);
            if (mascota == null)
            {
                return BadRequest();
            }
            return _mapper.Map<List<MascotasDto>>(mascota);
        }

        [HttpGet("mascota-Y-propietario-goldenRetriever")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotaYpropietarioGoldenR()
        {
            var mascota = await _unitOfWork.Mascotas.GetMascotaYpropietarioGoldenRetriver();
            if (mascota == null)
            {
                return BadRequest();
            }
            return _mapper.Map<List<MascotaDto>>(mascota);
        }

        
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Mascota>> Post(MascotaDto mascotaDto)
        {
            var mascota = _mapper.Map<Mascota>(mascotaDto);
            _unitOfWork.Mascotas.Add(mascota);
            await _unitOfWork.SaveAsync();
        
            if (mascota == null)
            {
                return BadRequest();
            }
            mascota.Id = mascota.Id;
            return CreatedAtAction(nameof(Post), new { id = mascota.Id }, mascota);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody]MascotaDto mascotaDto)
        {
            if (mascotaDto == null)
            {
                return NotFound();
            }
            var mascota = _mapper.Map<Mascota>(mascotaDto);
            _unitOfWork.Mascotas.Update(mascota);
            await _unitOfWork.SaveAsync();
            return mascotaDto;
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MascotaDto>> Delete(int id)
        {
            var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            _unitOfWork.Mascotas.Remove(mascota);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}