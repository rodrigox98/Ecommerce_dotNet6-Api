using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs.VendedorDTO
{
    public class ReadVendedorDTO
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
        public virtual List<Venda> Vendas { get; set; }
    }
}
