/*Crie uma classe chamada Pessoa que possua uma coleção de objetos da classe Livro. A classePessoa deve conter os seguintes atributos:- Cpf (string): o cpf da pessoa.- Nome (string): o nome da pessoa.Livro deve ter os seguintes atributos:- Titulo (string): o título do livro.- Autor (string): o autor do livro.A classe pessoa deve possuir um método para receber os livros.No programa principal: Implemente uma rotina que imprima os dados dos livros da pessoa noconsole*/

Livro livro01 = new Livro("1984", 1963);

Pessoa pessoa01 = new Pessoa("Gabriel", "123456");

pessoa01.adicionarLivro(livro01);

pessoa01.MostrarInfo();