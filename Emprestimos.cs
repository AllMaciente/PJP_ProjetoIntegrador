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
    public int Id_livro { get; set; }
    public string Usuario { get; set; }
    public string Livro { get; set; }


    public Emprestimo() { }
    public Emprestimo(string data_emprestimo, string data_prazo, string data_devolucao, string horario, int id_usuario, int id_livro)
    {
        Data_emprestimo = data_emprestimo;
        Data_prazo = data_prazo;
        Data_devolucao = data_devolucao;
        Horario = horario;
        Id_usuario = id_usuario;
        Id_livro = id_livro;

        // Aqui você chama a função para adicionar o empréstimo ao banco de dados
        RepoEmprestimos.AddEmprestimo(this);
    }

    public static List<Emprestimo> Sincronizar()
    {
        return RepoEmprestimos.Sincronizar();
    }
    public static List<Emprestimo> ListarEmprestimo()
    {
        return RepoEmprestimos.ListEmprestimos();

    }

    public static Delete(int indece){
        RepoEmprestimos.Delete(indece);
    }
    public static Update(int indice, string data_emprestimo, string data_prazo, string data_devolucao, string horario, int id_usuario, int id_livro){
        RepoEmprestimos.Update(indece,data_emprestimo, data_prazo, data_devolucao, horario, id_usuario, id_livro);
    }
    public static void testDB()
    {
        RepoEmprestimos.InitConexao();

        RepoEmprestimos.CloseConexao();

    }

}