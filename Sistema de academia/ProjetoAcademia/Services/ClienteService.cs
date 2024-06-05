using System;
using System.Collections.Generic;
using System.Linq;




public class ClienteService
{
    private readonly IRepository<Cliente> _clienteRepository;

    public ClienteService(IRepository<Cliente> clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void CreateCliente(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente));
        }

        _clienteRepository.Create(cliente);
    }

    public void UpdateCliente(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente));
        }

        _clienteRepository.Update(cliente);
    }

    public void DeleteCliente(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID do cliente deve ser maior que zero.");
        }

        _clienteRepository.Delete(id);
    }

    public Cliente GetClienteById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID do cliente deve ser maior que zero.");
        }

        return _clienteRepository.GetById(id);
    }

    public IEnumerable<Cliente> GetAllClientes()
    {
        return _clienteRepository.GetAll();
    }

    public IEnumerable<Cliente> SearchClientes(string filtro)
    {
        if (string.IsNullOrEmpty(filtro))
        {
            throw new ArgumentNullException(nameof(filtro));
        }

        var clientes = _clienteRepository.GetAll();

        return clientes.Where(c =>
            c.Nome.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            c.CPF.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            c.Email.Contains(filtro, StringComparison.InvariantCultureIgnoreCase));
    }
}

