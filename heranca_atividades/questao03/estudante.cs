public class Estudante{
    public string matricula { get; set; }
    public string nomeEstudante { get; set; }
    public int idade { get; set; }


    public Estudante(string matricula, string nomeEstudante, int idade){
        this.matricula = matricula;
        this.nomeEstudante = nomeEstudante;
        this.idade = idade;
    }

    public void mostrarInfo(){
        Console.WriteLine("\nNome: " + this.nomeEstudante);
        Console.WriteLine("\nIdade: " + this.idade);
        Console.WriteLine("\nMatricula: " + this.matricula);
    }
}