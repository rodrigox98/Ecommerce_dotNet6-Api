using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

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
            //Verifica se o Json passado no body está correto. Exemplo: Foreign Key. 
            if (!ModelState.IsValid) return BadRequest(ModelState);

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
            List<ReadVendaDTO> vendasDTO = _mapper.Map<List<ReadVendaDTO>>(vendas);
            return Ok(vendasDTO);
        }
        #endregion
    }
}
