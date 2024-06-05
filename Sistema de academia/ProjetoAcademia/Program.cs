using System;

namespace ProjetoAcademia
{
  class Program
  {
    private MatriculaService _matriculaService; // Matricula service
    private PersonalService _personalService; // Personal service

    public Program(MatriculaService matriculaService, PersonalService personalService)
    {
      _matriculaService = matriculaService;
      _personalService = personalService;
    }

    static void Main(string[] args)
    {
      // Create repositories
      var repository = RepositoryFactory.CreateRepository();
      var clienteService = new ClienteService(repository); // Assuming ClienteRepository exists

      // Create services with repositories
      var matriculaService = new MatriculaService(repository, clienteService); // Pass both repositories
      var personalService = new PersonalService(repository);

      // Create and start the program instance
      var program = new Program(matriculaService, personalService);
      program.MenuPrincipal();
    }


    private void MenuPrincipal()
    {
      while (true)
      {
        Console.WriteLine("[0] Fechar");
        Console.WriteLine("[1] Gerenciar Matrículas");
        Console.WriteLine("[2] Gerenciar Personal");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
          case "0":
            Console.WriteLine("Programa Encerrado!");
            Environment.Exit(0);
            break;
          case "1":
            GerenciarMatriculas();
            break;
          case "2":
            GerenciarPersonal();
            break;
          default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
        }
      }
    }

    private void GerenciarMatriculas()
    {
      while (true)
      {
        Console.WriteLine("[0] Voltar");
        Console.WriteLine("[1] Matricular Aluno");
        Console.WriteLine("[2] Renovar Matrícula"); // Assuming renewal instead of update
        Console.WriteLine("[3] Cancelar Matrícula");
        Console.WriteLine("[4] Listar Matrículas");
        Console.WriteLine("[5] Buscar Matrícula");
        string opcaoMatricula = Console.ReadLine();

        switch (opcaoMatricula)
        {
          case "0":
            return;
          case "1":
            MatricularAluno();
            break;
          case "2":
            RenovarMatricula();
            break;
          case "3":
            CancelarMatricula();
            break;
          case "4":
            ListarMatriculas();
            break;
          case "5":
            BuscarMatricula();
            break;
          default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
        }
      }
    }

    private void MatricularAluno()
    {
      // Get student (cliente) information
      Console.WriteLine("CPF do Cliente: ");
      string cpf = Console.ReadLine();
      var cliente = MatriculaService.clienteService.GetClienteByCpf(cpf);

      if (cliente == null)
      {
        // Cliente not found, ask if user wants to create a new one
        Console.WriteLine("Cliente não encontrado. Deseja criar um novo cliente? (s/n)");
        string criarCliente = Console.ReadLine().ToLower();
        if (criarCliente == "s")
        {
          // Implement logic to create a new cliente
          // ... (create cliente and get the created object)
          cliente = /* created cliente object */;
        }
        else
        {
          Console.WriteLine("Matrícula cancelada.");
          return;
        }
      }

      // Get personal information
      Console.WriteLine("ID do Personal: ");
      int idPersonal = int.Parse(Console.ReadLine());
      var personal = _personalService.GetPersonalById(idPersonal);

      if (personal == null)
      {
        Console.WriteLine("Personal não encontrado.");
        return;
      }

      // Get Matricula details
      Console.WriteLine("Data de Início (dd/MM/yyyy): ");
      DateTime dataInicio = DateTime.Parse(Console.ReadLine());
      Console.WriteLine("Valor Mensal: ");
      double valorMensal = double.Parse(Console.ReadLine());

      // Get payment method information (assuming an interface for payment)
      IMetodoDePagamento metodoPagamento;
      // ... (Implement logic to get the payment method object)

      // Create a Matricula object
      var matricula = new Matricula
      {
        DataInicio = dataInicio,
        DataFim = null, // Initially set to null for active matrículas
        ValorMensal = valorMensal,
        Cliente = cliente,
        ClienteId = cliente.Id,
        Personal = personal,
        PersonalId = idPersonal
      };

      // Call MatriculaService.CriarMatricula to save the Matricula
      try
      {
        _matriculaService.CriarMatricula(matricula, cliente, metodoPagamento);
        Console.WriteLine("Matrícula realizada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Erro ao criar matrícula");
      }
    }
    private void RenovarMatricula()
    {
      // Get Matricula ID from the user
      Console.WriteLine("ID da Matrícula: ");
      int matriculaId = int.Parse(Console.ReadLine());

      // Get new end date and value from the user
      Console.WriteLine("Nova Data de Término (dd/MM/yyyy): ");
      DateTime novaDataFim = DateTime.Parse(Console.ReadLine());
      Console.WriteLine("Novo Valor Mensal: ");
      double novoValor = double.Parse(Console.ReadLine());

      // Get payment method information (assuming an interface for payment)
      IMetodoDePagamento metodoPagamento;
      try
      {
        // ... (Implement logic to get the payment method object)
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erro ao obter método de pagamento: {ex.Message}");
        return; // Stop if payment method retrieval fails
      }

      try
      {
        _matriculaService.RenovarMatricula(matriculaId, novaDataFim, novoValor, metodoPagamento);
        Console.WriteLine("Matrícula renovada com sucesso!");
      }
      catch (Exception ex)
      {
        // Handle specific exceptions if needed (e.g., Matricula não encontrada)
        Console.WriteLine($"Erro ao renovar matrícula: {ex.Message}");
      }
    }

