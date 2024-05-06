public class Aluno : Curso
{
    public String Nome{get;set;}
    public double nota1{get;set;}
    public double nota2{get;set;}
    public Aluno(String nome,String lingua,String Tipo, double nota1, double nota2): base(nome,Tipo, nota1, nota2){
    }

    public void mostar(){
        Console.WriteLine("Aluno : "+Nome);
        Console.WriteLine("Nota 1 : "+base.nota1);
        Console.WriteLine("Nota 2 : "+base.nota2);
    }
}