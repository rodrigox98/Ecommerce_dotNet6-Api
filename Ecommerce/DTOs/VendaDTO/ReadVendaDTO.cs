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
        public string Itens { get; set; }
        public float ValorTotal { get; set; }
        public Status StatusVenda { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
