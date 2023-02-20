using Ecommerce.DTOs.VendaDTO;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Ecommerce.Models.Enum
{
    public class EnumVerification
    {

        /// <summary>
        /// Verifica as regras de negócio para o Update do Status.
        /// </summary>
        /// <param name="venda"></param>
        /// <param name="update"></param>
        /// <returns><see cref="true"/> Se o status é inválido, conforme regra de negócio.</returns>
        /// <exception cref="Exception"></exception>
        public bool IsStatusInvalide(Venda venda, UpdateVendaDTO update)
        {

            if (venda.StatusVenda == Status.AguardandoPagamento && (update.StatusVenda == Status.EnviadoParaTransportadora
                || update.StatusVenda == Status.Entregue || update.StatusVenda == Status.AguardandoPagamento))
            {
                throw new Exception("Só é possível atualizar para Pagamento Aprovado ou Cancelada");
                return true;
            }
            if (venda.StatusVenda == Status.PagamentoAprovado && (update.StatusVenda == Status.PagamentoAprovado
                || update.StatusVenda == Status.Entregue || update.StatusVenda == Status.AguardandoPagamento))
            {
                throw new Exception("Só é possível atualizar para Enviado para Transportadora ou Cancelada");
                return true;
            }
            if (venda.StatusVenda == Status.EnviadoParaTransportadora && update.StatusVenda != Status.Entregue)
            {
                throw new Exception("Só é possível atualizar para Entregue ");
                return true;
            }
            if (venda.StatusVenda == Status.Entregue && update.StatusVenda != Status.Entregue)
            {
                throw new Exception("Venda entregue, não é mais possível atualizar.");
            }
            if (venda.StatusVenda == Status.Cancelada && update.StatusVenda != Status.Cancelada)
            {
                throw new Exception("Venda cancelada, não é possível atualizar");
            }
            return false;
        }
    }
}
