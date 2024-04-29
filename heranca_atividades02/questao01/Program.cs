/*
Crie uma classe base chamada Veiculo com os seguintes atributos: Marca (string): a marca do veículo. Modelo (string): o modelo do veículo.Crie subclasses para diferentes tipos de veículos, como Carro, Moto e Caminhao, que herdamda classe Veiculo e adicionam atributos específicos, Carro: número de portas; Moto: cilindrada; Caminhão: capacidade de carga
*/

Carro carro01 = new Carro();

carro01.modelo = "alfa romeu";
carro01.marca = "a";
carro01.numeroPortas = 0;

Console.WriteLine(carro01.ligarVeiculo());
