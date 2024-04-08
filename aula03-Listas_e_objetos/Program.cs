Curso curso01= new Curso();
Turma turma01 = new Turma();

curso01.nome = "ADS";
curso01.duracao = 2;

turma01.anoFormacao = 2025;
turma01.turno = "Noturno";

curso01.adicionarTurma(turma01);

foreach(var turma in curso01.turmas){
    Console.WriteLine(turma.turno);
}