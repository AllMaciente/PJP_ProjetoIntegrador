using Model;
using Repository;

namespace Controller;
public class FuncionarioCont
{
    public static void CriarFuncionarios(string nome, string funcao, bool adm, string email, string senha)
    {
        int idFuncionario = FuncionarioRepo.funcionario.Count;

        new Funcionario(idFuncionario, nome, funcao, adm, email, senha);
    }
    public static List<Funcionario> ListarFuncionarios(){
        return Funcionario.ListarFuncionarios();
    }
    public static void AlterarFuncionarios(int idFuncionario, string nome, string funcao, string email, string senha){
        Funcionario.AlterarFuncionarios(idFuncionario, nome, funcao,email, senha );
    }
    public static void DeletarFuncionarios(int idFuncionario){
        Funcionario.DeletarFuncionarios(idFuncionario);
    }
}
