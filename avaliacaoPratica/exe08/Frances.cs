public class Frances : Curso
{
     public String Lingua{get;set;}
    public Frances(String nome,String tipo, double nota1, double nota2): base(nome,tipo, nota1, nota2){
       this.Lingua = "frances";
       this.Nome = nome;
        this.Tipo = tipo;
        this.nota1 = nota1;
        this.nota2 = nota2;
    }

    public void mediaF(){
          if(this.Tipo == "avançado")
            {
                  media = (nota1+nota2)/2;
                  Console.WriteLine("Media : "+ media);
            }
            else{
                 Console.WriteLine("Media ............");
            }
    }

    public void mostar(){
         Console.WriteLine("\nCurso de  "+Lingua);
        Console.WriteLine("Status : "+base.Tipo);
        Console.WriteLine("Aluno : "+base.Nome);
        Console.WriteLine("Nota 1 : "+base.nota1); 
        Console.WriteLine("Nota 2 : "+base.nota2);
    }
}