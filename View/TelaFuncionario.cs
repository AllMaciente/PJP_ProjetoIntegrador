using System.ComponentModel;
using System.Drawing.Text;
using System.Security.Cryptography;
using Controller;
using Model;
using Repository;

namespace View;

public class TelaFuncionario : Form
{
    private readonly Label LblTelaFuncionario;
    private readonly Button btnCriarFuncionario;
    private readonly Button btnListarFuncionarios;
    private readonly Button btnAlterarFuncionario;
    private readonly Button btnDeletarFuncionario;
    private readonly Button btnSair;
    public readonly DataGridView listaFuncionarios;
    public TelaFuncionario()
    {
        Size = new Size(730, 600);
        StartPosition = FormStartPosition.CenterScreen;
        LblTelaFuncionario = new Label
        {
            Text = "Administracao Funcionarios",
            Location = new Point(200, 20),
            Size = new Size(300, 30),
        };
        btnCriarFuncionario = new Button
        {
            Text = "Criar Funcionario",
            Location = new Point(20, 60),
            Size = new Size(150, 30),
        };
        btnListarFuncionarios = new Button
        {
            Text = "Listar Funcionarios",
            Location = new Point(170, 60),
            Size = new Size(150, 30),
        };
        btnAlterarFuncionario = new Button
        {
            Text = "Alterar Funcionario",
            Location = new Point(320, 60),
            Size = new Size(150, 30),
        };
        btnDeletarFuncionario = new Button
        {
            Text = "Deletar Funcionario",
            Location = new Point(470, 60),
            Size = new Size(150, 30),
        };
        btnSair = new Button
        {
            Text = "SAIR",
            Location = new Point(620, 60),
            Size = new Size(75, 30),
        };

        btnSair.BackColor = Color.Red;
        btnCriarFuncionario.Click += ClickCriarFunc;
        btnListarFuncionarios.Click += ClickListarFunc;
        btnAlterarFuncionario.Click += ClickAlterarFunc;
        btnDeletarFuncionario.Click += ClickDeletarFunc;
        btnSair.Click += ClickSair;

        listaFuncionarios = new DataGridView();
        setupListaFuncionarios(listaFuncionarios);

        Controls.Add(LblTelaFuncionario);
        Controls.Add(btnCriarFuncionario);
        Controls.Add(btnListarFuncionarios);
        Controls.Add(btnAlterarFuncionario);
        Controls.Add(btnDeletarFuncionario);
        Controls.Add(btnSair);
        Controls.Add(listaFuncionarios);
    }

    private void setupListaFuncionarios(DataGridView listaFuncionarios)
    {
        listaFuncionarios.Name = "Funcionarios";
        listaFuncionarios.Location = new Point(60, 140);
        listaFuncionarios.Size = new Size(600, 350);
        listaFuncionarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        listaFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        listaFuncionarios.RowHeadersVisible = false;

        listaFuncionarios.Visible = false;
    }

    private void ClickCriarFunc(object sender, EventArgs e)
    {
        TelaCadastroFuncionario cadastroFuncionario = new TelaCadastroFuncionario();
        cadastroFuncionario.Show();
    }

    private void ClickListarFunc(object sender, EventArgs e)
    {
        BindingList<Funcionario> lsFunc = new BindingList<Funcionario>(FuncionarioRepo.funcionario);
        listaFuncionarios.Visible = true;
        listaFuncionarios.DataSource = lsFunc;
    }

    private void ClickAlterarFunc(object sender, EventArgs e)
    {
        if (FuncionarioRepo.funcionario.Count > 0)
        {
            TelaAlterarFuncionario telaAlterarFuncionario = new TelaAlterarFuncionario(listaFuncionarios);
            telaAlterarFuncionario.Show();
        }
    }

    private void ClickDeletarFunc(object sender, EventArgs e)
    {
        if (listaFuncionarios.SelectedRows.Count > 0)
        {
            if (listaFuncionarios.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = listaFuncionarios.SelectedRows[0];
                int idFuncionario = Convert.ToInt32(row.Cells[0].Value);

                listaFuncionarios.Rows.RemoveAt(row.Index);
            }
        }
    }

    private void ClickSair(object sender, EventArgs e) {
        this.Close();
        ViewHome.CurrentInstance.Show();
    }

}
