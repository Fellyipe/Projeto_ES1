public class Personal
{
    private int id;
    private string nome;
    private DateTime dataNascimento;
    private string ctps;
    private string cpf;
    private string cargo;
    private string telefone;
    private string email;
    private DateTime dataContratacao;
    private double salario;
    private string endereco;

    public int Id { get { return id; } set { id = value; } }
    public string Nome { get { return nome; } set { nome = value; } }
    public DateTime DataNascimento { get { return dataNascimento; } set { dataNascimento = value; } }
    public string CTPS { get { return ctps; } set { ctps = value; } }
    public string CPF { get { return cpf; } set { cpf = value; } }
    public string Cargo { get { return cargo; } set { cargo = value; } }
    public string Telefone { get { return telefone; } set { telefone = value; } }
    public string Email { get { return email; } set { email = value; } }
    public DateTime DataContratacao { get { return dataContratacao; } set { dataContratacao = value; } }
    public double Salario { get { return salario; } set { salario = value; } }
    public string Endereco { get { return endereco; } set { endereco = value; } }
}
