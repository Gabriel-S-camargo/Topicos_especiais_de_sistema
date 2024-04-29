public class Circulo : FiguraGeometrica{
    public double raio { get; set; }

    public double pi = 3.14;

    public double calcularArea(double pi, double raio) {
        double resultado = pi * (raio * raio);
        return resultado;
    } 

    public double calcularPerimetro(){
        double resultado = 2 * pi * raio;
        return resultado;
    }
}