Pedagio Ped_Curitiba = new Pedagio();

Ped_Curitiba.preco_eixo = 5.00;

Passeio santana = new Passeio();

santana.combustivel = "Gasolina";
santana.eixos = 2;

Mototocicleta kawasaki_400 = new Mototocicleta();

kawasaki_400.cilindrada = "50";

Caminhao scania = new Caminhao();

scania.eixos = 2;

scania.tipoCarga = "Alimentícia";

Ped_Curitiba.cobrarPedagio(santana);

Ped_Curitiba.cobrarPedagio(kawasaki_400);

Ped_Curitiba.cobrarPedagio(scania);