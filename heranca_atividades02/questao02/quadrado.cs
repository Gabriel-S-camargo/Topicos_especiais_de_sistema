public class Quadrado : FiguraGeometrica{

    public double lado { get; set; }

    public double calcularArea(double lado){
        double resultado = lado * lado;

        return resultado;
    } 

    public double calcularPerimetro(){
        double resultado = lado * 4;

        return resultado;
    }

}