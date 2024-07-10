using System.Collections.Generic;
using Model;

namespace Controller
{
    public class ControllerUser
    {
        public static void Sincronizar()
        {
            User.Sincronizar();
        }

        public static void Criar(string nome, string data_nascimento, string cpf)
        {
            // validate cpf, validate age
            new User(nome, data_nascimento, cpf);
        }

        public static List<User> Listar()
        {
            return User.ListarUser();
        }

        public static void Alterar(int indice, string nome, string data_nascimento, string cpf)
        {
            User.Alterar(indice, nome, data_nascimento, cpf);
        }

        public static void Deletar(int indice)
        {
            List<User> users = Listar();

            if (indice >= 0 && indice < users.Count)
            {
                User.Deletar(indice);
            }
            else
            {
                Console.WriteLine("Indice inválido");
            }
        }
    }
}
