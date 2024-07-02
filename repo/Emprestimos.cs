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
        // inicializa a conexão com o banco
        InitConexao();
        string query = "SELECT * FROM pessoas";
        MySqlCommand command = new MySqlCommand(query, conexao);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.Id = Convert.ToInt32(reader["id_emprestimo"].ToString());
            emprestimo.Data_emprestimo = reader["data_emprestimo"].ToString();
            emprestimo.Data_prazo = reader["data_prazo"].ToString();
            emprestimo.Data_devolucao = reader["data_devolucao"].ToString();
            emprestimo.Horario = reader["horario"].ToString();
            emprestimo.Id_multa = Convert.ToInt32(reader["id_multa "].ToString());
            emprestimo.Id_usuario = Convert.ToInt32(reader["id_usuario"].ToString());
            emprestimo.id_livro = Convert.ToInt32(reader["id_livro"].ToString());
            emprestimos.Add(emprestimo);
        }
        // fcha a conexão com o banco
        CloseConexao();
        return emprestimos;
    }
}
