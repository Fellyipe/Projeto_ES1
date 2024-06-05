using System.Configuration;

class Cartao : IMetodoDePagamento
{
    public void RealizarPagamento(double valor)
    {
        // Implementação específica para pagamento com cartão
        Console.WriteLine($"Pagamento com cartão no valor de R${valor} concluído!");
    }
}
