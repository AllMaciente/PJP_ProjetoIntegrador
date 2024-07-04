using Model;
using MySqlConnector;

namespace Repo;

public class RepoEmprestimos
{
    private static MySqlConnection conexao;

    static List<Emprestimo> emprestimos = new List<Emprestimo>();

    public static List<Emprestimo> ListEmprestimos()
    {
        return emprestimos;
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
            MessageBox.Show("Não deu, foi mal");
        }
    }
    public static void CloseConexao()
    {
        conexao.Close();
    }
    public static List<Emprestimo> Sincronizar()
    {
        InitConexao();
        string querySync = "SELECT * FROM emprestimos";
        MySqlCommand command = new MySqlCommand(querySync, conexao);
        MySqlDataReader readerSync = command.ExecuteReader();
        while (readerSync.Read())
        {
            Emprestimo emp = new Emprestimo();
            emp.Id = Convert.ToInt32(readerSync["id_emprestimo"].ToString());
            emp.Data_emprestimo = readerSync["data_emprestimo"].ToString() ?? "";
            emp.Data_prazo = readerSync["data_prazo"].ToString() ?? "";
            emp.Data_devolucao = readerSync["data_devolucao"].ToString() ?? "";
            emp.Horario = readerSync["horario"].ToString() ?? "";
            emp.Id_multa = Convert.ToInt32(readerSync["id_multa"].ToString());
            emp.Id_usuario = Convert.ToInt32(readerSync["id_usuario"].ToString());
            emp.id_livro = Convert.ToInt32(readerSync["id_livro"].ToString());
            emprestimos.Add(emp);
        }
        CloseConexao();
        return emprestimos;
    }
}