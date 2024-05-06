public class Filme
{
    public string titulo { get; set; }
    public string genero { get; set; }
    public string duracao { get; set; }
    public bool disponivel { get; set; }

    public Filme(string titulo, string genero, string duracao)
    {
        this.titulo = titulo;
        this.genero = genero;
        this.duracao = duracao;
        this.disponivel = true;
    }

    public string registrarEmprestimo()
    {
        if (this.disponivel == false)
        {
            return "Titulo indisponível";
        }
        else
        {
            this.disponivel = false;
            return "Emprestimo registrado";
        }
    }

    public string registrarDevolucao()
    {
        if (this.disponivel == true)
        {
            return "Este titulo nao esta emprestado, impossível retornar";
        }
        else
        {
            return "Titulo retornado";
        }
    }

    public string verificarTitulo()
    {
        if (this.disponivel == true)
        {
            return "Titulo disponivel para emprestimo";
        }
        else
        {

            return "Titulo indisponivel para emprestimo";
        }


    }
}