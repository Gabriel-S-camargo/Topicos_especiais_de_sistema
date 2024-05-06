public class Moto : Veiculo{
    public int cilindrada { get; set; }
    public Moto(int cilindrada, string modelo, string marca) : base(modelo, marca)
    {
        this.cilindrada = cilindrada;
    }
    public void mostrarInfo()
    {
        base.mostrarInfo();  
        Console.WriteLine("Cilindrada: " + this.cilindrada);
    }
}