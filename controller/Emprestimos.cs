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
    }
}