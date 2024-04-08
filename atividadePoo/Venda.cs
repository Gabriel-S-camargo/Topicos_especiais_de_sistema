public class Venda {

    public Vendedor vendedor;
    public Cliente cliente;
    public List<Produto> produtosVendidos;

    // Construtor com dependecia das classes

    public Venda(Vendedor vendedor, Cliente cliente) {
        this.vendedor = vendedor;
        
        this.cliente = cliente;

        produtosVendidos = new List<Produto>();
    }

    public void adicionarProduto(Produto produto){
        
        this.produtosVendidos.Add(produto);
    }


    public double calcularValorVenda(){
        double valorTotalVenda = 0;

        foreach(var prod in produtosVendidos){
            valorTotalVenda += prod.preco;
        }

        return valorTotalVenda;
    }


}