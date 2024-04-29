public class Caminhao : Iveiculo {
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public int quantidadeEixo { get; set; }

    public double pagarPedagio(double preco){
        return preco * this.quantidadeEixo;
    }
}