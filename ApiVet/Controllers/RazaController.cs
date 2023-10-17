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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVet.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class RazaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<RazaDto>>> Get([FromQuery]Params razaParams)
        {
            var razas = await _unitOfWork.Razas.GetAllAsync(razaParams.PageIndex,razaParams.PageSize, razaParams.Search);
            var listaRazasDto= _mapper.Map<List<RazaDto>>(razas.registros);
            return new Pager<RazaDto>(listaRazasDto, razas.totalRegistros,razaParams.PageIndex,razaParams.PageSize,razaParams.Search);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazasDto>> Get(int id)
        {
            var raza = await _unitOfWork.Razas.GetByIdAsync(id);
            return _mapper.Map<RazasDto>(raza);
        }
        [HttpGet("cantidad-mascotasXraza")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetCantidadMascotasXraza()
        {
            var raza = await _unitOfWork.Razas.GetCantidadMascotaXraza();
            return Ok(raza);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Raza>> Post(RazaDto razaDto)
        {
            var raza = _mapper.Map<Raza>(razaDto);
            _unitOfWork.Razas.Add(raza);
            await _unitOfWork.SaveAsync();
        
            if (raza == null)
            {
                return BadRequest();
            }
            raza.Id = raza.Id;
            return CreatedAtAction(nameof(Post), new { id = raza.Id }, raza);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RazaDto>> Put(int id, [FromBody]RazaDto razaDto)
        {
            if (razaDto == null)
            {
                return NotFound();
            }
            var raza = _mapper.Map<Raza>(razaDto);
            _unitOfWork.Razas.Update(raza);
            await _unitOfWork.SaveAsync();
            return razaDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Raza>> Delete(int id)
        {
            var raza = await _unitOfWork.Razas.GetByIdAsync(id);
            if (raza == null)
            {
                return NotFound();
            }
            _unitOfWork.Razas.Remove(raza);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}