    private void CancelarMatricula()
    {
      // Get Matricula ID from the user
      Console.WriteLine("ID da Matrícula: ");
      int matriculaId = int.Parse(Console.ReadLine());

      // Call MatriculaService.DeleteMatricula to delete the Matricula
      try
      {
        _matriculaService.DeleteMatricula(matriculaId);
        Console.WriteLine("Matrícula cancelada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erro ao cancelar matrícula: {ex.Message}");
      }
    }

    private void ListarMatriculas()
    {
      // Get all Matriculas from the MatriculaService
      var matriculas = _matriculaService.GetAllMatriculas();

      // Display the list of Matriculas to the user
      Console.WriteLine("Lista de Matriculas:");
      if (matriculas.Any()) // Check if there are any Matriculas before iterating
      {
        foreach (var matricula in matriculas)
        {
          Console.WriteLine($"ID: {matricula.IdMatricula}");
          Console.WriteLine($"Cliente: {matricula.Cliente.Nome}");
          Console.WriteLine($"Personal: {matricula.Personal.Nome}");
          Console.WriteLine($"Data de Início: {matricula.DataInicio:dd/MM/yyyy}");
          Console.WriteLine($"Data de Término: {matricula.DataFim?.ToString("dd/MM/yyyy") ?? "Ativa"}");
          Console.WriteLine($"Valor Mensal: R${matricula.ValorMensal:F2}");
          Console.WriteLine("------------------------------------");
        }
      }
      else
      {
        Console.WriteLine("Nenhuma matrícula cadastrada.");
      }
    }

    private void BuscarMatricula()
    {
      // Get Matricula ID from the user
      Console.WriteLine("ID da Matrícula: ");
      int matriculaId = int.Parse(Console.ReadLine());

      // Get the Matricula from the MatriculaService
      var matricula = _matriculaService.GetMatriculaById(matriculaId);

      // If Matricula found, display it to the user
      if (matricula != null)
      {
        Console.WriteLine("Matrícula encontrada:");
        Console.WriteLine($"ID: {matricula.IdMatricula}");
        Console.WriteLine($"Cliente: {matricula.Cliente.Nome}");
        Console.WriteLine($"Personal: {matricula.Personal.Nome}");
        Console.WriteLine($"Data de Início: {matricula.DataInicio:dd/MM/yyyy}");
        Console.WriteLine($"Data de Término: {matricula.DataFim?.ToString("dd/MM/yyyy") ?? "Ativa"}");
        Console.WriteLine($"Valor Mensal: R${matricula.ValorMensal:F2}");
      }
      else
      {
        Console.WriteLine("Matrícula não encontrada.");
      }
    }


    private void GerenciarPersonal()
    {
      while (true)
      {
        Console.WriteLine("[0] Voltar");
        Console.WriteLine("[1] Cadastrar Personal");
        Console.WriteLine("[2] Atualizar Personal");
        Console.WriteLine("[3] Deletar Personal");
        Console.WriteLine("[4] Listar Personal");
        Console.WriteLine("[5] Buscar Personal");
        string opcaoPersonal = Console.ReadLine();

        switch (opcaoPersonal)
        {
          case "0":
            return;
          case "1":
            CadastrarPersonal();
            break;
          case "2":
            AtualizarPersonal();
            break;
          case "3":
            DeletarPersonal();
            break;
          case "4":
            ListarPersonal();
            break;
          case "5":
            BuscarPersonal();
            break;
          default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
        }
      }
    }
    private void CadastrarPersonal()
    {
      // Get personal information from the user
      Console.WriteLine("Nome: ");
      string nome = Console.ReadLine();

      Console.WriteLine("Data de Nascimento (dd/MM/yyyy): ");
      DateTime dataNascimento = DateTime.Parse(Console.ReadLine()); // Assuming valid format

      Console.WriteLine("CTPS: ");
      string ctps = Console.ReadLine();

      Console.WriteLine("CPF: ");
      string cpf = Console.ReadLine();

      Console.WriteLine("Cargo: ");
      string cargo = Console.ReadLine();

      Console.WriteLine("Telefone: ");
      string telefone = Console.ReadLine();

      Console.WriteLine("Email: ");
      string email = Console.ReadLine();

      Console.WriteLine("Data de Contratação (dd/MM/yyyy): ");
      DateTime dataContratacao = DateTime.Parse(Console.ReadLine()); // Assuming valid format

      Console.WriteLine("Salario: ");
      double salario = double.Parse(Console.ReadLine()); // Assuming valid input

      Console.WriteLine("Endereço: ");
      string endereco = Console.ReadLine();

      // Create a Personal object with the information
      var personal = new Personal
      {
        Nome = nome,
        DataNascimento = dataNascimento,
        CTPS = ctps,
        CPF = cpf,
        Cargo = cargo,
        Telefone = telefone,
        Email = email,
        DataContratacao = dataContratacao,
        Salario = salario,
        Endereco = endereco
      };

      // Call PersonalService.CreatePersonal to save the personal
      _personalService.CreatePersonal(personal);

      Console.WriteLine("Personal cadastrado com sucesso!");
    }

