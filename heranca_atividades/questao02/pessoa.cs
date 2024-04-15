public class Pessoa {
    public string nome { get; set; }
    public string cpf { get; set; }
    public Livro livro;

    public Pessoa(string nome, string cpf){
        this.nome = nome;
        this.cpf = cpf;
    }


    public void adicionarLivro(Livro livro){
        this.livro = livro;

    }

    public void MostrarInfo(){
        Console.WriteLine("\nNome: " + this.nome);
        Console.WriteLine("\nCPF" + this.cpf);
        Console.WriteLine("Livro sendo lido: " + this.livro.titulo);
    }
    
    
}