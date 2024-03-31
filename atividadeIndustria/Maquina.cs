// Estrutura com atributos e metodos da classe "Máquina"

public class Maquina{

    public int id{get;set;}
    public string marca{get;set;} = string.Empty;
    public string modelo{get;set;} = string.Empty;

    public void exibirInfoMaquina(){
        Console.WriteLine("\nId maquina: " + this.id);
        Console.WriteLine("Marca: " + this.marca);
        Console.WriteLine("Modelo: " +this.modelo);
    }

    public void iniciarProducao(){
        Console.WriteLine("Iniciada a produção da maquina " + this.id);
    }

}