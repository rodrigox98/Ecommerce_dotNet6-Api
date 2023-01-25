using Ecommerce.Models.Enum;
using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs.VendaDTO
{
    public class CreateVendaDTO
    {
        [Required]
        public string Itens { get; set; }
        [Required]
        public float ValorTotal { get; set; }
        [Required]
        public int VendedorId { get; set; }
        public DateTime DataVenda { get; set; }
        
    }
}
