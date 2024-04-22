public class Caminhao : iVeiculo{
    public int eixos { get; set; }
    public string tipoCarga { get; set; }

    public double pagarPedagio(double preco){
        return preco * eixos;
    }

}


