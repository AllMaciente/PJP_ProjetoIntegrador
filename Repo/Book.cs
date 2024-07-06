using System;
using System.Collections.Generic;
using MySqlConnector;
using Model;

namespace Repo
{
    public class RepoBook
    {
        private static MySqlConnection conexao;
        static List<Book> books = new List<Book>();

        public static List<Book> ListBooks()
        {
            return books;
        }

        public static void InitConexao()
        {
            string info = "server=localhost;database=bibliotechDB;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try
            {
                conexao.Open();
            }
            catch
            {
                // Handle exception
                Console.WriteLine("Connection failed");
            }
        }

        public static void CloseConexao()
        {
            conexao.Close();
        }

        public static List<Book> Sincronizar()
        {
            InitConexao();
            string querySync = "SELECT * FROM livros"; // Changed table name to match Book context
            MySqlCommand command = new MySqlCommand(querySync, conexao);
            MySqlDataReader readerSync = command.ExecuteReader();

            while (readerSync.Read())
            {
                Book book = new Book
                {
                    Id = Convert.ToInt32(readerSync["id_livro"].ToString()), // Changed column name to match Book context
                    Livro = readerSync["nome"].ToString() ?? "" // Changed column name to match Book context
                };

                books.Add(book);
            }

            CloseConexao();
            return books;
        }
    }
}
