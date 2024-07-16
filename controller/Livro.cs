using Model;

namespace Controller{
    public class ControllerLivro{
        public static void Sincronizar(){
            Livro.Sincronizar();
        }
        public static List<Livro> ListarLivros(){
            return Livro.ListarLivros();
        }
        public static void CriarLivro(string nome, string autor, string genero, int qtd_paginas){
            new Livro(nome,autor,genero,qtd_paginas);
        }

        public static void AlterarLivro(int indice, string nome, string autor, string genero, int qtd_paginas){
            Livro.AlterarLivro(indice, nome, autor, genero, qtd_paginas);
        }

        public static void ExcluirLivro(int indice){
            // List<Livro> livros = ListarLivros();

            // if(indice >= 0 && indice < livros.Count){
            //     livros.RemoveAt(indice);
            //     Console.WriteLine("Livro excluído com sucesso!");
            // }else{
            //     Console.WriteLine("Indice invalido");
            // }
            Livro.ExcluirLivro(indice);
        }
    }
}