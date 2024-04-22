public class ContaCorrente : iContaBancaria{
    public int numConta { get; set; }
    public double saldo { get; set; }

    public ContaCorrente(int numConta){
        this.numConta = numConta;
        this.saldo = 0;
    }

    // metodos

    public double depositar(double valorDeposito)
    {

        this.saldo += valorDeposito;

        Console.WriteLine("Deposito realizado! Saldo atual = " + this.saldo);

        return this.saldo;
    }

    public String varteste = "teste";
    public double sacar(double valorSaque)
    {

        if (valorSaque > this.saldo)
        {
            Console.WriteLine("Saldo insuficiente para saque");
            return this.saldo;
        }
        else
        {
            this.saldo -= valorSaque;
            Console.WriteLine("Saque realizado! Saldo atual: " + this.saldo);
            return this.saldo;
        }

    }


}