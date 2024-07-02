using System.Security.Cryptography.X509Certificates;
using Repo;

namespace Model;
public class Emprestimo
{
    public int Id { get; set; }
    public string Data_emprestimo { get; set; }
    public string Data_prazo { get; set; }
    public string Data_devolucao { get; set; }
    public string Horario { get; set; }
    public int Id_multa { get; set; }
    public int Id_usuario { get; set; }
    public int id_livro { get; set; }

    public Emprestimo() { }
    public static List<Emprestimo> Sincronizar()
    {
        return RepoEmprestimos.Sincronizar();
    }
    public static List<Emprestimo> ListarEmprestimo()
    {
        return RepoEmprestimos.ListEmprestimos();
    }
    public static void testDB()
    {
        RepoEmprestimos.InitConexao();

        RepoEmprestimos.CloseConexao();

    }

}