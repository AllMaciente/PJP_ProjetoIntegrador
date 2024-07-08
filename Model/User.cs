using System.Collections.Generic;
using Repo;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string Usuario { get; set; }

        public User() { }

        public static List<User> Sincronizar()
        {
            return RepoUser.Sincronizar();
        }

        public static List<User> ListarUser()
        {
            return RepoUser.ListUsers();
        }

        public static void testDB()
        {
            RepoUser.InitConexao();
            RepoUser.CloseConexao();
        }
        public override string ToString()
        {
            return Usuario;
        }
    }
}
