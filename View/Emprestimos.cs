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


        Controls.Add(DgvEmprestimos);

        Controls.Add(LblDataEmprestimo);
        Controls.Add(LblDataPrazo);
        Controls.Add(LblDataDevolucao);
        Controls.Add(LblHorario);
        Controls.Add(LblIdMulta);
        Controls.Add(LblUsuario);
        Controls.Add(LblLivro);
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
       
    }
}