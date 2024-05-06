public class Bicicleta : Veiculo
{
    public int numMarchas { get; set; }

    public Bicicleta(int numMarchas, string modelo, string marca) : base(modelo, marca)
    {
        this.numMarchas = numMarchas;
    }

    public void mostrarInfo()
    {
        base.mostrarInfo();
        Console.WriteLine("Numero de marchas: " + this.numMarchas);
    }
}