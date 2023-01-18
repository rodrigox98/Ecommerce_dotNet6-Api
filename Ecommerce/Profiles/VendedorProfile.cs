using AutoMapper;
using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;

namespace Ecommerce.Profiles
{
    public class VendedorProfile : Profile
    {
        public VendedorProfile()
        {
            CreateMap<CreateVendedorDTO, Vendedor>();
            CreateMap<Vendedor, ReadVendedorDTO>();
            CreateMap<UpdateVendedorDTO, Vendedor>();
        }
    }
}
