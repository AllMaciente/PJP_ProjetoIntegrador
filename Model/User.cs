using System.Collections.Generic;
using Repo;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Data_nascimento { get; set; }
        public string Cpf { get; set; }

        public User() { }
        public User(
            string usuario,
            string data_nascimento,
            string cpf
        ) { 
            Usuario = usuario;
            Data_nascimento = data_nascimento;
            Cpf = cpf;

            RepoUser.Criar(this);
        }

        public static List<User> Sincronizar()
        {
            return RepoUser.Sincronizar();
        }

        public static List<User> ListarUser()
        {
            return RepoUser.ListUsers();
        }

        public static void Alterar(
            int indice,
            string usuario,
            string data_nascimento,
            string cpf
        ){  
            RepoUser.Update(indice, usuario, data_nascimento, cpf);
        }

        public static void Deletar(int indice) {
            RepoUser.Delete(indice);
        }

        public static void testDB()
        {
            RepoUser.InitConexao();
            RepoUser.CloseConexao();
        }
        public override string ToString()
        {
            return $"{Id} - {Usuario}";
        }
    }
}
