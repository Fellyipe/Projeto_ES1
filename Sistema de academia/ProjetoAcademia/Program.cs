using System;

namespace ProjetoAcademia
{
  class Program
  {
    static void Main(string[] args)
    {
      // Create repository instance (assuming RepositoryFactory creates it)
      var repository = RepositoryFactory.CreateRepository();

      // Get the AcademiaManager singleton instance
      var academiaManager = AcademiaManager.Instance;

      // Start the application using the singleton instance
      academiaManager.MenuPrincipal();
    }
  }
}
