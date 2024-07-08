using System.Security.Cryptography.X509Certificates;
using Model;
namespace Controller;
public class ControllerEmprestimo
{
    public static void testDB()
    {
        Emprestimo.testDB();
    }
    public static List<Emprestimo> ListarEmprestimos()
    {
        return Emprestimo.ListarEmprestimo();
    }
    public static void Sincronizar()
    {
        Emprestimo.Sincronizar();
        User.Sincronizar();
        Book.Sincronizar();
    }
    public static List<User> ListarUser()
    {
        return User.ListarUser();
    }
    public static List<Book> ListarBook()
    {
        return Book.ListarBook();
    }

    public static void Create(string data_emprestimo, string data_prazo, string data_devolucao, string horario, int id_usuario, int id_livro)
    {
        new Emprestimo(data_emprestimo, data_prazo, data_devolucao, horario, id_usuario, id_livro);
    }

}