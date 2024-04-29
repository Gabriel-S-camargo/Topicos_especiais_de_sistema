public class Pedagio{
    public string nomePedagio { get; set; }
    public double valorEixo { get; set; }

    public string cobrarPedagio(Iveiculo veiculo){
        double valorASerCobrado = veiculo.pagarPedagio(this.valorEixo);

        return "Valor Pago: " + valorASerCobrado;
    }
}