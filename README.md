- API REST utilizando .Net 6.
- Documentação swagger | Entity Framework | Microsoft SQL Server | AutoMapper
- Pattern: DTO(Data Transfer Object)
- A API Implementações: 

  1. Registra vendedor: Recebe dados pessoais do vendedor + Somatório de todas as vendas ligadas ao determinado vendedor. 
  2. Registrar venda: Recebe os dados do vendedor + itens vendidos + preço total da venda. Registra venda com status "Aguardando pagamento"; 
  3. Buscar venda: Busca pelo Id da venda; | Buscar Vendedor : Busca Pelo Id do vendedor.
  4. Retorna lista de todos os vendedores ou vendas.
  5. Atualizar venda: Permite que seja atualizado o status da venda.
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
  
  5. <a href="https://imgur.com/8cSxhAJ"><img src="https://i.imgur.com/8cSxhAJ.gif" title="source: imgur.com" /></a>
