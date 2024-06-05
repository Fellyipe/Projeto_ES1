public class PersonalService
{
    private readonly Repository _repository;

    public PersonalService(Repository repository)
    {
        _repository = repository;
    }

    public void CreatePersonal(Personal personal)
    {
        _repository.Create(personal);
    }

    public Personal GetPersonalById(int id)
    {
        return _repository.GetById<Personal>(id);
    }

    public void UpdatePersonal(Personal personal)
    {
        _repository.Update(personal);
    }

    public void DeletePersonal(int id)
    {
        _repository.Delete<Personal>(id);
    }

    public IEnumerable<Personal> GetAllPersonals()
    {
        return _repository.GetAll<Personal>();
    }
}
