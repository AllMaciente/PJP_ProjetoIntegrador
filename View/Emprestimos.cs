// using Controller;
// using Model;

namespace View;

public class ViewEmprestimos : Form
{
    private readonly DataGridView DgvEmprestimos;
    public ViewEmprestimos()
    {
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
        // Listar();
    }
}