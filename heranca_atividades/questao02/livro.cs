public class Livro{

    public string titulo { get; set; }
    public int anoPublicacao{get; set; }

    public Livro(string titulo, int anoPublicacao){
        this.titulo = titulo;
        this.anoPublicacao = anoPublicacao;
    }

    public string getTitulo(){
        return this.titulo;
    }



}