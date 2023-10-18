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
    public class VeterinarioController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public VeterinarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VeterinarioDto>>> Get([FromQuery]Params veterinarioParams)
        {
            var veterinario = await _unitOfWork.Veterinarios.GetAllAsync(veterinarioParams.PageIndex,veterinarioParams.PageSize, veterinarioParams.Search);
            var listaVeterinariosDto= _mapper.Map<List<VeterinarioDto>>(veterinario.registros);
            return new Pager<VeterinarioDto>(listaVeterinariosDto, veterinario.totalRegistros,veterinarioParams.PageIndex,veterinarioParams.PageSize,veterinarioParams.Search);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VeterinariosDto>> Get(int id)
        {
            var veterinario = await _unitOfWork.Veterinarios.GetByIdAsync(id);
            return _mapper.Map<VeterinariosDto>(veterinario);
        }
        [HttpGet("cirujano-vascular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VeterinariosDto>>> GetVetCirujanoVascu()
        {
            var veterinario = await _unitOfWork.Veterinarios.GetVeterinarioCirujanoVascular();
            return _mapper.Map<List<VeterinariosDto>>(veterinario);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Veterinario>> Post(VeterinarioDto veterinarioDto)
        {
            var veterinario = _mapper.Map<Veterinario>(veterinarioDto);
            _unitOfWork.Veterinarios.Add(veterinario);
            await _unitOfWork.SaveAsync();
        
            if (veterinario == null)
            {
                return BadRequest();
            }
            veterinario.Id = veterinario.Id;
            return CreatedAtAction(nameof(Post), new { id = veterinario.Id }, veterinario);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody]VeterinarioDto veterinarioDto)
        {
            if (veterinarioDto == null)
            {
                return NotFound();
            }
            var veterinario = _mapper.Map<Veterinario>(veterinarioDto);
            _unitOfWork.Veterinarios.Update(veterinario);
            await _unitOfWork.SaveAsync();
            return veterinarioDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VeterinarioDto>> Delete(int id)
        {
            var veterinario = await _unitOfWork.Veterinarios.GetByIdAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }
            _unitOfWork.Veterinarios.Remove(veterinario);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}