    private void AtualizarPersonal()
    {
      // Get personal ID from the user
      Console.WriteLine("ID do Personal: ");
      int id = int.Parse(Console.ReadLine());

      // Get the personal information to update from the user (optional update)
      Console.WriteLine("Novo Nome (ou deixe em branco para manter): ");
      string novoNome = Console.ReadLine();

      Console.WriteLine("Nova Data de Nascimento (ou deixe em branco para manter - dd/MM/yyyy): ");
      DateTime? novaDataNascimento = null; // Nullable DateTime
      if (!String.IsNullOrEmpty(Console.ReadLine()))
      {
        novaDataNascimento = DateTime.Parse(Console.ReadLine());
      }

      // ... (get other information to update using similar logic with null handling)

      // Create a Personal object with the updated information
      var personal = new Personal
      {
        Id = id,
        Nome = String.IsNullOrEmpty(novoNome) ? _personalService.GetPersonalById(id).Nome : novoNome, // Use existing name if not updated
        DataNascimento = novaDataNascimento ?? _personalService.GetPersonalById(id).DataNascimento, // Use existing date if not updated
                                                                                                    // ... (update other properties with null handling)
      };

      // Call PersonalService.UpdatePersonal to update the personal
      _personalService.UpdatePersonal(personal);

      Console.WriteLine("Personal atualizado com sucesso!");
    }

    private void DeletarPersonal()
    {
      // Get personal ID from the user
      Console.WriteLine("ID do Personal: ");
      int id = int.Parse(Console.ReadLine());

      // Call PersonalService.DeletePersonal to delete the personal
      _personalService.DeletePersonal(id);

      Console.WriteLine("Personal deletado com sucesso!");
    }

    private void ListarPersonal()
    {
      // Get all personal from the PersonalService
      var personals = _personalService.GetAllPersonals();

      // Display the list of personals to the user
      Console.WriteLine("Lista de Personals:");
      if (personals.Any()) // Check if there are any personals before iterating
      {
        foreach (var personal in personals)
        {
          Console.WriteLine($"ID: {personal.Id} - Nome: {personal.Nome}");
        }
      }
      else
      {
        Console.WriteLine("Nenhum personal cadastrado.");
      }
    }

    private void BuscarPersonal()
    {
      // Get personal ID from the user
      Console.WriteLine("ID do Personal: ");
      int id = int.Parse(Console.ReadLine());

      // Get the personal from the PersonalService
      var personal = _personalService.GetPersonalById(id);

      // If personal found, display it to the user
      if (personal != null)
      {
        Console.WriteLine($"Personal encontrado:");
        Console.WriteLine($"ID: {personal.Id} - Nome: {personal.Nome}");
        Console.WriteLine($"Data de Nascimento: {personal.DataNascimento:dd/MM/yyyy}");
        Console.WriteLine($"CTPS: {personal.CTPS}");
        Console.WriteLine($"CPF: {personal.CPF}");
        Console.WriteLine($"Cargo: {personal.Cargo}");
        Console.WriteLine($"Telefone: {personal.Telefone}");
        Console.WriteLine($"Email: {personal.Email}");
        Console.WriteLine($"Data de Contratação: {personal.DataContratacao:dd/MM/yyyy}");
        Console.WriteLine($"Salario: R${personal.Salario:F2}");
        Console.WriteLine($"Endereço: {personal.Endereco}");
      }
      else
      {
        Console.WriteLine("Personal não encontrado.");
      }
    }
  }
}