using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Repository
{
    private static Repository instance;
    private static readonly object lockObject = new object();

    private readonly DbContext dbContext;

    private Repository(DbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public static Repository GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Repository(new ApplicationDbContext());
                }
            }
        }
        return instance;
    }

    public IEnumerable<T> GetAll<T>() where T : class
    {
        return dbContext.Set<T>().ToList();
    }

    public T GetById<T>(int id) where T : class
    {
        return dbContext.Set<T>().Find(id);
    }

    public void Create<T>(T entity) where T : class
    {
        dbContext.Set<T>().Add(entity);
        dbContext.SaveChanges();
    }

    public void Update<T>(T entity) where T : class
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        dbContext.SaveChanges();
    }

    public void Delete<T>(int id) where T : class
    {
        var entity = dbContext.Set<T>().Find(id);
        dbContext.Set<T>().Remove(entity);
        dbContext.SaveChanges();
    }
}
