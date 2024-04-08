Operario operadorDeCaixa = new Operario();
operadorDeCaixa.nome = "Pia";
operadorDeCaixa.cpf = "12345";
operadorDeCaixa.salario = 1200;

Gerente coordenadorDeOperacao = new Gerente();

coordenadorDeOperacao.nome = "Gabriel";
coordenadorDeOperacao.salario = 5000;

Console.WriteLine(operadorDeCaixa.calcularBonus());

Console.WriteLine(coordenadorDeOperacao.calcularBonus(500));