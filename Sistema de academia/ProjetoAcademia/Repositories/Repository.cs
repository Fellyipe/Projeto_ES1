using System;
using System.Collections.Generic;

namespace ProjetoAcademia
{
    public class Repository
    {
        private readonly string connectionString;

        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create<T>(T entity) where T : class
        {
            // Implementação do método Create
        }

        public T Read<T>(int id) where T : class
        {
            // Implementação do método Read
        }

        public void Update<T>(T entity) where T : class
        {
            // Implementação do método Update
        }

        public void Delete<T>(int id) where T : class
        {
            // Implementação do método Delete
        }

        public IEnumerable<T> ListAll<T>() where T : class
        {
            // Implementação do método ListAll
        }
    }
}
