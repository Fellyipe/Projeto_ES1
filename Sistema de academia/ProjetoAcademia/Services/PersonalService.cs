using System;
using System.Collections.Generic;
using System.Linq;


public class PersonalService
{
    private readonly IRepository<Personal> _personalRepository;

    public PersonalService(IRepository<Personal> personalRepository)
    {
        _personalRepository = personalRepository;
    }

    public void CreatePersonal(Personal personal)
    {
        if (personal == null)
        {
            throw new ArgumentNullException(nameof(personal));
        }

        _personalRepository.Create(personal);
    }

    public void UpdatePersonal(Personal personal)
    {
        if (personal == null)
        {
            throw new ArgumentNullException(nameof(personal));
        }

        _personalRepository.Update(personal);
    }

    public void DeletePersonal(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID do personal deve ser maior que zero.");
        }

        _personalRepository.Delete(id);
    }

    public Personal GetPersonalById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID do personal deve ser maior que zero.");
        }

        return _personalRepository.GetById(id);
    }

    public IEnumerable<Personal> GetAllPersonals()
    {
        return _personalRepository.GetAll();
    }

    public IEnumerable<Personal> SearchPersonals(string filtro)
    {
        if (string.IsNullOrEmpty(filtro))
        {
            throw new ArgumentNullException(nameof(filtro));
        }

        var personals = _personalRepository.GetAll();

        return personals.Where(p =>
            p.Nome.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            p.CPF.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) ||
            p.Email.Contains(filtro, StringComparison.InvariantCultureIgnoreCase));
    }
}
