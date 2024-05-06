public class Ingles : Curso
{
       public String Lingua{get;set;}
    public Ingles(String nome,String tipo, double nota1, double nota2): base(nome,tipo, nota1, nota2){
       this.Lingua = "igles";
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
                  this.nota1 = 0;
                  this.nota2 = 0;
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