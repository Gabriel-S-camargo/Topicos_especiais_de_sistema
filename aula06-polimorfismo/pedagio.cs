
public class Pedagio{

    public string nome { get; set; }
    public double preco_eixo { get; set; }

    //Metodo de cobraca

    public bool cobrarPedagio(iVeiculo veiculo){        

        double preco_cobrado = veiculo.pagarPedagio(this.preco_eixo);

        Console.WriteLine(preco_cobrado);
    
        return true; // muleta
    }



}