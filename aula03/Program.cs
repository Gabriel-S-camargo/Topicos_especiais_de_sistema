
// Instanciar uma Universidade

Universidade objUniversidade = new Universidade();

objUniversidade.nome = "Universidade Positivo";
objUniversidade.localizacao = "Ecoville";
objUniversidade.anoFundacao = 1990;

// Criar o curso 'ADS' e adicionar dentro da universidade o Curso

Curso objCurso = new Curso();

objCurso.nome = "ADS";

objUniversidade.adicionarCurso(objCurso);

// Criar o curso 'BSI' e adicionar dentro da universidade o Curso
objCurso = new Curso();
objCurso.nome = "BSI";
objUniversidade.adicionarCurso(objCurso);

Console.WriteLine(objUniversidade.nome);

foreach(var curso in objUniversidade.cursos){
    Console.WriteLine(curso.nome);
    
}
