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
    public static void AddEmprestimo(Emprestimo emprestimo)
    {
        InitConexao();
        string insert = "INSERT INTO emprestimos (data_emprestimo, data_prazo, data_devolucao, horario, id_usuario, id_livro) " +
                        "VALUES (@DataEmprestimo, @DataPrazo, @DataDevolucao, @Horario, @IdUsuario, @IdLivro);";
        MySqlCommand command = new MySqlCommand(insert, conexao);

        try
        {
            command.Parameters.AddWithValue("@DataEmprestimo", emprestimo.Data_emprestimo);
            command.Parameters.AddWithValue("@DataPrazo", emprestimo.Data_prazo);
            command.Parameters.AddWithValue("@DataDevolucao", emprestimo.Data_devolucao);
            command.Parameters.AddWithValue("@Horario", emprestimo.Horario);
            command.Parameters.AddWithValue("@IdUsuario", emprestimo.Id_usuario);
            command.Parameters.AddWithValue("@IdLivro", emprestimo.Id_livro);
            command.Parameters.AddWithValue("@Usuario", emprestimo.Usuario);
            command.Parameters.AddWithValue("@Livro", emprestimo.Livro);

            int rowsAffected = command.ExecuteNonQuery();
            emprestimo.Id = Convert.ToInt32(command.LastInsertedId);

            emprestimo.Usuario = getName(emprestimo.Id_usuario);
            emprestimo.Livro = getBook(emprestimo.Id_livro);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Empréstimo cadastrado com sucesso");
                // Supondo que você tenha uma lista de empréstimos para adicionar o novo empréstimo:
                // emprestimos.Add(emprestimo);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar empréstimo");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Erro ao cadastrar empréstimo: " + e.Message);
        }

        CloseConexao();
    }

    public static void CloseConexao()
    {
        conexao.Close();
    }
    public static string getName(int id)
    {
        InitConexao();
        string queryBook = "SELECT nome FROM usuarios WHERE id_usuario =  @Id";
        MySqlCommand commandBook = new MySqlCommand(queryBook, conexao);
        commandBook.Parameters.AddWithValue("@Id", id);
        MySqlDataReader readerBook = commandBook.ExecuteReader();
        if (readerBook.Read())
        {
            return readerBook["nome"].ToString();
        }
        else
        {
            return "Não encontrado";
        }
        CloseConexao();
    }
    public static string getBook(int id)
    {
        InitConexao();
        string queryNome = "SELECT nome FROM livros WHERE id_livro = @Id";
        MySqlCommand commandNome = new MySqlCommand(queryNome, conexao);
        commandNome.Parameters.AddWithValue("@Id", id);
        MySqlDataReader readerNome = commandNome.ExecuteReader();
        if (readerNome.Read())
        {
            return readerNome["nome"].ToString();
        }
        else
        {
            return "Não encontrado";
        }
        CloseConexao();
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
            emp.Id_multa = readerSync["id_multa"] != DBNull.Value ? Convert.ToInt32(readerSync["id_multa"]) : 0;
            emp.Id_usuario = Convert.ToInt32(readerSync["id_usuario"].ToString());
            emp.Id_livro = Convert.ToInt32(readerSync["id_livro"].ToString());
            emp.Usuario = getName(emp.Id_usuario);
            emp.Livro = getBook(emp.Id_livro);
            emprestimos.Add(emp);
        }
        CloseConexao();
        return emprestimos;
    }

}