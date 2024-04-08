public class Funcionario{
    public string cpf { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public double salario { get; set; }

    public double calcularBonus(){
        return this.salario * 0.5;
    }
}