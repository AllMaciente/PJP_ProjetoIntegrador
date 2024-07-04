using Controller;
using Model;

namespace View;

public class ViewEmprestimos : Form
{
    private readonly DataGridView DgvEmprestimos;
    public ViewEmprestimos()
    {
        ControllerEmprestimo.testDB();
        // ControllerEmprestimo.Sincronizar();

        Size = new Size(800, 400);
        StartPosition = FormStartPosition.CenterScreen;
        DgvEmprestimos = new DataGridView
        {
            Location = new Point(0, 100),
            Size = new Size(800, 250)
        };

        Controls.Add(DgvEmprestimos);
        // ControllerEmprestimo.Sincronizar();
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
            HeaderText = "Data_emprestimo"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Data_prazo",
            HeaderText = "Data_prazo"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Data_devolucao",
            HeaderText = "Data_devolucao"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Horario",
            HeaderText = "Horario"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id_multa",
            HeaderText = "Id_multa"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id_usuario",
            HeaderText = "Id_usuario"
        });
        DgvEmprestimos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id_livro",
            HeaderText = "Id_livro"
        });
    }
}