public class ContaPoupanca : ContaBancaria{
    public double juros { get; set; }

    public ContaPoupanca(int id, string nomeResponsavel, double juros) : base(id, nomeResponsavel){
        this.juros = juros;
    }

    public void mostrarInfo(){
        base.mostrarInfo();
        Console.WriteLine("Juros de rendimento Mensal: " + this.juros);
    }

    public double calcularJuros(){
        double valorRendimento = this.saldo * (this.juros / 100);

        return valorRendimento;
    }
}