- API REST utilizando .Net Core.
- Documentação swagger 
- A API Implementações:
  1. Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2. Buscar venda: Busca pelo Id da venda;
  3. Atualizar venda: Permite que seja atualizado o status da venda.
     3. 1 Possíveis status: 

| `Pagamento aprovado` | `Enviado para transportadora` | `Entregue` | `Cancelada` |
| -------------------- | ----------------------------- | ---------- | ----------- |
|                      |                               |            |             |

- 1. Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
  2. Verificação de venda com pelo menos 1 item;
  3. A atualização de status permite somente as seguintes transições:

     - **De:** `Aguardando pagamento ` **Para:** `Pagamento Aprovado`
     - **De**: `Aguardando pagamento`  **Para:** `Cancelada`
     - **De:** `Pagamento Aprovado  ` **Para:** `Enviado para Transportadora`
     - **De:** `Pagamento Aprovado  `**Para:** `Cancelada`
     - **De:** `Enviado para Transportador`. **Para:** `Entregue`
  
  4. ![GifEcommerce](C:\Users\rodri\Videos\GifEcommerce.gif)