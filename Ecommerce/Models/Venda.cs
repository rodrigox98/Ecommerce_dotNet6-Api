using Ecommerce.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Venda
    {
        [Required, Key]
        public int IdVenda{ get; set; }
        [Required]
        public string Itens { get; set; }
        [Required]
        public Status StatusVenda { get; set; }
        [Required]
        public Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }

    }
}
