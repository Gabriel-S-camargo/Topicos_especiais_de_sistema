public class Gerente : Funcionario {
    public double calcularBonus(double vlrExtra){
        double bonusPadrao = base.calcularBonus();

        return bonusPadrao + vlrExtra;
    }
}