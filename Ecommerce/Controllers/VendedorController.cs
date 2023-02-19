using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;
using FluentResults;
using Marktplace.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private VendedorService _service;

        public VendedorController(VendedorService service)
        {
            _service = service;
        }

        string msg = "Objeto não encontrado";

        #region Post
        /// <summary>
        /// Adiciona um Vendedor ao banco de dados.
        /// </summary>
        /// <param name="vendedorDTO">Objeto com campos necessários para criação de um vendedor.</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso.</response>
        [HttpPost]
        public IActionResult CreateVendedor([FromBody] CreateVendedorDTO vendedorDTO)
        {
            ReadVendedorDTO vendedor = _service.CreateVendedor(vendedorDTO);
            return CreatedAtAction(nameof(GetVendedorById), new { Id = vendedor.VendedorId}, vendedor);
        }
        #endregion


        #region Get
        /// <summary>
        /// Retorna todos os vendedores do banco de dados.
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult GetAllVendedores()
        {
            
            List<ReadVendedorDTO> vendedores = _service.GetAllVendedores();
            if (vendedores == null) return NotFound();
            return Ok(vendedores);
        }

        /// <summary>
        /// Retorna um vendedor pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            ReadVendedorDTO vendedor = _service.GetVendedorById(id);

            if(vendedor == null) return NotFound();

            return Ok(vendedor);
        }
        #endregion


        #region Put
        /// <summary>
        /// Atualize os dados de um determinado vendedor do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vendedorDTO"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateVendedor(int id, [FromBody] UpdateVendedorDTO vendedorDTO)
        {
            Result result = _service.UpdateVendedor(id, vendedorDTO);
            
            if(result.IsFailed) return NotFound();
            return NoContent();
        }
        #endregion
    }
}
