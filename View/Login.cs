namespace View;
    public class ViewLogin : Form {
        private readonly Label LblTitulo;
        private readonly Label LblTexto;
        private readonly Label LblTexto2;
        private readonly TextBox InputUser;
        private readonly TextBox InputSenha;
        private readonly Button BtnLogin;
        private readonly Button BtnSair;

        public ViewLogin(){
            Size = new Size(500, 350);
            StartPosition = FormStartPosition.CenterScreen;

            LblTitulo = new Label{
                Text = "BiblioTech",
                Font = new Font("Arial", 30, FontStyle.Bold),
                Location = new Point(120,30),
                Size = new Size(300,50),
            };

            LblTexto = new Label{
                Text = "Usuario",
                Font = new Font("Arial", 12),
                Location = new Point(120,100),
                Size = new Size(80,20)
            };

            InputUser = new TextBox{
                Location = new Point(200,100),
                Size = new Size(150,30),
            };

            LblTexto2 = new Label{
                Text = "Senha",
                Font = new Font("Arial", 12),
                Size = new Size(70,30),
                Location = new Point(120,140),
            };

            InputSenha = new TextBox{
                Location = new Point(200,140),
                Size = new Size(150,30),
            };

            BtnLogin = new Button {
                Text = "Login",
                Font = new Font("Arial", 11),
                Size = new Size(100,25),
                Location = new Point(135, 200),
            };
            BtnLogin.Click += BtnLogin_Click;

            BtnSair = new Button {
                Text = "Sair",
                Font = new Font("Arial", 11),
                Size = new Size(100,25),
                Location = new Point(245, 200),
            };
            BtnSair.Click += BtnSair_Click;

            Controls.Add(LblTexto);
            Controls.Add(LblTitulo);
            Controls.Add(InputUser);
            Controls.Add(LblTexto2);
            Controls.Add(InputSenha);
            Controls.Add(BtnLogin);
            Controls.Add(BtnSair);
        }

        private void BtnLogin_Click(object? sender, EventArgs e){
            ViewHome homeForm = new ViewHome();
            homeForm.Show();
            Hide();
        }

        private void BtnSair_Click(object? sender, EventArgs e){
            Application.Exit();
        }
    }
