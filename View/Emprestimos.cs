using System;
using System.Data;
using System.Windows.Forms;

using Controller;
using Model;

namespace View;

public class ViewEmprestimos : Form
{

    private Button BtnVoltar;
    private DataGridView DgvEmprestimos;


    private Label LblDataEmprestimo;
    private Label LblDataPrazo;
    private Label LblDataDevolucao;
    private Label LblHorario;
    private Label LblIdMulta;
    private Label LblUsuario;
    private Label LblLivro;

    private TextBox InpDataEmprestimo;
    private TextBox InpDataPrazo;
    private TextBox InpDataDevolucao;
    private TextBox InpHorario;
    private TextBox InpIdMulta;
    private TextBox InpIdUsuario;
    private TextBox InpIdLivro;


    private Button BtnCreate;
    private Button BtnAlterar;
    private Button BtnDelete;
    private BindingSource _bindingSource;


    public ViewEmprestimos()
    {
        InitializeComponent();
        Listar();
    }
    private void InitializeComponent()
    {
        ControllerEmprestimo.Sincronizar();
        _bindingSource = new BindingSource();

        int point2 = 0;
        int sep = 50;
        Text = "Emprestimo";
        Size = new Size(850, 550);
        StartPosition = FormStartPosition.CenterScreen;
        DgvEmprestimos = new DataGridView
        {
            Location = new Point(0, 250),
            Size = new Size(850, 250)
        };

        LblDataDevolucao = new Label
        {
            Text = "Data Devolucao",
            Location = new Point(25, point2 += sep),
            Size = new Size(100, 25)
        };
        LblDataEmprestimo = new Label
        {
            Text = "Data Emprestimo",
            Location = new Point(25, point2 += sep),
            Size = new Size(100, 25)
        };
        LblDataPrazo = new Label
        {
            Text = "Data Prazo",
            Location = new Point(25, point2 += sep),
            Size = new Size(100, 25)
        };
        LblHorario = new Label
        {
            Text = "Horario",
            Location = new Point(25, point2 += sep),
            Size = new Size(100, 25)
        };
        LblIdMulta = new Label
        {
            Text = "Id Multa",
            Location = new Point(25, point2 += sep),
            Size = new Size(100, 25)
        };
        LblUsuario = new Label
        {
            Text = "Usuario",
            Location = new Point(300, sep),
            Size = new Size(100, 25)
        };
        LblLivro = new Label
        {
            Text = "Livro",
            Location = new Point(500, sep),
            Size = new Size(100, 25)
        };


        point2 = 25;
        InpDataDevolucao = new TextBox
        {
            Name = "InpDataDevolucao",
            Location = new Point(25, point2 += sep),
            Size = new Size(200, 30)
        };
        InpDataEmprestimo = new TextBox
        {
            Name = "InpDataEmprestimo",
            Location = new Point(25, point2 += sep),
            Size = new Size(200, 30)

        };
        InpDataPrazo = new TextBox
        {
            Name = "InpDataPrazo",
            Location = new Point(25, point2 += sep),
            Size = new Size(200, 30)

        };
        InpHorario = new TextBox
        {
            Name = "InpHorario",
            Location = new Point(25, point2 += sep),
            Size = new Size(200, 30)

        };

        InpIdUsuario = new TextBox
        {
            Name = "InpIdUsuario",
            Location = new Point(300, sep * 2),
            Size = new Size(150, 30)
        };

        InpIdLivro = new TextBox
        {
            Name = "InpIdLivro",
            Location = new Point(500, sep * 2),
            Size = new Size(150, 30)
        };

        BtnCreate = new Button
        {
            Text = "Create",
            Location = new Point(700, (sep * 1)),
            Size = new Size(100, 20)
        };
        BtnCreate.Click += ClickCreate;

        BtnAlterar = new Button
        {
            Text = "Alterar",
            Location = new Point(700, (sep * 2)),
            Size = new Size(100, 20)
        };
        BtnAlterar.Click += ClickAlterar;

        BtnDelete = new Button
        {
            Text = "Delete",
            Location = new Point(700, (sep * 3)),
            Size = new Size(100, 20)
        };
        BtnDelete.Click += ClickDeletar;

        BtnVoltar = new Button
        {
            Text = "Voltar",
            Location = new Point(0, 0),
            Size = new Size(150, 30)
        };
        BtnVoltar.Click += BtnVoltar_Click;


        Controls.Add(DgvEmprestimos);

        Controls.Add(LblDataEmprestimo);
        Controls.Add(LblDataDevolucao);
        Controls.Add(LblDataPrazo);
        Controls.Add(LblHorario);
        Controls.Add(LblIdMulta);
        Controls.Add(LblUsuario);
        Controls.Add(LblLivro);

        Controls.Add(InpDataDevolucao);
        Controls.Add(InpDataEmprestimo);
        Controls.Add(InpDataPrazo);
        Controls.Add(InpHorario);
        Controls.Add(InpIdMulta);
        Controls.Add(InpIdUsuario); // Changed from InpUsuario
        Controls.Add(InpIdLivro);   // Changed from InpLivro



        Controls.Add(BtnCreate);
        Controls.Add(BtnAlterar);
        Controls.Add(BtnDelete);
        Controls.Add(BtnVoltar);
    }
    private void Listar()
    {
        List<Emprestimo> emprestimos = ControllerEmprestimo.ListarEmprestimos();
        _bindingSource.DataSource = emprestimos;
        DgvEmprestimos.DataSource = _bindingSource;

        DgvEmprestimos.Columns.Clear();
        DgvEmprestimos.AutoGenerateColumns = false;
        AdicionarColunasAoDataGridView();

    }
    private void AdicionarColunasAoDataGridView()
    {
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id",
            HeaderText = "Id"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Data_emprestimo",
            HeaderText = "Data Emprestimo"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Data_prazo",
            HeaderText = "Data Prazo"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Data_devolucao",
            HeaderText = "Data Devolucao"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Horario",
            HeaderText = "Horario"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Usuario",
            HeaderText = "Usuario"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Livro",
            HeaderText = "Livro"
        });



    }
    // Dentro do método ClickCreate
    private void ClickCreate(object sender, EventArgs e)
    {

        // Obtenha os IDs digitados nos TextBoxes
        int idUsuario = Convert.ToInt32(InpIdUsuario.Text);
        int idLivro = Convert.ToInt32(InpIdLivro.Text);


        // Captura os valores dos campos de entrada
        string dataEmprestimo = InpDataEmprestimo.Text;
        string dataPrazo = InpDataPrazo.Text;
        string dataDevolucao = InpDataDevolucao.Text;
        string horario = InpHorario.Text;

        // Chama o método para criar um novo empréstimo
        ControllerEmprestimo.Create(dataEmprestimo, dataPrazo, dataDevolucao, horario, idUsuario, idLivro);

        // Atualize a exibição da lista de empréstimos
        Listar();
    }

    // Dentro do método ClickAlterar
    private void ClickAlterar(object sender, EventArgs e)
    {
        // Obtenha os IDs digitados nos TextBoxes
        int index = DgvEmprestimos.SelectedRows[0].Index;
        // Captura os valores dos campos de entrada
        string dataEmprestimo = InpDataEmprestimo.Text;
        string dataPrazo = InpDataPrazo.Text;
        string dataDevolucao = InpDataDevolucao.Text;
        string horario = InpHorario.Text;

        // Chama o método para atualizar o empréstimo
        ControllerEmprestimo.Update(index, dataEmprestimo, dataPrazo, dataDevolucao, horario);

        // Atualize a exibição da lista de empréstimos
        Listar();
    }

    private void ClickDeletar(object? sender, EventArgs e)
    {
        int index = DgvEmprestimos.SelectedRows[0].Index;
        ControllerEmprestimo.Delete(index);
        Listar();
    }
    private void BtnVoltar_Click(object sender, EventArgs e)
    {
        LimparDataGridView();
        this.Close();
        if (ViewHome.CurrentInstance != null)
        {
            ViewHome.CurrentInstance.Show();
        }
    }
    private void LimparDataGridView()
    {
        _bindingSource.Clear();
        DgvEmprestimos.Columns.Clear();
    }
}