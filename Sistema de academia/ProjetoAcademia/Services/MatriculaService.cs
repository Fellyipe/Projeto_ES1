using System;
using System.Collections.Generic;
using System.Linq;


public class MatriculaService
{
    private readonly IRepository<Matricula> _matriculaRepository;
    private readonly IRepository<Cliente> _clienteRepository;
    private readonly IRepository<Personal> _personalRepository;

    public MatriculaService(
        IRepository<Matricula> matriculaRepository,
        IRepository<Cliente> clienteRepository,
        IRepository<Personal> personalRepository)
    {
        _matriculaRepository = matriculaRepository;
        _clienteRepository = clienteRepository;
        _personalRepository = personalRepository;
    }

    public void CreateMatricula(Matricula matricula)
    {
        if (matricula == null)
        {
            throw new ArgumentNullException(nameof(matricula));
        }

        if (matricula.ClienteId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(matricula.ClienteId), "ID do cliente deve ser maior que zero.");
        }

        if (matricula.PersonalId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(matricula.PersonalId), "ID do personal deve ser maior que zero.");
        }

        // Validações adicionais...

        _matriculaRepository.Create(matricula);
    }

    public void UpdateMatricula(Matricula matricula)
    {
        if (matricula == null)
        {
            throw new ArgumentNullException(nameof(matricula));
        }

        if (matricula.IdMatricula <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(matricula.IdMatricula), "ID da matrícula deve ser maior que zero.");
        }

        if (matricula.ClienteId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(matricula.ClienteId), "ID do cliente deve ser maior que zero.");
        }

        if (matricula.PersonalId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(matricula.PersonalId), "ID do personal deve ser maior que zero.");
        }

        // Validações adicionais...

        _matriculaRepository.Update(matricula);
    }

    public void DeleteMatricula(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID da matrícula deve ser maior que zero.");
        }

        _matriculaRepository.Delete(id);
    }

    public Matricula GetMatriculaById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID da matrícula deve ser maior que zero.");
        }

        var matricula = _matriculaRepository.GetById(id);

        if (matricula != null)
        {
            matricula.Cliente = _clienteRepository.GetById(matricula.ClienteId);
            matricula.Personal = _personalRepository.GetById(matricula.PersonalId);
        }

        return matricula;
    }

    public IEnumerable<Matricula> GetAllMatriculas()
    {
        var matriculas = _matriculaRepository.GetAll();

        foreach (var matricula in matriculas)
        {
            matricula.Cliente = _clienteRepository.GetById(matricula.ClienteId);
            matricula.Personal = _personalRepository.GetById(matricula.PersonalId);
        }

        return matriculas;
    }

    public IEnumerable<Matricula> SearchMatriculas(string filtro)
    {
        if (string.IsNullOrEmpty(filtro))
        {
            throw new ArgumentNullException(nameof(filtro));
        }

        var matriculas = _matriculaRepository.GetAll();

        return matriculas.Where(m =>
            m.Cliente.Nome.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            m.Personal.Nome.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            m.DataInicio.ToString("dd/MM/yyyy").Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            m.DataFim.ToString("dd/MM/yyyy").Contains(filtro, StringComparison.InvariantCultureIgnoreCase));
    }
}
