public class RepositoryFactory
{
    public static Repository CreateRepository()
    {
        var context = new ApplicationDbContext();
        return new Repository(context);
    }
}