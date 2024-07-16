using Repository;

namespace Model{
public class Funcionario
{
    public int IdFuncionario { get; set; }
    public string Nome { get; set; }
    public string Funcao { get; set; }
    public bool Adm { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

        public Funcionario(string nome, string funcao, bool adm, string email, string senha)
        {
            Nome = nome;
            Funcao = funcao;
            Adm = adm;
            Email = email;
            Senha = senha;
            FuncionarioRepo.funcionario.Add(this);
        }

        public Funcionario(int idFuncionario, string nome, string funcao, bool adm, string email, string senha)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            Funcao = funcao;
            Adm = adm;
            Email = email;
            Senha = senha;
            FuncionarioRepo.funcionario.Add(this);
        }

        public static List<Funcionario> ListarFuncionarios()
        {
            return FuncionarioRepo.funcionario;
        }

        public static void AlterarFuncionarios(int idFuncionario, string nome, string funcao, string email, string senha)
        {
            FuncionarioRepo.funcionario[idFuncionario].Nome = nome;
            FuncionarioRepo.funcionario[idFuncionario].Funcao = funcao;
            FuncionarioRepo.funcionario[idFuncionario].Email = email;
            FuncionarioRepo.funcionario[idFuncionario].Senha = senha;
        }

        public static void DeletarFuncionarios(int idFuncionario)
        {
            FuncionarioRepo.funcionario.RemoveAt(idFuncionario);
        }
    }
}