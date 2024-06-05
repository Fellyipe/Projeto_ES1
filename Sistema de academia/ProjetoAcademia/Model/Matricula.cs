using System.ComponentModel.DataAnnotations.Schema;

public class Matricula
{
	public int IdMatricula { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public double ValorMensal { get; set; }

    [NotMapped]
    public Cliente Cliente { get; set; }
    
    [NotMapped]
    public Personal Personal { get; set; }

    public int ClienteId { get; set; }
    public int PersonalId { get; set; }
}


