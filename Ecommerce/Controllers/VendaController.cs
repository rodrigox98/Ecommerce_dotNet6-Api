using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;
using Ecommerce.Models.Enum;
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
        /// <summary>
        /// Adiciona uma nova venda no banco de dados.
        /// </summary>
        /// <param name="vendaDTO"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult CreateVenda([FromBody] CreateVendaDTO vendaDTO)
        {
            //Verifica se o Json passado no body está correto. Exemplo: Foreign Key. 
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Venda venda = _mapper.Map<Venda>(vendaDTO);

            _context.Vendas.Add(venda);
            _context.SaveChanges();
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
            List<Venda> vendas = _context.Vendas.ToList();
            vendas.ForEach(venda => venda.Vendedor.CalcularTotalVendas());
            List<ReadVendaDTO> vendasDTO = _mapper.Map<List<ReadVendaDTO>>(vendas);
            return Ok(vendasDTO);
        }
        

        /// <summary>
        /// Returna uma venda por um determinado Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetVendaById(int id)
        {
            Venda vendaBanco = _context.Vendas.FirstOrDefault(venda => venda.VendaId == id);
            if (vendaBanco == null) return NotFound();

            vendaBanco.Vendedor.CalcularTotalVendas();
            ReadVendaDTO venda = _mapper.Map<ReadVendaDTO>(vendaBanco);
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
        public IActionResult UpdateVenda(int id, UpdateVendaDTO vendaDTO)
        {
            Venda vendaBanco = _context.Vendas.FirstOrDefault(v => v.VendaId == id);
            

            TryValidateModel(vendaDTO);

            if(vendaBanco == null)
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
            }
        }
        #endregion
    }
}
