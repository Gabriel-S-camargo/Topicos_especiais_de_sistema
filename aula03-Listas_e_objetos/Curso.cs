// ./Curso.cs

public class Curso{
    public string nome{get;set;}
    public int duracao{get;set;}
    public string area{get;set;}

    public List<Turma> turmas = new List<Turma>();

    public void adicionarTurma(Turma t){
        this.turmas.Add(t);
    }

}