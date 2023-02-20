using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;
using Ecommerce.Models.Enum;
using FluentResults;
using Marktplace.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private VendaService _service;

        public VendaController(VendaService service)
        {
            _service = service;
        }
        
        #region Post
        /// <summary>
        /// Adiciona uma nova venda no banco de dados.
        /// </summary>
        /// <param name="vendaDTO"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult CreateVenda([FromBody] CreateVendaDTO vendaDTO)
        {
            //Verifica se o Json passado no body está correto. Exemplo: Foreign Key. 
            ReadVendaDTO venda = _service.CreateVenda(vendaDTO);
            if(!ModelState.IsValid) return BadRequest(ModelState);
               
            return CreatedAtAction(nameof(GetVendaById), new {Id = venda.VendaId }, venda);
        }
        #endregion

        #region Get
        /// <summary>
        /// Retorna todas as vendas do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult GetAllVendas()
        {
            List<ReadVendaDTO> vendas = _service.GetAllVendas();
            return Ok(vendas);
        }
        
        /// <summary>
        /// Returna uma venda por um determinado Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetVendaById(int id)
        {
            ReadVendaDTO venda = _service.GetVendaById(id);

            if (venda == null) return NotFound();

            return Ok(venda);
        }
        #endregion

        #region Put
        /// <summary>
        /// Atualiza o status de uma determinada venda do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vendaDTO"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateVenda(int id, [FromBody] UpdateVendaDTO vendaDTO)
        {
            Result statusAlterado = _service.UpdateVenda(id, vendaDTO);
            TryValidateModel(vendaDTO);

                if (statusAlterado.IsFailed) return NotFound();
            
            return NoContent();
            
            /*if(statusAlterado == null)
            {
                return NotFound(new {msg = "Objeto não encontrado, verifique o ID"});
            }
            else
            {
                EnumVerification verification = new EnumVerification();
                if (verification.IsStatusInvalide(vendaBanco, vendaDTO)) return BadRequest();
                
                _mapper.Map(vendaDTO, vendaBanco);
                _context.SaveChanges();
                return NoContent();
            }*/
        }
        #endregion
    }
}
