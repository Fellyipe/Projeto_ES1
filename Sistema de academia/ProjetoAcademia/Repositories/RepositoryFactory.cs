public class RepositoryFactory
{
    private static Repository repositoryInstance;

    public static Repository CreateRepository()
    {
        if (repositoryInstance == null)
        {
            repositoryInstance = Repository.GetInstance();
        }
        return repositoryInstance;
    }
}
