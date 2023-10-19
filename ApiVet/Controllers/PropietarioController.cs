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
    public class PropietarioController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PropietarioDto>>> Get([FromQuery]Params propietarioParams)
        {
            var propietario = await _unitOfWork.Propietarios.GetAllAsync(propietarioParams.PageIndex,propietarioParams.PageSize, propietarioParams.Search);
            var listaPropietariosDto= _mapper.Map<List<PropietarioDto>>(propietario.registros);
            return new Pager<PropietarioDto>(listaPropietariosDto, propietario.totalRegistros,propietarioParams.PageIndex,propietarioParams.PageSize,propietarioParams.Search);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get1()
        {
           var propietarios = await _unitOfWork.Propietarios.GetNormally();

           return _mapper.Map<List<PropietarioDto>>(propietarios);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropietariosDto>> Get(int id)
        {
            var propietario = await _unitOfWork.Propietarios.GetByIdAsync(id);
            return _mapper.Map<PropietariosDto>(propietario);
        }
        [HttpGet("mascotas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PropietariosDto>>> GetPropietarioConMascotas()
        {
            var propietario = await _unitOfWork.Propietarios.GetPropietariosWhitMascotas();
            return _mapper.Map<List<PropietariosDto>>(propietario);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Propietario>> Post(PropietarioDto propietarioDto)
        {
            var propietario = _mapper.Map<Propietario>(propietarioDto);
            _unitOfWork.Propietarios.Add(propietario);
            await _unitOfWork.SaveAsync();
        
            if (propietario == null)
            {
                return BadRequest();
            }
            propietario.Id = propietario.Id;
            return CreatedAtAction(nameof(Post), new { id = propietario.Id }, propietario);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody]PropietarioDto propietarioDto)
        {
            if (propietarioDto == null)
            {
                return NotFound();
            }
            var propietario = _mapper.Map<Propietario>(propietarioDto);
            _unitOfWork.Propietarios.Update(propietario);
            await _unitOfWork.SaveAsync();
            return propietarioDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropietarioDto>> Delete(int id)
        {
            var propietario = await _unitOfWork.Propietarios.GetByIdAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            _unitOfWork.Propietarios.Remove(propietario);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}