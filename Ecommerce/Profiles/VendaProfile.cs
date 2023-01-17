using AutoMapper;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.Models;
using System.Linq;
namespace Ecommerce.Profiles
{
    public class VendaProfile : Profile
    {
        public VendaProfile()
        {
            CreateMap<CreateVendaDTO, Venda>();
            CreateMap<Venda, ReadVendaDTO>();
                    
        }
    }
}
