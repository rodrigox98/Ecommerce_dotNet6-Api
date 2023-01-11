using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public VendedorController(EcommerceContext context)
        {
            _context = context;
        }

        string msg = "Objeto não encontrado";

        #region Post
        [HttpPost]
        public IActionResult CreateVendedor([FromBody] Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVendedorById), new {id = vendedor.IdVendedor}, vendedor);
        }
        #endregion


        #region Get
        [HttpGet]
        public IActionResult GetAllVendedores()
        {
            List<Vendedor> vendores = _context.Vendedores.ToList();
            return Ok(vendores);
        }


        [HttpGet("{id}")]
        public IActionResult GetVendedorById(int id)
        {
            
            var vendedorId = _context.Vendedores.Find(id);
            if (vendedorId == null) return NotFound(msg);
             
            return Ok(vendedorId);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateVendedor(int id, [FromBody] Vendedor vendedor)
        {
            var vendedorBancoDeDados = _context.Vendedores.Find(id);

            if (vendedorBancoDeDados == null) return NotFound(msg);

            vendedorBancoDeDados.Cpf = vendedor.Cpf;
            vendedorBancoDeDados.Nome = vendedor.Nome;
            vendedorBancoDeDados.Telefone = vendedor.Telefone;
            vendedorBancoDeDados.Email = vendedor.Email;

            _context.Update(vendedorBancoDeDados);
            _context.SaveChanges();
            return Ok(vendedorBancoDeDados);
        }
        #endregion
    }
}
