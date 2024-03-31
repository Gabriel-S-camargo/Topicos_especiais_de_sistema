// Estrutura com atributos e metodos da classe "Máquina"

public class Maquina{

    public int id{get;set;}
    public string marca{get;set;}
    public string modelo{get;set;}

    public void exibirInfo(){
        console.WriteLine("Id maquina: " + this.id);
        console.WriteLine("Marca: " + this.marca);
        console.WriteLine("Modelo: " +this.modelo);
    }

    public void iniciarProducao(Produto p){
        console.WriteLine("Iniciada a produção da maquina!\nProduto sendo produzido: " + this.Produto.nome);
    }

}