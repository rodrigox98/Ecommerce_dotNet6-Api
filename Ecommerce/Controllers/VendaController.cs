using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private EcommerceContext _context;
        private IMapper _mapper;

        public VendaController(EcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Post
        [HttpPost]
        public IActionResult CreateVenda([FromBody] CreateVendaDTO vendaDTO)
        {
            Venda venda = _mapper.Map<Venda>(vendaDTO);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Ok();
        }
        #endregion

        #region Get

        [HttpGet]
        public IActionResult GetAllVendas()
        {
            List<Venda> vendas = _context.Vendas.ToList();
            return Ok(vendas);
        }
        #endregion
    }
}
