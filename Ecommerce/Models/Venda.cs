using Ecommerce.Models.Enum;

namespace Ecommerce.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public string Itens { get; set; }
        Status StatusVenda { get; set; }
        Vendedor Vendedor { get; set; }
        DateTime DataVenda { get; set; }

    }
}
