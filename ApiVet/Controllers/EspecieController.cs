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
    public class EspecieController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EspecieDto>>> Get([FromQuery]Params especieParams)
        {
            var especie = await _unitOfWork.Especies.GetAllAsync(especieParams.PageIndex,especieParams.PageSize, especieParams.Search);
            var listaEspeciesDto= _mapper.Map<List<EspecieDto>>(especie.registros);
            return new Pager<EspecieDto>(listaEspeciesDto, especie.totalRegistros,especieParams.PageIndex,especieParams.PageSize,especieParams.Search);
        }
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EspecieDto>>> Get1()
        {
           var especie = await _unitOfWork.Especies.GetNormally();

           return _mapper.Map<List<EspecieDto>>(especie);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspeciesDto>> Get(int id)
        {
            var especie = await _unitOfWork.Especies.GetByIdAsync(id);
            return _mapper.Map<EspeciesDto>(especie);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Especie>> Post(EspecieDto especieDto)
        {
            var especie = _mapper.Map<Especie>(especieDto);
            _unitOfWork.Especies.Add(especie);
            await _unitOfWork.SaveAsync();
        
            if (especie == null)
            {
                return BadRequest();
            }
            especie.Id = especie.Id;
            return CreatedAtAction(nameof(Post), new { id = especie.Id }, especie);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody]EspecieDto especieDto)
        {
            if (especieDto == null)
            {
                return NotFound();
            }
            var especie = _mapper.Map<Especie>(especieDto);
            _unitOfWork.Especies.Update(especie);
            await _unitOfWork.SaveAsync();
            return especieDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EspecieDto>> Delete(int id)
        {
            var especie = await _unitOfWork.Especies.GetByIdAsync(id);
            if (especie == null)
            {
                return NotFound();
            }
            _unitOfWork.Especies.Remove(especie);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}