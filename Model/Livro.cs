using Repository;

namespace Model{
    public class Livro{
        public int Id_livro{get;set;}
        public string Nome{get;set;}
        public string Autor{get;set;}
        public string Genero{get;set;}
        public int Qtd_paginas{get;set;}

        public Livro(){}
        //add
        public Livro(string nome, string autor, string genero, int qtd_paginas){
            Nome = nome;
            Autor = autor;
            Genero = genero;
            Qtd_paginas = qtd_paginas;

            RepositoryLivro.CriarLivro(this);
        }
        //listar
        public static List<Livro> ListarLivros(){
            return RepositoryLivro.RepositoryLivros();
        }
        //sincronizar
        public static void Sincronizar(){
            RepositoryLivro.Sincronizar();
        }
        //excluir
        public static void ExcluirLivro(int indice){
            RepositoryLivro.ExcluirLivro(indice);
        }
        //alterar
        public static void AlterarLivro(int indice, string nome, string autor, string genero, int qtd_paginas){
            Livro livro = RepositoryLivro.GetLivro(indice);
            if(livro != null){
                livro.Nome = nome;
                livro.Autor = autor;
                livro.Genero = genero;
                livro.Qtd_paginas = qtd_paginas;
                RepositoryLivro.AlterarLivro(indice,livro);
            }else{
                Console.WriteLine("Livro não encontrado");
            }
        }
    }
}