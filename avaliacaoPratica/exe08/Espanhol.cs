public class Espanhol : Curso
{
      public String Lingua{get;set;}
    public Espanhol(String nome,String tipo, double nota1, double nota2): base(nome,tipo, nota1, nota2){
       this.Lingua = "espanol";
       this.Nome = nome;
        this.Nome = nome;
        this.nota1 = nota1;
        this.nota2 = nota2;
    }

    public void certificado(){
          if(this.Tipo == "concluido")
            {
                this.Tipo = Tipo;
                 Console.WriteLine("Parabens você completou seu curso de Ingles");
            }
            else{
                      Console.WriteLine("Curso incompleto");
                }
    }

    public void mostar(){
        Console.WriteLine("\nStatus : "+base.Tipo);
        Console.WriteLine("Aluno : "+base.Nome);
        Console.WriteLine("Nota 1 : "+base.nota1); 
        Console.WriteLine("Nota 2 : "+base.nota2);
    }
}