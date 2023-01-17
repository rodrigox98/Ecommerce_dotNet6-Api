using Ecommerce.Models.Enum;
using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecommerce.DTOs.VendaDTO
{
    public class ReadVendaDTO
    {
        [Required, Key]
        public int VendaId { get; set; }
        [Required]
        public string Itens { get; set; }
        [Required]
        public Status StatusVenda { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
