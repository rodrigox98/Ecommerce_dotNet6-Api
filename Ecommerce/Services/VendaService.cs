using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.Models;
using Ecommerce.Models.Enum;
using FluentResults;

namespace Marktplace.Services
{
    public class VendaService
    {
        private MarketplaceContext _context;
        private IMapper _mapper;

        public VendaService(MarketplaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        #region Post
        public ReadVendaDTO CreateVenda(CreateVendaDTO vendaDTO)
        {
            Venda venda = _mapper.Map<Venda>(vendaDTO);
            _context.Add(venda);
            _context.SaveChanges();
            return _mapper.Map<ReadVendaDTO>(venda);
        }
        #endregion

        #region Get
        public List<ReadVendaDTO> GetAllVendas()
        {
            List<Venda> vendas = _context.Vendas.ToList();
            vendas.ForEach(venda => venda.Vendedor.CalcularTotalVendas());
            List<ReadVendaDTO> vendasDTO = _mapper.Map<List<ReadVendaDTO>>(vendas);
            return vendasDTO;
        }
        public ReadVendaDTO GetVendaById(int id)
        {
            Venda venda = _context.Vendas.FirstOrDefault(v => v.VendaId == id);
            if(venda == null)
            {
                return null;
            }
            else
            {
                venda.Vendedor.CalcularTotalVendas();
                ReadVendaDTO vendaDTO = _mapper.Map<ReadVendaDTO>(venda);
                return vendaDTO;
            }
        }
        #endregion
        #region Put
        public Result UpdateVenda(int id, UpdateVendaDTO vendaDTO)
        {
            Venda vendaBanco = _context.Vendas.FirstOrDefault(v => v.VendaId == id);
            if(vendaBanco == null)
            {
                return Result.Fail("Venda não encontrada");
            }
            else
            {
                EnumVerification verification = new EnumVerification();

                if (verification.IsStatusInvalide(vendaBanco, vendaDTO))
                {
                    Result.Fail("Não é possível fazer essa atualização.");
                }
                _mapper.Map(vendaDTO, vendaBanco);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
        #endregion
    }
}
