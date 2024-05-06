public class ContaBancaria{
    public int id { get; set; }
    public string nomeResponsavel { get; set; }
    public double saldo{ get; set; }

    public ContaBancaria(int id, string nomeResponsavel){
        this.id = id;
        this.nomeResponsavel = nomeResponsavel;
        this.saldo = 0;
    }

    public void mostrarInfo(){
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Nome do responsavel: " + this.nomeResponsavel);
        Console.WriteLine("Saldo: " + this.saldo);
    }

    public string deposito(double valorDeposito){
        this.saldo += valorDeposito;

        return "Deposito realizado com sucesso";
    }

    public virtual string saque(double valorSaque){
        if(this.saldo < valorSaque){
            return "Saldo Indisponivel para saque";
        }else{
            this.saldo -= valorSaque;
            return "Saque realizado";
        }
    }
}