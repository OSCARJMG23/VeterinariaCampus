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
    public class MovimientoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public MovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MovimientoDto>>> Get([FromQuery]Params movimientoParams)
        {
            var movimiento = await _unitOfWork.Movimientos.GetAllAsync(movimientoParams.PageIndex,movimientoParams.PageSize, movimientoParams.Search);
            var listaMovimientosDto= _mapper.Map<List<MovimientoDto>>(movimiento.registros);
            return new Pager<MovimientoDto>(listaMovimientosDto, movimiento.totalRegistros,movimientoParams.PageIndex,movimientoParams.PageSize,movimientoParams.Search);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoDto>> Get(int id)
        {
            var movimiento = await _unitOfWork.Movimientos.GetByIdAsync(id);
            return _mapper.Map<MovimientoDto>(movimiento);
        }
        [HttpGet("valorTotalXmovimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetMovimientosYvalorTotal()
        {
            var movimiento = await _unitOfWork.Movimientos.GetMovimientosYvalorTotalXmovimiento();
            return Ok(movimiento);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Movimiento>> Post(MovimientoDto movimientoDto)
        {
            var movimiento = _mapper.Map<Movimiento>(movimientoDto);
            _unitOfWork.Movimientos.Add(movimiento);
            await _unitOfWork.SaveAsync();
        
            if (movimiento == null)
            {
                return BadRequest();
            }
            movimiento.Id = movimiento.Id;
            return CreatedAtAction(nameof(Post), new { id = movimiento.Id }, movimiento);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoDto>> Put(int id, [FromBody]MovimientoDto movimientoDto)
        {
            if (movimientoDto == null)
            {
                return NotFound();
            }
            var movimiento = _mapper.Map<Movimiento>(movimientoDto);
            _unitOfWork.Movimientos.Update(movimiento);
            await _unitOfWork.SaveAsync();
            return movimientoDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoDto>> Delete(int id)
        {
            var movimiento = await _unitOfWork.Movimientos.GetByIdAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }
            _unitOfWork.Movimientos.Remove(movimiento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}