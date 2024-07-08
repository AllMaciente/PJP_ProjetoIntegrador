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
    public static void Update(int indice, string data_emprestimo, string data_prazo, string data_devolucao, string horario)
        {
            InitConexao();
            string query = "UPDATE emprestimos SET data_emprestimo = @DataEmprestimo, data_prazo = @DataPrazo, data_devolucao = @DataDevolucao, horario = @Horario WHERE id_emprestimo = @Id";
            MySqlCommand command = new MySqlCommand(query, conexao);
            Emprestimo emprestimo = emprestimos[indice];
            try
            {
                if (data_emprestimo != null || data_prazo != null || data_devolucao != null || horario != null)
                {
                    command.Parameters.AddWithValue("@Id", emprestimo.Id);
                    command.Parameters.AddWithValue("@DataEmprestimo", data_emprestimo);
                    command.Parameters.AddWithValue("@DataPrazo", data_prazo);
                    command.Parameters.AddWithValue("@DataDevolucao", data_devolucao);
                    command.Parameters.AddWithValue("@Horario", horario);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        emprestimo.Data_emprestimo = data_emprestimo;
                        emprestimo.Data_prazo = data_prazo;
                        emprestimo.Data_devolucao = data_devolucao;
                        emprestimo.Horario = horario;

                        emprestimo.Usuario = getName(emprestimo.Id_usuario);
                        emprestimo.Livro = getBook(emprestimo.Id_livro);
                    }
                    else
                    {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("emprestimo não encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
            CloseConexao();
        }

        public static void Delete(int index)
        {
            InitConexao();
            string delete = "DELETE FROM emprestimos WHERE id_emprestimo = @Id";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@Id", emprestimos[index].Id);
            // executar
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                emprestimos.RemoveAt(index);
                MessageBox.Show("Emprestimo deletado com sucesso.");
            }
            else
            {
                MessageBox.Show("Tarefa não encontrado.");
            }
            CloseConexao();
        }
    }
