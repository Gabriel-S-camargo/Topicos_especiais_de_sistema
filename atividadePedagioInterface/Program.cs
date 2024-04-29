Carro carro01 = new Carro();

Moto moto01 = new Moto();

Caminhao caminhao01 = new Caminhao();

caminhao01.quantidadeEixo = 2;

Pedagio pedagio01 = new Pedagio();

pedagio01.valorEixo = 10;

Console.WriteLine(pedagio01.cobrarPedagio(carro01));

Console.WriteLine(pedagio01.cobrarPedagio(moto01));

Console.WriteLine(pedagio01.cobrarPedagio(caminhao01));