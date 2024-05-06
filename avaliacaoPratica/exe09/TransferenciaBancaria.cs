public class TransferenciaBancaria : IMetodoPagamento
{

    public string tipoPagamento { get; set; }
    public double saldoConta { get; set; }
    public double taxaIof { get; set; }

    public TransferenciaBancaria(double saldoConta, double taxaIof)
    {
        this.tipoPagamento = "Transferência Bancária";
        this.saldoConta = saldoConta;
        this.taxaIof = taxaIof;
    }

    public void realizaPagamento(double valorPagamento)
    {
        if (valorPagamento > this.saldoConta)
        {
            Console.WriteLine("\nSaldo Insuficiente");

        }
        else
        {
            double taxaPagamento = valorPagamento * (this.taxaIof / 100);
            this.saldoConta -= valorPagamento + taxaPagamento;
            Console.WriteLine("\nPagamento realizado!\nSaldo Atual: " + this.saldoConta);
            Console.WriteLine("Taxa Paga: " + taxaPagamento);
        }

    }

    public void statusPagamento(){
        Console.WriteLine("\nMetodo de Pagamento: " +this.tipoPagamento);
        Console.WriteLine("Saldo atual: " +this.saldoConta);
        Console.Write("Taxa IOF: " +this.taxaIof + "%");
    }

}