class PIX : IMetodoDePagamento
{
    public void RealizarPagamento(double valor)
    {
        // Implementação específica para pagamento via PIX
        Console.WriteLine($"Pagamento via PIX no valor de R${valor} concluído!");
    }
}