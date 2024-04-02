public class Veiculo{

    public string modelo = string.Empty;

    public Motor motor;

    public Veiculo(Motor m){
        this.motor = m;
    }
} 

/*
    Atividade Orientação objetos

    Implemente as classes conforme o enunciado

    1. Classe Produto
    Atributos - >(Codigo, nome, preco)

    2. Classe cliente 
    Atributos -> (cpf, nome)

    3.Classe Vendedor
    Atributos -> (Matricula, cpf, nome)

    4. Classe Venda
    Atributos (Vendedor, Cliente, Lista de produtos vendidos, total_da_venda)

    Metodos:

    a: Construtor com dependencia do vendedor e do Cliente
    b: Construtor padrão(Constroi o objeto sem estado)
    c: Método para adicionar os produtos comprados pelo cliente
    d: Método para calcular o valor da venda


*/