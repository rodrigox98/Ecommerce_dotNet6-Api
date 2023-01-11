using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Vendedor
    {
        [Required, Key]
        public int IdVendedor { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [StringLength(11, ErrorMessage = "Número deve ter obrigatoriamente 11 dígitos", MinimumLength = 11)]
        public string Telefone { get; set; }

    }
}
