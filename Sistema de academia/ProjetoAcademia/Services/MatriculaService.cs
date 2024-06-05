public class MatriculaService
{
    private readonly Repository _repository;
    private readonly ClienteService _clienteService;

    public MatriculaService(Repository repository, ClienteService clienteService)
    {
        _repository = repository;
        _clienteService = clienteService;
    }

    public void CriarMatricula(Matricula matricula, Cliente cliente, IMetodoDePagamento metodoDePagamento)
    {
        // Verificar se o cliente já existe pelo CPF
        var clienteExistente = _clienteService.GetClienteByCpf(cliente.CPF);
        if (clienteExistente == null)
        {
            // Criar novo cliente
            _clienteService.CreateCliente(cliente);
            clienteExistente = cliente; // Novo cliente criado
        }

        // Associar o cliente existente à matrícula
        matricula.ClienteId = clienteExistente.Id;
        matricula.Cliente = clienteExistente;

        // Realizar o pagamento
        metodoDePagamento.RealizarPagamento(matricula.ValorMensal);

        // Criar a matrícula
        CreateMatricula(matricula);
    }

    public void RenovarMatricula(int matriculaId, DateTime novaDataFim, double valor, IMetodoDePagamento metodoDePagamento)
    {
        var matricula = _repository.GetById<Matricula>(matriculaId);
        if (matricula == null)
        {
            throw new Exception("Matrícula não encontrada.");
        }

        // Atualizar a data de fim da matrícula
        matricula.DataFim = novaDataFim;

        // Realizar o pagamento
        metodoDePagamento.RealizarPagamento(valor);
        UpdateMatricula(matricula);
    }

    public void CreateMatricula(Matricula matricula)
    {
        _repository.Create(matricula);
    }

    public Matricula GetMatriculaById(int id)
    {
        return _repository.GetById<Matricula>(id);
    }

    public void UpdateMatricula(Matricula matricula)
    {
        _repository.Update(matricula);
    }

    public void DeleteMatricula(int id)
    {
        _repository.Delete<Matricula>(id);
    }

    public IEnumerable<Matricula> GetAllMatriculas()
    {
        return _repository.GetAll<Matricula>();
    }

    public IEnumerable<Matricula> GetMatriculasByClienteId(int clienteId)
{
    return _repository.GetAll<Matricula>().Where(m => m.ClienteId == clienteId);
}

}
