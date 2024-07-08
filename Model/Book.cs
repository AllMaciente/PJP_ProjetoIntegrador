using System.Collections.Generic;
using Repo;

namespace Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Livro { get; set; }

        public Book() { }

        public static List<Book> Sincronizar()
        {
            return RepoBook.Sincronizar();
        }

        public static List<Book> ListarBook()
        {
            return RepoBook.ListBooks();
        }

        public static void testDB()
        {
            RepoUser.InitConexao();
            RepoUser.CloseConexao();
        }

        public override string ToString()
        {
            return $"{Id} - {Livro}";
        }
    }
}
