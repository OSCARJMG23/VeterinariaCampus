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
    public class LaboratorioController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public LaboratorioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<LaboratorioDto>>> Get([FromQuery]Params laboratorioParams)
        {
            var laboratorio = await _unitOfWork.Laboratorios.GetAllAsync(laboratorioParams.PageIndex,laboratorioParams.PageSize, laboratorioParams.Search);
            var listaLaboratoriosDto= _mapper.Map<List<LaboratorioDto>>(laboratorio.registros);
            return new Pager<LaboratorioDto>(listaLaboratoriosDto, laboratorio.totalRegistros,laboratorioParams.PageIndex,laboratorioParams.PageSize,laboratorioParams.Search);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<LaboratorioDto>>> Get1()
        {
           var laboratorios = await _unitOfWork.Laboratorios.GetNormally();

           return _mapper.Map<List<LaboratorioDto>>(laboratorios);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LaboratoriosDto>> Get(int id)
        {
            var laboratorio = await _unitOfWork.Laboratorios.GetByIdAsync(id);
            return _mapper.Map<LaboratoriosDto>(laboratorio);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Laboratorio>> Post(LaboratorioDto laboratorioDto)
        {
            var laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
            _unitOfWork.Laboratorios.Add(laboratorio);
            await _unitOfWork.SaveAsync();
        
            if (laboratorio == null)
            {
                return BadRequest();
            }
            laboratorio.Id = laboratorio.Id;
            return CreatedAtAction(nameof(Post), new { id = laboratorio.Id }, laboratorio);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LaboratorioDto>> Put(int id, [FromBody]LaboratorioDto laboratorioDto)
        {
            if (laboratorioDto == null)
            {
                return NotFound();
            }
            var laboratorio = _mapper.Map<Laboratorio>(laboratorioDto);
            _unitOfWork.Laboratorios.Update(laboratorio);
            await _unitOfWork.SaveAsync();
            return laboratorioDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LaboratorioDto>> Delete(int id)
        {
            var laboratorio = await _unitOfWork.Laboratorios.GetByIdAsync(id);
            if (laboratorio == null)
            {
                return NotFound();
            }
            _unitOfWork.Laboratorios.Remove(laboratorio);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}