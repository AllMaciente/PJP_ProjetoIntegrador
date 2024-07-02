using Model;
namespace Controller;
public class ControllerEmprestimo
{
    public static void testDB()
    {
        Emprestimo.testDB();
    }
    public static void Sincronizar()
    {
        Emprestimo.Sincronizar();
    }
    public static List<Emprestimo> ListarEmprestimos()
    {
        return Emprestimo.ListarEmprestimo();
    }
}