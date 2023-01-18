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
        [HttpGet]
        public IActionResult GetAllVendedores()
        {
            
            List<Vendedor> vendedores = _context.Vendedores.ToList();
            List<ReadVendedorDTO> vendedoresDTO = _mapper.Map<List<ReadVendedorDTO>>(vendedores);
            return Ok(vendedoresDTO);
        }


        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            var vendedorBanco = _context.Vendedores.FirstOrDefault(v => v.VendedorId == id);
            
            if (vendedorBanco == null) return NotFound(msg);

            ReadVendedorDTO vendedor = _mapper.Map<ReadVendedorDTO>(vendedorBanco);
            
            return Ok(vendedor);
        }
        #endregion


        #region Put
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
