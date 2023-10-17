using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiVet.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVet.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class TratamientoMedicoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public TratamientoMedicoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
        {
            var tratamientoMedico = await _unitOfWork.TratamientosMedicos.GetAllAsync();
            return _mapper.Map<List<TratamientoMedicoDto>>(tratamientoMedico);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoMedicoDto>> Get(int id)
        {
            var tratamientoMedico = await _unitOfWork.TratamientosMedicos.GetByIdAsync(id);
            return _mapper.Map<TratamientoMedicoDto>(tratamientoMedico);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoMedico>> Post(TratamientoMedicoDto tratamientoMedicoDto)
        {
            var tratamientoMedico = _mapper.Map<TratamientoMedico>(tratamientoMedicoDto);
            _unitOfWork.TratamientosMedicos.Add(tratamientoMedico);
            await _unitOfWork.SaveAsync();
        
            if (tratamientoMedico == null)
            {
                return BadRequest();
            }
            tratamientoMedico.Id = tratamientoMedico.Id;
            return CreatedAtAction(nameof(Post), new { id = tratamientoMedico.Id }, tratamientoMedico);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoMedicoDto>> Put(int id, [FromBody]TratamientoMedicoDto tratamientoMedicoDto)
        {
            if (tratamientoMedicoDto == null)
            {
                return NotFound();
            }
            var tratamientoMedico = _mapper.Map<TratamientoMedico>(tratamientoMedicoDto);
            _unitOfWork.TratamientosMedicos.Update(tratamientoMedico);
            await _unitOfWork.SaveAsync();
            return tratamientoMedicoDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TratamientoMedicoDto>> Delete(int id)
        {
            var tratamientoMedico = await _unitOfWork.TratamientosMedicos.GetByIdAsync(id);
            if (tratamientoMedico == null)
            {
                return NotFound();
            }
            _unitOfWork.TratamientosMedicos.Remove(tratamientoMedico);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}