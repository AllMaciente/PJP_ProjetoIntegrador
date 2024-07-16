using Model;
using MySqlConnector;

namespace Repository{
    public class RepositoryLivro{
        private static MySqlConnection conexao;
        static readonly List<Livro> livros = new List<Livro> ();

        public static List<Livro> RepositoryLivros(){
            return livros;
        }
        //FILTRO DO LIVRO
        public static Livro GetLivro(int indice){
            if(indice < 0 || indice >= livros.Count){
                return null;
            }else{
                return livros[indice];
            }
        }
        //Iniciar conexao
        public static void IniConexao(){
            string query = "server=localhost;database=bibliotechdb; user id=root; password=''";
            conexao = new MySqlConnection(query);
            try{
                conexao.Open();
            }catch{
                Console.WriteLine("ERRO AO CONECTAR COM O BANCO!");
                MessageBox.Show("AAAAA");
            }
        }
        //Fechar conexao
        public static void FecharConexao(){
            conexao.Close();
        }
        //Sincronizar
        public static List<Livro> Sincronizar(){
            IniConexao();
            string query = "SELECT * FROM livros";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader reader = comando.ExecuteReader();
            
            while(reader.Read()){
                int id = Convert.ToInt32(reader["id_livro"].ToString());
                int qtd_paginas = Convert.ToInt32(reader["qtd_paginas"].ToString());
                Livro livro = new Livro
                {
                    Id_livro = id,
                    Nome = reader["nome"].ToString(),
                    Autor = reader["autor"].ToString(),
                    Genero = reader["genero"].ToString(),
                    Qtd_paginas = qtd_paginas,

                };
                livros.Add(livro);
                }
                FecharConexao();
                return livros;
            }
        //Criar
        public static void CriarLivro(Livro livro){
            IniConexao();
            string query = "INSERT INTO livros (nome, autor, genero, qtd_paginas) VALUES (@Nome, @Autor, @Genero, @Qtd_paginas)";
            MySqlCommand command = new MySqlCommand(query,conexao);

            try{
                if(livro.Nome == null){
                    Console.WriteLine("Preencha todos os campos!");
                }else{
                    command.Parameters.AddWithValue("@Nome", livro.Nome);
                    command.Parameters.AddWithValue("@Autor", livro.Autor);
                    command.Parameters.AddWithValue("@Genero", livro.Genero);
                    command.Parameters.AddWithValue("@Qtd_paginas", livro.Qtd_paginas);
                    
                    int rows = command.ExecuteNonQuery();
                    livro.Id_livro = Convert.ToInt32(command.LastInsertedId);
                    
                    if(rows > 0){
                        Console.WriteLine("Livro cadastrado com sucesso!");
                        livros.Add(livro);
                    }else{
                        Console.WriteLine("Erro ao cadastrar livro!");
                    }
                }
                }catch{
                    Console.WriteLine("Erro ao cadastrar livro!");
                }
                FecharConexao();
            }
        //Excluir
        public static void ExcluirLivro(int indice){
            IniConexao();
            string query = "DELETE FROM livros WHERE id_livro = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            command.Parameters.AddWithValue("@Id",livros[indice].Id_livro);
            int rows = command.ExecuteNonQuery();

            if(rows > 0){
                livros.RemoveAt(indice);
                Console.WriteLine("Livro excluido com sucesso!");
            }else{
                Console.WriteLine("Erro ao excluir livro!");
            }
            FecharConexao();
        }
        //Alterar
        public static void AlterarLivro(int indice, Livro livro){
            IniConexao();
            string query = "UPDATE livros SET nome = @Nome, autor = @Autor, genero = @Genero, qtd_paginas = @Qtd_paginas WHERE id=@Id)";
            MySqlCommand command = new MySqlCommand(query, conexao);

            try{
                if(livro != null){
                    command.Parameters.AddWithValue("@Nome", livros[indice].Nome);
                    command.Parameters.AddWithValue("@Autor", livros[indice].Autor);
                    command.Parameters.AddWithValue("@Genero", livros[indice].Genero);
                    command.Parameters.AddWithValue("@Qtd_paginas", livros[indice].Qtd_paginas);
                    int rows = command.ExecuteNonQuery();

                    if(rows > 0){
                        livros[indice] = livro;
                        Console.WriteLine("Livro alterado com sucesso!");
                    }else{
                        Console.WriteLine("Erro ao alterar livro!");
                }}else{
                    Console.WriteLine("Livro não encontrado!");
                }
            }catch{
                Console.WriteLine("Erro ao alterar");
            }
            FecharConexao();
            }
        }
    }
