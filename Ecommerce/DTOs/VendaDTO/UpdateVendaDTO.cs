using Ecommerce.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs.VendaDTO
{
    public class UpdateVendaDTO
    {
        [Required]
        public Status StatusVenda { get; set ; }
    }
}
