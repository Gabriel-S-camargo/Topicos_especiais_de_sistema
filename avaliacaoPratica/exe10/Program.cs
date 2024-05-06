CompanhiaAerea latam = new CompanhiaAerea("Latam", "Boeing 767-300F");

ReservaRegular rr01 = new ReservaRegular("Gabriel");

ReservaUpgrade ru01 = new ReservaUpgrade("Fernando Alonso", "Primeira Classe");

ReservaEmGrupo reg01 = new ReservaEmGrupo("Grupo BOSCH", 60);

rr01.mostrarInfo();

latam.reservarVoo(rr01);

ru01.mostrarInfo();

reg01.mostrarInfo();
