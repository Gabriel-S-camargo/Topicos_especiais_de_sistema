public class Triangulo : FiguraGeometrica{
    public double base { get; set; }
    public double altura { get; set; }

    public double calcularArea(double base, double altura) {
        double resultado = (base * altura) / 2;
        return resultado;
    } 

    public double calcularPerimetro(){
        double resultado = 0.0;
        return resultado;
    }
}