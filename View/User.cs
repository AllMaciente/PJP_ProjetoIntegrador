using Controller;
using Model;

namespace View;

public class ViewUser : Form {

    private readonly Label LblNome;
    private readonly Label LblCpf;
    private readonly Label LblDataNascimento;
    private readonly TextBox InpNome;
    private readonly TextBox InpCpf;
    private readonly TextBox InpDataNascimento;
    private readonly Button BtnCadastrar;
    private readonly Button BtnAlterar;
    private readonly Button BtnDeletar;
    private readonly DataGridView DgvPessoas;

    public ViewUser() {
        ControllerUser.Sincronizar();

        Size = new Size(400, 400);
        StartPosition = FormStartPosition.CenterScreen;

        LblNome = new Label {
            Text = "Nome: ",
            Location = new Point(50, 50),
        };
        LblCpf = new Label {
            Text = "Cpf: ",
            Location = new Point(50, 100),
        };
        LblDataNascimento = new Label {
            Text = "Data De Nascimento: ",
            Location = new Point(50, 150),
        };

        InpNome = new TextBox {
            Name = "Nome",
            Location = new Point(150, 50),
            Size = new Size(200, 20)
        };
        InpCpf = new TextBox {
            Name = "Cpf",
            Location = new Point(150, 100),
            Size = new Size(200, 20)
        };
        InpDataNascimento = new TextBox {
            Name = "DataNascimento",
            Location = new Point(150, 150),
            Size = new Size(200, 20)
        };

        BtnCadastrar = new Button {
            Text = "Cadastrar",
            Location = new Point(50, 150),
        };
        BtnCadastrar.Click += ClickCadastrar;
        BtnAlterar = new Button {
            Text = "Alterar",
            Location = new Point(150, 150),
        };
        BtnAlterar.Click += ClickAlterar;
        BtnDeletar = new Button {
            Text = "Deletar",
            Location = new Point(250, 150),
        };
        BtnDeletar.Click += ClickDeletar;

        DgvPessoas = new DataGridView {
            Location = new Point(0, 200),
            Size = new Size(400, 150)
        };


        Controls.Add(LblNome);
        Controls.Add(LblCpf);
        Controls.Add(LblDataNascimento);
        Controls.Add(InpNome);
        Controls.Add(InpCpf);
        Controls.Add(InpDataNascimento);
        Controls.Add(BtnCadastrar);
        Controls.Add(BtnAlterar);
        Controls.Add(BtnDeletar);
        Controls.Add(DgvPessoas);
        
        Listar();
    }

    private void ClickCadastrar(object? sender, EventArgs e) {
        if(InpNome.Text == "") {
            return;
        }
        ControllerUser.Criar(InpNome.Text, InpDataNascimento.Text, InpCpf.Text);
        Listar();
    }

    private void ClickAlterar(object? sender, EventArgs e) {
        int index = DgvPessoas.SelectedRows[0].Index;
        if(InpNome.Text == "") {
            return;
        }
        ControllerUser.Alterar(index, InpNome.Text, InpDataNascimento.Text, InpCpf.Text);
        Listar();
    }

    private void Listar() {
        List<User> users = ControllerUser.Listar();
        DgvPessoas.Columns.Clear();
        DgvPessoas.AutoGenerateColumns = false;
        DgvPessoas.DataSource = pessoas;
        
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Id",
            HeaderText = "Id"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Nome",
            HeaderText = "Nome"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Cpf",
            HeaderText = "Cpf"
        });
        DgvPessoas.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Data_nascimento",
            HeaderText = "Data_nascimento"
        });
    }
    private void ClickDeletar(object? sender, EventArgs e) {
        int index = DgvPessoas.SelectedRows[0].Index;
        ControllerUser.Deletar(index);
        Listar();
    }


}