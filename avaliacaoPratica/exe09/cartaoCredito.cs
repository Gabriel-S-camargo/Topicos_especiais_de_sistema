public class CartaoCredito : IMetodoPagamento{

    public string tipoPagamento {get; set;}
    public double diasAtePagamento {get; set;}
    public double limiteCartao {get; set;}


    public CartaoCredito(double diasAtePagamento, double limiteCartao) {
        this.tipoPagamento = "Cartao de Credito";
        this.diasAtePagamento=diasAtePagamento;
        this.limiteCartao=limiteCartao;
    }

    public void realizaPagamento(double valorPagamento){
        if(valorPagamento > limiteCartao){
            Console.WriteLine("\nLimite insuficiente para compra");
        }
        else{
            this.limiteCartao -= valorPagamento;
            Console.WriteLine("\nPagemento realizado!\nLimite disponível: " + this.limiteCartao);
        }
    }
    public void statusPagamento(){
        Console.WriteLine("\nMetodo de Pagamento: " + this.tipoPagamento);
        Console.WriteLine("Limite atual: " + this.limiteCartao);
        Console.WriteLine("Dias para o pagamento da fatura: " + this.diasAtePagamento);
        
    } 
}