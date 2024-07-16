using System.ComponentModel;
using Controller;
using Model;
using Repository;

namespace View;

public class TelaAlterarFuncionario : Form
{
    private readonly Label LblCadFunc;
    private readonly Label LblNome;
    private readonly Label LblFuncao;
    private readonly Label LblEmail;
    private readonly Label LblSenha;
    private readonly Label LblAdm;
    private readonly Label LblCadastrado;
    private readonly TextBox TxtCadFunc;
    private readonly TextBox TxtNome;
    private readonly TextBox txtFuncao;
    private readonly TextBox TxtEmail;
    private readonly TextBox TxtSenha;
    private readonly CheckBox checkAdm;
    private readonly Button btnSalvar;
    private readonly DataGridView listaFuncionarios;

    public TelaAlterarFuncionario(DataGridView listaFuncionarios)
    {
        this.listaFuncionarios = listaFuncionarios;

        Size = new Size(400, 400);

        StartPosition = FormStartPosition.CenterScreen;

        LblCadFunc = new Label
        {
            Text = "Cadastro de Funcionario",
            Location = new Point(140, 10),
            Size = new Size(300, 30),
        };

        LblNome = new Label
        {
            Text = "Nome",
            Location = new Point(20, 50),
            Size = new Size(50, 30),
        };
        TxtNome = new TextBox
        {
            Location = new Point(100, 50),
            Size = new Size(200, 50),
        };


        LblFuncao = new Label
        {
            Text = "Função",
            Location = new Point(20, 100),
            Size = new Size(50, 30),

        };
        txtFuncao = new TextBox
        {
            Location = new Point(100, 100),
            Size = new Size(200, 50),
        };


        LblEmail = new Label
        {
            Text = "Email",
            Location = new Point(20, 150),
            Size = new Size(50, 30),

        };
        TxtEmail = new TextBox
        {
            Location = new Point(100, 150),
            Size = new Size(200, 50),
        };


        LblSenha = new Label
        {
            Text = "Senha",
            Location = new Point(20, 200),
            Size = new Size(50, 30),

        };
        TxtSenha = new TextBox
        {
            Location = new Point(100, 200),
            Size = new Size(200, 50),
        };


        LblAdm = new Label
        {
            Text = "User ADM?",
            Location = new Point(20, 250),
            Size = new Size(70, 30),

        };
        checkAdm = new CheckBox
        {
            Location = new Point(100, 250),
            Size = new Size(20, 20),
        };


        btnSalvar = new Button
        {
            Text = "Salvar",
            Location = new Point(100, 290),
            Size = new Size(200, 20),
        };
        LblCadastrado = new Label
        {
            Text = "Funcionario cadastrado!",
            Visible = false
        };
        btnSalvar.Click += Salvar;

        Controls.Add(LblCadFunc);
        Controls.Add(LblNome);
        Controls.Add(LblFuncao);
        Controls.Add(LblEmail);
        Controls.Add(LblSenha);
        Controls.Add(TxtNome);
        Controls.Add(txtFuncao);
        Controls.Add(TxtEmail);
        Controls.Add(TxtSenha);
        Controls.Add(LblAdm);
        Controls.Add(checkAdm);
        Controls.Add(btnSalvar);
        Controls.Add(LblCadastrado);

        CarregarFuncionario();

    }

    public void AtualizarGrid(DataGridView listaFuncionarios)
    {
        BindingList<Funcionario> lsFunc = new BindingList<Funcionario>(FuncionarioRepo.funcionario);
        listaFuncionarios.DataSource = lsFunc;
    }

    private void CarregarFuncionario()
    {
        int idFuncionario = Convert.ToInt32(listaFuncionarios.SelectedRows[0].Cells[0].Value);
        Funcionario funcionario = FuncionarioRepo.funcionario.Find(fun => fun.IdFuncionario == idFuncionario);

        if (funcionario != null)
        {
            this.TxtNome.Text = funcionario.Nome;
            this.txtFuncao.Text = funcionario.Funcao;
            this.checkAdm.Checked = funcionario.Adm;
            this.TxtEmail.Text = funcionario.Email;
            this.TxtSenha.Text = funcionario.Senha;
        }
    }

    private void Salvar(object sender, EventArgs e)
    {
        int idFuncionario = Convert.ToInt32(listaFuncionarios.SelectedRows[0].Cells[0].Value);
        FuncionarioCont.AlterarFuncionarios(idFuncionario, TxtNome.Text, txtFuncao.Text, TxtEmail.Text, TxtSenha.Text);

        listaFuncionarios.Refresh();
        this.Close();
    }

}