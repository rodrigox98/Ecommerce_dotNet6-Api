using AutoMapper;
using Ecommerce.DTOs.VendaDTO;
using Ecommerce.Models;

namespace Ecommerce.Profiles
{
    public class VendaProfile : Profile
    {
        public VendaProfile()
        {
            CreateMap<CreateVendaDTO, Venda>();
        }
    }
}
