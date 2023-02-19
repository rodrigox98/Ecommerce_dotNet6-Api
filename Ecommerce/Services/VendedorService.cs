using AutoMapper;
using Ecommerce.Context;
using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;
using FluentResults;

namespace Marktplace.Services
{
    
    public class VendedorService
    {
        private MarketplaceContext _context;
        private IMapper _mapper;

        public VendedorService(MarketplaceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Post
        public ReadVendedorDTO CreateVendedor(CreateVendedorDTO vendedorDTO)
        {
            Vendedor vendedor = _mapper.Map<Vendedor>(vendedorDTO);
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return _mapper.Map<ReadVendedorDTO>(vendedor);
        }

        #endregion

        #region Get
        public List<ReadVendedorDTO> GetAllVendedores()
        {
            List<Vendedor> vendedores = _context.Vendedores.ToList();
            vendedores.ForEach(vendedor => vendedor.CalcularTotalVendas());

            List<ReadVendedorDTO> vendedoresDTO = _mapper.Map<List<ReadVendedorDTO>>(vendedores);
            return vendedoresDTO;
        }


        public ReadVendedorDTO GetVendedorById(int id)
        {
            Vendedor vendedorBanco = _context.Vendedores.FirstOrDefault(v => v.VendedorId == id);
            if (vendedorBanco == null)
            {
                return null;
            }
            else 
            {
                vendedorBanco.CalcularTotalVendas();
                ReadVendedorDTO vendedorDTO = _mapper.Map<ReadVendedorDTO>(vendedorBanco);
                return vendedorDTO;
            }
        }
        #endregion

        #region Put
        public Result UpdateVendedor(int id, UpdateVendedorDTO vendedorDTO)
        {
            Vendedor vendedor = _context.Vendedores.FirstOrDefault(v => v.VendedorId == id);
            if(vendedor == null)
            {
                return Result.Fail("Vendedor não encontrado");
            }
            else
            {
                _mapper.Map(vendedorDTO, vendedor);
                _context.SaveChanges();
                return Result.Ok();
            }
        }
        #endregion

    }
}
