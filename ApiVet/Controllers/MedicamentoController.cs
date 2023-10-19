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
    public class MedicamentoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicamentoDto>>> Get([FromQuery]Params medicamentoParams)
        {
            var medicamento = await _unitOfWork.Medicamentos.GetAllAsync(medicamentoParams.PageIndex,medicamentoParams.PageSize, medicamentoParams.Search);
            var listaMedicamentosDto= _mapper.Map<List<MedicamentoDto>>(medicamento.registros);
            return new Pager<MedicamentoDto>(listaMedicamentosDto, medicamento.totalRegistros,medicamentoParams.PageIndex,medicamentoParams.PageSize,medicamentoParams.Search);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get1()
        {
           var medicamentos = await _unitOfWork.Medicamentos.GetNormally();

           return _mapper.Map<List<MedicamentoDto>>(medicamentos);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentosDto>> Get(int id)
        {
            var medicamento = await _unitOfWork.Medicamentos.GetByIdAsync(id);
            return _mapper.Map<MedicamentosDto>(medicamento);
        }
        [HttpGet("laboratorio-genfar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentosDto>>> GetMedicamentoLaboratorioGenfar()
        {
            var medicamento = await _unitOfWork.Medicamentos.GetMedicamentoLaboratorioGenfar();
            return _mapper.Map<List<MedicamentosDto>>(medicamento);
        }
        [HttpGet("precio-mayor-50k")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentoPrecioMayor50k()
        {
            var medicamento = await _unitOfWork.Medicamentos.MedicamentoPrecioMayor50K();
            return _mapper.Map<List<MedicamentoDto>>(medicamento);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Medicamento>> Post(MedicamentoDto medicamentoDto)
        {
            var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
            _unitOfWork.Medicamentos.Add(medicamento);
            await _unitOfWork.SaveAsync();
        
            if (medicamento == null)
            {
                return BadRequest();
            }
            medicamento.Id = medicamento.Id;
            return CreatedAtAction(nameof(Post), new { id = medicamento.Id }, medicamento);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody]MedicamentoDto medicamentoDto)
        {
            if (medicamentoDto == null)
            {
                return NotFound();
            }
            var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
            _unitOfWork.Medicamentos.Update(medicamento);
            await _unitOfWork.SaveAsync();
            return medicamentoDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentoDto>> Delete(int id)
        {
            var medicamento = await _unitOfWork.Medicamentos.GetByIdAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            _unitOfWork.Medicamentos.Remove(medicamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}