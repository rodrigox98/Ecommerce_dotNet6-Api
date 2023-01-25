using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IMapper _mapper;

        public VendedorController(EcommerceContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
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
            Vendedor vendedor = _mapper.Map<Vendedor>(vendedorDTO);
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedorById), new { Id = vendedor.VendedorId }, vendedor);
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
            
            List<Vendedor> vendedores = _context.Vendedores.ToList();
            vendedores.ForEach(vendedor => vendedor.CalcularTotalVendas());

            List<ReadVendedorDTO> vendedoresDTO = _mapper.Map<List<ReadVendedorDTO>>(vendedores);
            return Ok(vendedoresDTO);
        }

        /// <summary>
        /// Retorna um vendedor pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            var vendedorBanco = _context.Vendedores.FirstOrDefault(v => v.VendedorId == id);
            
            if (vendedorBanco == null) return NotFound(msg);
            //Calcula o somatório total de todas as Vendas do Vendedor.
            vendedorBanco.CalcularTotalVendas();
            ReadVendedorDTO vendedor = _mapper.Map<ReadVendedorDTO>(vendedorBanco);
            
            
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
            Vendedor vendedorBancoDeDados = _context.Vendedores.FirstOrDefault(f => f.VendedorId == id);

            if (vendedorBancoDeDados == null) return NotFound(msg);

            _mapper.Map(vendedorDTO, vendedorBancoDeDados);
           
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
