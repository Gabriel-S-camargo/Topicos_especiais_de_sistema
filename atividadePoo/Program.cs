Vendedor vendedor = new Vendedor { matricula = "0123", cpf = "123", nome = "pia" };

Cliente cliente = new Cliente { cpf = "456", nome = "guria" };

Venda venda = new Venda(vendedor, cliente);

Produto produto1 = new Produto { codigo = 1, nome = "Produto 1", preco = 10 };
Produto produto2 = new Produto { codigo = 2, nome = "Produto 2", preco = 20 };

venda.adicionarProduto(produto1);
venda.adicionarProduto(produto2);

double totalVenda = venda.calcularValorVenda();

Console.WriteLine("Total da venda: " + totalVenda);