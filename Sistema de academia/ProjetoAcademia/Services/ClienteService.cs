public class ClienteService
{
    private readonly Repository _repository;

    public ClienteService(Repository repository)
    {
        _repository = repository;
    }

    public void CreateCliente(Cliente cliente)
    {
        _repository.Create(cliente);
    }

    public Cliente GetClienteById(int id)
    {
        return _repository.GetById<Cliente>(id);
    }

    public Cliente GetClienteByCpf(string cpf)
    {
        return _repository.GetAll<Cliente>().FirstOrDefault(c => c.CPF == cpf);
    }

    public void UpdateCliente(Cliente cliente)
    {
        _repository.Update(cliente);
    }

    public void DeleteCliente(int id)
    {
        _repository.Delete<Cliente>(id);
    }

    public IEnumerable<Cliente> GetAllClientes()
    {
        return _repository.GetAll<Cliente>();
    }
}
