public class Veiculo{
    public string modelo { get; set; }
    public string marca { get; set; }
    
    public Veiculo(string modelo, string marca){
        this.modelo = modelo;
        this.marca = marca;
    }
    public void mostrarInfo(){
        Console.WriteLine("Modelo: " + this.modelo);
        Console.WriteLine("Marca: " + this.marca);
    }
}