public class ContaCorrente : ContaBancaria{
    public string cpf { get; set; }

    public ContaCorrente(int id, string nomeResponsavel, string cpf) : base(id, nomeResponsavel) { 
        this.cpf = cpf;
    }

    public  void mostrarInfo(){
        base.mostrarInfo();
        Console.WriteLine("CPF responsavel: " + this.cpf);
    }
}