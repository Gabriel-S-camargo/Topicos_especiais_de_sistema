public class Produto
{
    public string nome { get; set; }
    public double preco { get; set; }
    public int quantidadeEstoque { get; set; }

    public Produto(string nome, double preco, int quantidadeEstoque)
    {
        this.nome = nome;
        this.preco = preco;
        this.quantidadeEstoque = quantidadeEstoque;
    }

    public int removerEstoque(int quantidadeRemovida)
    {
        this.quantidadeEstoque -= quantidadeRemovida;
        return this.quantidadeEstoque;
    }

    public int adicionarEstoque(int quantidadeAdicionada)
    {
        this.quantidadeEstoque += quantidadeAdicionada;

        return this.quantidadeEstoque;
    }

    public double valorTotalEstoque()
    {
        double valorTotalEstoque = this.preco * this.quantidadeEstoque;

        return valorTotalEstoque;
    }



}