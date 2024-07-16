using System.Windows.Forms.Design;

namespace View;
    public class ViewHome : Form {
        public static ViewHome CurrentInstance {get; private set;}
        private readonly Label LblTitulo;
        private readonly Label LblTexto;
        private readonly Button BtnFuncionario;
        private readonly Button BtnUsuario;
        private readonly Button BtnEmprestimo;
        private readonly Button BtnLivro;
        private readonly Button BtnSair;

        public ViewHome(){
            CurrentInstance = this;
            Size = new Size(600, 300);
            StartPosition = FormStartPosition.CenterScreen;

            LblTitulo = new Label{
                Text = "BiblioTech",
                Font = new Font("Arial", 30, FontStyle.Bold),
                Location = new Point(180,30),
                Size = new Size(400,50),
            };

            LblTexto = new Label {
                Text = "Bem vindo(a) ao sistema de biblioteca da Prefeitura de Joinville",
                Font = new Font("Arial", 15),
                Location = new Point(50,90),
                Size = new Size(500,50),
            };
            BtnLivro = new Button {
                Text = "Livros",
                Font = new Font("Arial", 11),
                Size = new Size(100,25),
                Location = new Point(20, 160),
            };
            BtnLivro.Click += BtnLivro_Click;
            BtnFuncionario = new Button {
                Text = "Funcionarios",
                Font = new Font("Arial", 11),
                Size = new Size(100,25),
                Location = new Point(130, 160),
            };
            BtnFuncionario.Click += BtnFuncionario_Click;

            BtnUsuario = new Button {
                Text = "Usuarios",
                Font = new Font("Arial", 11),
                Location = new Point(240, 160),
                Size = new Size(100,25),
            };
            BtnUsuario.Click += BtnUsuario_Click;

            BtnEmprestimo = new Button {
                Text = "Emprestimo",
                Font = new Font("Arial", 11),
                Location = new Point(350, 160),
                Size = new Size(100,25),
            };
            BtnEmprestimo.Click += BtnEmprestimo_Click;

            BtnSair = new Button {
                Text = "Sair",
                Font = new Font("Arial", 12),
                Location = new Point(460, 160),
                Size = new Size(100,25),
            };
            BtnSair.Click += BtnSair_Click;

            Controls.Add(LblTexto);
            Controls.Add(LblTitulo);
            Controls.Add(BtnLivro);
            Controls.Add(BtnUsuario);
            Controls.Add(BtnEmprestimo);
            Controls.Add(BtnFuncionario);
            Controls.Add(BtnSair);
        }

        private void BtnSair_Click(object? sender, EventArgs e){
            Application.Exit();
        }

        private void BtnLivro_Click(object? sender, EventArgs e){
            ViewLivro livro = new ViewLivro();
            livro.Show();
            Hide();
        }

        private void BtnUsuario_Click(object? sender, EventArgs e){
            ViewUser usuario = new ViewUser();
            usuario.Show();
            Hide();
        }

        private void BtnEmprestimo_Click(object? sender, EventArgs e){
            ViewEmprestimos emprestimo = new ViewEmprestimos();
            emprestimo.Show();
            Hide();
        }

        private void BtnFuncionario_Click(object? sender, EventArgs e){
            TelaFuncionario funcionario = new TelaFuncionario();
            funcionario.Show();
            Hide();
        }
    }
