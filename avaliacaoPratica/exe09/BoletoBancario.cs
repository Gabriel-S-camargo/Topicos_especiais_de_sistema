public class BoletoBancario : IMetodoPagamento{

    public string tipoPagamento { get; set; }
    public double saldoConta { get; set; }
    public int tempoPagamento { get; set; }
    
    public BoletoBancario(double saldoConta, int tempoPagamento){
        this.tipoPagamento = "Boleto Bancário";
        this.saldoConta=saldoConta;
        this.tempoPagamento=tempoPagamento;
    }

    public void realizaPagamento(double valorPagamento){
        if(valorPagamento > this.saldoConta){
            Console.WriteLine("\nSaldo Insuficiente");

        }
        else{
            this.saldoConta -= valorPagamento;
            Console.WriteLine("\nPagamento realizado!\nSaldo Atual: " + this.saldoConta);
        }
    }

    public void statusPagamento(){
        Console.WriteLine("\nMetodo de pagamento: " + this.tipoPagamento);
        Console.WriteLine("Saldo atual: " + this.saldoConta);
        Console.WriteLine("tempo de pagamento: " + this.tempoPagamento);
    }
}