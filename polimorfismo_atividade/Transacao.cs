public class Transacao{
    public string tipo;
    public double valorTransacao;

    public Transacao(string tipo, double valorTransacao){
        this.tipo = tipo;
        this.valorTransacao = valorTransacao;

        
    } 

    public void exibirInfo(){
        Console.WriteLine("Tipo da transacao: " + this.tipo);
        Console.WriteLine("Valor da transacao: " + this.valorTransacao);
    }

    

}