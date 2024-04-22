public class ContaPoupanca : iContaBancaria
{
    public int numConta { get; set; }
    public double saldo { get; set; }

    public ContaPoupanca(int numConta)
    {
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

    public double sacar(double valorSaque)
    {

        if (valorSaque > this.saldo)
        {
            Console.WriteLine("Saldo insuficiente para saque");
            return this.saldo;
        }
        else
        {
            Transacao transacao = new Transacao("Saque", valorSaque);
            this.saldo -= valorSaque;
            Console.WriteLine("Saque realizado! Saldo atual: " + this.saldo);
            return this.saldo;
        }

    }


}