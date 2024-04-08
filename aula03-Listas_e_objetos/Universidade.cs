// ./Universidade.cs
public class Universidade{
    public string nome{get;set;}
    public string localizacao{get;set;}
    public int anoFundacao{get;set;}
    public List<Curso> cursos = new List<Curso>();

    public void adicionarCurso(Curso c){
        this.cursos.Add(c);
    }


}