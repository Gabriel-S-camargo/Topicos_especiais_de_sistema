public class SistemaPagamento{
    public string nomeConta { get; set; }
    public double valorDaConta  { get; set; }
    public bool situacaoPagamentoConta { get; set; }

    public SistemaPagamento(string nomeConta, double valorDaConta) {
        this.nomeConta = nomeConta;
        this.valorDaConta = valorDaConta;
    }

    public void pagarConta(IMetodoPagamento metodoPagamento){
        metodoPagamento.realizaPagamento(this.valorDaConta);
        this.situacaoPagamentoConta = true;
    }

    public  string situacaoPagamento(){
        if(this.situacaoPagamentoConta == true){
            return "Conta ja foi paga";
        }
        else{
            return "Conta ainda não foi paga";
        }
    }
}