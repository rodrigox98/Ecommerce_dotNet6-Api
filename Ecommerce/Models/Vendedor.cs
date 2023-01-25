using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Vendedor
    {
        [Required, Key]
        public int VendedorId { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [StringLength(11, ErrorMessage = "Número deve ter obrigatoriamente 11 dígitos", MinimumLength = 11)]
        public string Telefone { get; set; }
        public float ValorTotalVendas { get; set; } 
        [JsonIgnore]
        public virtual List<Venda> Vendas { get; set; }
        

        public float CalcularTotalVendas()
        {
            return ValorTotalVendas = Vendas.Sum(venda => venda.ValorTotal);
        }
    }
}
