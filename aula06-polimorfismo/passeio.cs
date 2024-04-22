public class Passeio : iVeiculo{
    public string combustivel { get; set; }
    public int eixos { get; set; }

    public double pagarPedagio(double preco){
        return preco * 1;
    }
    
}