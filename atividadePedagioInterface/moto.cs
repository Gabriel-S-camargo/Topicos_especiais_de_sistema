public class Moto : Iveiculo{
    public string Modelo { get; set; }
    public string Marca { get; set; }

    public double pagarPedagio(double preco){
        return preco * 0.5;
    }
}