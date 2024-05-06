public class ContaEmpresarial : ContaBancaria{
    public double saldoMinimo { get; set; }

    public ContaEmpresarial(int id, string nomeResponsavel, double saldoMinimo) : base(id, nomeResponsavel){
        this.saldoMinimo = saldoMinimo;
        this.saldo = saldoMinimo;
    } 

    public void mostrarInfo(){
        base.mostrarInfo();
        Console.WriteLine("Saldo Minimo de conta: " + this.saldoMinimo);
    }

    public override string saque(double valorSaque){
        
        double saldoTemp = this.saldo - valorSaque;

        if(saldoTemp < this.saldoMinimo){
            return "Operação abaixo do saldo minimo";
        }
        else{
            this.saldo = saldoTemp;

            return "Operacao realizada";
        }


        
    }
}