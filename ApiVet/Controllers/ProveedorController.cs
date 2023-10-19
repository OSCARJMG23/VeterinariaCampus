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
    
    public class ProveedorController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProveedorDto>>> Get([FromQuery]Params proveedorParams)
        {
            var proveedor = await _unitOfWork.Proveedores.GetAllAsync(proveedorParams.PageIndex,proveedorParams.PageSize, proveedorParams.Search);
            var listaProveedoresDto= _mapper.Map<List<ProveedorDto>>(proveedor.registros);
            return new Pager<ProveedorDto>(listaProveedoresDto, proveedor.totalRegistros,proveedorParams.PageIndex,proveedorParams.PageSize,proveedorParams.Search);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get1()
        {
           var proveedors = await _unitOfWork.Proveedores.GetNormally();

           return _mapper.Map<List<ProveedorDto>>(proveedors);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProveedoresDto>> Get(int id)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            return _mapper.Map<ProveedoresDto>(proveedor);
        }
        [HttpGet("con/{medicamentoConsulta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedoresDto>>> GetProveedorXmedicamento(string medicamentoConsulta)
        {
            var proveedor = await _unitOfWork.Proveedores.GetProveedoresXmedicamento(medicamentoConsulta);
            return _mapper.Map<List<ProveedoresDto>>(proveedor);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Proveedor>> Post(ProveedorDto proveedorDto)
        {
            var proveedor = _mapper.Map<Proveedor>(proveedorDto);
            _unitOfWork.Proveedores.Add(proveedor);
            await _unitOfWork.SaveAsync();
        
            if (proveedor == null)
            {
                return BadRequest();
            }
            proveedor.Id = proveedor.Id;
            return CreatedAtAction(nameof(Post), new { id = proveedor.Id }, proveedor);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody]ProveedorDto proveedorDto)
        {
            if (proveedorDto == null)
            {
                return NotFound();
            }
            var proveedor = _mapper.Map<Proveedor>(proveedorDto);
            _unitOfWork.Proveedores.Update(proveedor);
            await _unitOfWork.SaveAsync();
            return proveedorDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProveedorDto>> Delete(int id)
        {
            var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            _unitOfWork.Proveedores.Remove(proveedor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}