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
    [Authorize]
    public class CitaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CitaDto>>> Get([FromQuery]Params citaParams)
        {
            var citas = await _unitOfWork.Citas.GetAllAsync(citaParams.PageIndex,citaParams.PageSize, citaParams.Search);
            var listaCitasDto= _mapper.Map<List<CitaDto>>(citas.registros);
            return new Pager<CitaDto>(listaCitasDto, citas.totalRegistros,citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CitaDto>> Get(int id)
        {
            var cita = await _unitOfWork.Citas.GetByIdAsync(id);
            return _mapper.Map<CitaDto>(cita);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cita>> Post(CitaDto citaDto)
        {
            var cita = _mapper.Map<Cita>(citaDto);
            _unitOfWork.Citas.Add(cita);
            await _unitOfWork.SaveAsync();
        
            if (cita == null)
            {
                return BadRequest();
            }
            cita.Id = cita.Id;
            return CreatedAtAction(nameof(Post), new { id = cita.Id }, cita);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CitaDto>> Put(int id, [FromBody]CitaDto citaDto)
        {
            if (citaDto == null)
            {
                return NotFound();
            }
            var cita = _mapper.Map<Cita>(citaDto);
            _unitOfWork.Citas.Update(cita);
            await _unitOfWork.SaveAsync();
            return citaDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CitaDto>> Delete(int id)
        {
            var citas = await _unitOfWork.Citas.GetByIdAsync(id);
            if (citas == null)
            {
                return NotFound();
            }
            _unitOfWork.Citas.Remove(citas);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}