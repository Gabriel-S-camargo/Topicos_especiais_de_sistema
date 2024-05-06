public class Carro : Veiculo
{
    public int numPortas { get; set; }

    public Carro(int numPortas, string modelo, string marca) : base(marca, modelo)
    {
        this.numPortas = numPortas;
    }

    public void mostrarInfo()
    {
        base.mostrarInfo();
        Console.WriteLine("Numero de portas: " + this.numPortas);
    }
}