public class Cliente
{
     private int id;
    private string nome;
    private string cpf;
    private string email;
    private DateTime dataNascimento;

    public int Id { get { return id; } set { id = value; } }
    public string Nome { get { return nome; } set { nome = value; } }
    public string CPF { get { return cpf; } set { cpf = value; } }
    public string Email { get { return email; } set { email = value; } }
    public DateTime DataNascimento { get { return dataNascimento; } set { dataNascimento = value; } }
}

