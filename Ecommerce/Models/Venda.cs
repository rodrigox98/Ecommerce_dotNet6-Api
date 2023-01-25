using Ecommerce.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Venda
    {
        [Required, Key]
        public int VendaId{ get; set; }
        [Required]
        public string Itens { get; set; }
        [Required]
        public float ValorTotal { get; set; }
        [Required]
        public Status StatusVenda { get; set; }
        public int VendedorId { get; set; }
        [JsonIgnore]
        public virtual Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }





    }
}
