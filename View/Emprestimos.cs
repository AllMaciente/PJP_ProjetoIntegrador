using Controller;
using Model;

namespace View;

public class ViewEmprestimos : Form
{
    private readonly DataGridView DgvEmprestimos;

    private readonly Label LblDataEmprestimo;
    private readonly Label LblDataPrazo;
    private readonly Label LblDataDevolucao;
    private readonly Label LblHorario;
    private readonly Label LblIdMulta;
    private readonly Label LblUsuario;
    private readonly Label LblLivro;

    private readonly TextBox InpDataEmprestimo;
    private readonly TextBox InpDataPrazo;
    private readonly TextBox InpDataDevolucao;
    private readonly TextBox InpHorario;
    private readonly TextBox InpIdMulta;
    private readonly TextBox InpUsuario;
    private readonly TextBox InpLivro;

    private readonly ListBox LbUsuario;
    private readonly ListBox LbLivro;

    private readonly Button btnCreate;
    private readonly Button btnAlterar;
    private readonly Button btnDelete;

    public ViewEmprestimos()
    {
        ControllerEmprestimo.Sincronizar();

        int point2 = 0;
        int sep = 50;
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

        LbUsuario = new ListBox
        {
            Location = new Point(300, sep + 25),
            Name = "LbUsuario",

            Size = new Size(150, 175),
        };
        LbLivro = new ListBox
        {
            Location = new Point(500, sep + 25),
            Name = "LbLivro",

            Size = new Size(150, 175),
        };

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
        Controls.Add(InpUsuario);
        Controls.Add(InpLivro);

        Controls.Add(LbUsuario);
        Controls.Add(LbLivro);

        Controls.Add(BtnCreate);
        Listar();
    }
    private void Listar()
    {
        List<Emprestimo> emprestimos = ControllerEmprestimo.ListarEmprestimos();
        DgvEmprestimos.Columns.Clear();
        DgvEmprestimos.AutoGenerateColumns = false;
        DgvEmprestimos.DataSource = emprestimos;

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
            DataPropertyName = "Id_multa",
            HeaderText = "Id Multa"
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

        List<User> users = ControllerEmprestimo.ListarUser();
        foreach (User user in users)
        {
            LbUsuario.Items.Add(user.ToString());
        }

    }
    private void button1_Click(object sender, EventArgs e)
    {
        // Verifica se há um item selecionado
        if (LbUsuario.SelectedItem != null)
        {
            // Obtém o item selecionado
            string selectedItem = LbUsuario.SelectedItem.ToString();
            // Obtém o índice do item selecionado
            int selectedIndex = LbUsuario.SelectedIndex;
            // Exibe o item selecionado e seu índice em uma MessageBox
            MessageBox.Show($"Item selecionado: {selectedItem}\nÍndice do item: {selectedIndex}");
        }
        else
        {
            MessageBox.Show("Nenhum item selecionado.");
        }
    }

}