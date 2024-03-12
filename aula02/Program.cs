//Implrementação de listas de objetos
class Program{
    static void Main(){
        List<Estudante> Estudantes = new List<Estudante>();
        // construir 3 estudantes e adicionar na lista estudante
        Estudante aluno;
        for(int i = 0; i < 3; i++){
            aluno = new Estudante("R"+i, "Nome"+i);
            Estudantes.Add(aluno);

        }

        foreach(var Estudante in Estudantes){
            Console.WriteLine(Estudante.Rgm + " " + Estudante.Nome);
        }

    }
}