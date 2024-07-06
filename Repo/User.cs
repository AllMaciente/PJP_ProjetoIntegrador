using System.Collections.Generic;
using MySqlConnector;
using Model;

namespace Repo
{
    public class RepoUser
    {
        private static MySqlConnection conexao;
        static List<User> users = new List<User>();

        public static List<User> ListUsers()
        {
            return users;
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

        public static List<User> Sincronizar()
        {
            InitConexao();
            string querySync = "SELECT * FROM usuarios";
            MySqlCommand command = new MySqlCommand(querySync, conexao);
            MySqlDataReader readerSync = command.ExecuteReader();

            while (readerSync.Read())
            {
                // Assume User object has a constructor to initialize from a DataReader
                User user = new User
                {
                    Id = Convert.ToInt32(readerSync["id_usuario"].ToString()),
                    Usuario = readerSync["nome"].ToString() ?? ""
                };

                users.Add(user);
            }

            CloseConexao();
            return users;
        }
    }
}
