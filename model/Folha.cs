using Microsoft.Extensions.Options;

namespace Nicolas;

public class Folha
{

    public int FolhaID {get; set;}
    public double valor {get; set;}
    public int quantidade {get; set;}
    public int mes {get; set;}
    public int ano {get; set;}
    public double salarioBruto {get; set;}
    public double IRRF {get; set;}
    public double INSS {get; set;}
    public double FGTS {get; set;}
    public double salarioLiquido {get; set;}
    public Funcionario? Funcionario {get; set;}
}
