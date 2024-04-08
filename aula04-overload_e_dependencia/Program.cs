//Cliente cliente01 = new Cliente();

Motor Turbo20 = new Motor();

Turbo20.combustivel = "Gasolina";

Turbo20.potencia = "150 cv";

//Console.WriteLine(Turbo20.potencia);

Veiculo Carro = new Veiculo(Turbo20);

Console.WriteLine(Carro.motor.potencia);