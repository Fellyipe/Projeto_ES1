class Dinheiro : IMetodoDePagamento
{
    public void RealizarPagamento(double valor)
    {
        // Implementação específica para pagamento em dinheiro
        Console.WriteLine($"Pagamento em dinheiro no valor de R${valor} concluído!");
    }
}