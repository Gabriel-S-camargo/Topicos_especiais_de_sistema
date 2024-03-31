// Estrutura com atributos e metodos da classe Linha de Produção

public class LinhaProducao{

    public int numeroLinha{get;set;}
    public string tipo{get;set;}
    public int quantidade{get;set;}

    public List<Maquina> maquinas = new List<Maquina>();

    public void exibirInfo(){
        console.WriteLine("Numero da linha de produção: " + this.numeroLinha);
        console.WriteLine("Tipo de produto da linha: " + this.tipo);
        console.WriteLine("Quantidade de produtos produzidos por hora: " + this.quantidade);

    }

    public void adicionarMaquina(Maquina m){
        this.maquinas.Add(m);
    }


}