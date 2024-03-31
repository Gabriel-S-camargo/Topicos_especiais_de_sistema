// Estrutura com método e atributos Da classe da "Indústria"

public class Industria{

    public string nome {get;set;}
    public string localizacao{get;set;}
    public int anoFundacao{get;set;}

    public List<LinhaProducao> linhasProducao = new List<LinhaProducao>();

    public void exibirInfo(){
        console.WriteLine("Nome da industria: " + this.nome);
        console.WriteLine("Localizacão: " + this.localizacao);
        console.WriteLine("Ano de Fundação: " + this.anoFundacao);
    }

    public void adicionarLinhaProducao(LinhaProducao lP){
        this.linhasProducao.Add(lP);
    }
}