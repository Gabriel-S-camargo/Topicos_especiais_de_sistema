public class Mototocicleta : iVeiculo{
    public string cilindrada { get; set; }

    public double pagarPedagio(double preco){
        return (preco * 0.5);
    }
}