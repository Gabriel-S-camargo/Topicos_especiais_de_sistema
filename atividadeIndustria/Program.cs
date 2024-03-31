
// Iniciando objetos

Industria industria01 = new Industria();

LinhaProducao linhaProducao01 = new LinhaProducao();
LinhaProducao linhaProducao02 = new LinhaProducao();

Maquina maquina01 = new Maquina();
Maquina maquina02 = new Maquina();
Maquina maquina03 = new Maquina();
Maquina maquina04 = new Maquina();

Produto produto01 = new Produto();
Produto produto02 = new Produto();
Produto produto03 = new Produto();
Produto produto04 = new Produto();

// Atributo dos objetos

//Industria
industria01.nomeIndustria = "Industria 1";
industria01.localizacao = "Curitiba, Brasil";
industria01.anoFundacao = 2005;

// Linhas de produção

linhaProducao01.numeroLinha = 1;
linhaProducao01.tipo = "componentes eletricos";
linhaProducao01.quantidade = 1000;

linhaProducao02.numeroLinha = 2;
linhaProducao02.tipo = "Componentes ativos";
linhaProducao02.quantidade = 2000;

// Maquinas

maquina01.id = 01;
maquina01.marca = "MaquiMais";
maquina01.modelo = "MQNA - 01";

maquina02.id = 02;
maquina02.marca = "MaquiMais";
maquina02.modelo = "MQNA - 02";

maquina03.id = 03;
maquina03.marca = "EletroMaquina";
maquina03.modelo = "MQNA - 03";

maquina04.id = 04;
maquina04.marca = "EletroMaquina";
maquina04.modelo = "MQNA - 04";

// Produtos

produto01.nomeProduto = "Resistor";
produto01.codigo = 001;
produto01.preco = 10.90;

produto02.nomeProduto = "Capacitor";
produto02.codigo = 002;
produto02.preco = 15.90;

produto03.nomeProduto = "Fonte de energia";
produto03.codigo = 003;
produto03.preco = 22.90;

produto04.nomeProduto = "Transistor";
produto04.codigo = 004;
produto04.preco = 16.90;


// Adicionando com o métodos

// Industria

industria01.adicionarLinhaProducao(linhaProducao01);

industria01.adicionarLinhaProducao(linhaProducao02);


// Linhas de produção

linhaProducao01.adicionarMaquina(maquina01);

linhaProducao01.adicionarMaquina(maquina02);

linhaProducao02.adicionarMaquina(maquina03);

linhaProducao02.adicionarMaquina(maquina04);

// teste de métodos

// Info Industria
industria01.exibirInfoIndustria();

// Info das linhas de produção

linhaProducao01.exibirInfoLinhaProdução();

linhaProducao02.exibirInfoLinhaProdução();

// Info das Máquinas

maquina01.exibirInfoMaquina();

maquina02.exibirInfoMaquina();

maquina03.exibirInfoMaquina();

maquina04.exibirInfoMaquina();


// Info dos Produtos

produto01.exibirInfoProduto();

produto02.exibirInfoProduto();

produto03.exibirInfoProduto();

produto04.exibirInfoProduto();

// Iniciar producao da maquina
