public class Curso{
   
    public String Tipo {get;set;}
    public String Nome{get;set;}
    public double nota1{get;set;}
    public double nota2{get;set;}
    public double media = 0.0;
    public Curso(String nome,String tipo,double nota1, double nota2){
        this.Tipo = tipo;
    }
     public void certificado(){
    }

    public void mediaF(){
    }
}