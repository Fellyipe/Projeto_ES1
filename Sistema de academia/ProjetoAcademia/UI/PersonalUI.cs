public class PersonalUI
{
    private readonly PersonalService _personalService;

    public PersonalUI(PersonalService personalService)
    {
        _personalService = personalService;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu de Pessoal");
            Console.WriteLine("------------------");
            Console.WriteLine("1. Listar Pessoal");
            Console.WriteLine("2. Adicionar Pessoal");
            Console.WriteLine("3. Atualizar Pessoal");
            Console.WriteLine("4. Remover Pessoal");
            Console.WriteLine("5. Voltar ao Menu Principal");
            Console.WriteLine();
            Console.Write("Digite sua opção: ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListPersonal();
                    break;
                case 2:
                    AddPersonal();
                    break;
                case 3:
                    UpdatePersonal();
                    break;
                case 4:
                    DeletePersonal();
                    break;
                case 5:
                    return; // Exit the Personal menu
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private void ListPersonal()
    {
        // Fetch and display a list of all Personal records
    }

    private void AddPersonal()
    {
        // Get user input to create a new Personal record and add it to the service
    }

    private void UpdatePersonal()
    {
        // Get user input to identify a Personal record to update and modify its details
    }

    private void DeletePersonal()
    {
        // Get user input to identify a Personal record to delete and remove it from the service
    }
}
