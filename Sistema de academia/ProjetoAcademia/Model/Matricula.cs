public class Matricula
{
	private int idMatricula;

	private Cliente cliente;

	private Personal personal;

	private DateTime dataInicio;

	private DateTime dataFim;

	private double valor;

	public void realizarMatricula()
	{

	}
	public int IdMatricula { get { return idMatricula; } }
	public int ClienteId { get { return cliente.Id; } }
  public int PersonalId { get { return personal.Id; } }
}

