// ./Turma.cs

public class Turma {
    public int anoFormacao{get;set;}
    public string turno{get;set;}
    public string sala{get;set;}

    // Propriedade 'estudantes' dentro da classe Turma que ira listar os objetos da classe Estudante
    // Prestar atenção na sintaxe
    public List<Estudante> estudantes = new List<Estudante>();

    // Criacao do Metodo adicionarEstudante que recebe um estudante e o
    // adiciona na lista de estudantes

    public void adicionarEstudante(Estudante e){
        this.estudantes.Add(e);
    }
}