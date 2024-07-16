using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Controller;

namespace View;
public class TelaCadastroFuncionario : Form
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
    public TelaCadastroFuncionario()
    {
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
        btnSalvar.Click += ClickSalvar;

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
    }

    private void ClickSalvar(object sender, EventArgs e)
    {
        FuncionarioCont.CriarFuncionarios(TxtNome.Text, txtFuncao.Text, checkAdm.Checked, TxtEmail.Text, TxtSenha.Text);
    
        LblCadastrado.Visible = true;
        LblCadastrado.Location = new Point(120, 310);
        LblCadastrado.Size = new Size(200, 50);
        LblCadastrado.Show();
    }
}