using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public class ViewLivro : Form
    {
        private Label LblNome;
        private Label LblAutor;
        private Label LblGenero;
        private Label LblQtdPag;
        private TextBox InputNome;
        private TextBox InputAutor;
        private TextBox InputGenero;
        private TextBox InputQtdPag;
        private Button BtnCadastrar;
        private Button BtnExcluir;
        private Button BtnVoltar;
        private Button BtnEditar;
        private DataGridView ListarLivros;
        private BindingSource _bindingSource;

        public ViewLivro()
        {
            InitializeComponent();
            Listar();
        }

        private void InitializeComponent()
        {
            ControllerLivro.Sincronizar();
            _bindingSource = new BindingSource();

            Size = new Size(400, 450);
            StartPosition = FormStartPosition.CenterScreen;

            LblNome = new Label
            {
                Text = "Nome:",
                Location = new Point(20, 30),
                Size = new Size(50, 20)
            };
            LblAutor = new Label
            {
                Text = "Autor:",
                Location = new Point(200, 30),
                Size = new Size(50, 20)
            };
            LblGenero = new Label
            {
                Text = "Gênero:",
                Location = new Point(20, 70),
                Size = new Size(50, 20)
            };
            LblQtdPag = new Label
            {
                Text = "Páginas:",
                Location = new Point(200, 70),
                Size = new Size(50, 20)
            };

            InputNome = new TextBox
            {
                Location = new Point(70, 30),
            };
            InputAutor = new TextBox
            {
                Location = new Point(250, 30),
            };
            InputGenero = new TextBox
            {
                Location = new Point(70, 70),
            };
            InputQtdPag = new TextBox
            {
                Location = new Point(250, 70),
            };
            BtnCadastrar = new Button
            {
                Text = "Cadastrar",
                Location = new Point(30, 130),
            };
            BtnCadastrar.Click += ClickCria;

            BtnEditar = new Button
            {
                Text = "Alterar",
                Location = new Point(115, 130),
            };
            BtnEditar.Click += ClickEdita;

            BtnExcluir = new Button
            {
                Text = "Excluir",
                Location = new Point(195, 130),
            };
            BtnExcluir.Click += ClickExclui;

            BtnVoltar = new Button
            {
                Text = "Voltar",
                Location = new Point(280, 130),
            };
            BtnVoltar.Click += ClickVoltar;

            ListarLivros = new DataGridView
            {
                Location = new Point(20, 170),
                Size = new Size(350, 200)
            };

            Controls.Add(LblNome);
            Controls.Add(LblAutor);
            Controls.Add(LblGenero);
            Controls.Add(LblQtdPag);
            Controls.Add(InputNome);
            Controls.Add(InputAutor);
            Controls.Add(InputGenero);
            Controls.Add(InputQtdPag);
            Controls.Add(BtnCadastrar);
            Controls.Add(BtnEditar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnVoltar);
            Controls.Add(ListarLivros);
        }

        private void ClickCria(object sender, EventArgs e)
        {
            int qtdPagina = int.Parse(InputQtdPag.Text);
            if (string.IsNullOrWhiteSpace(InputNome.Text))
            {
                MessageBox.Show("O campo nome não pode estar vazio");
            }
            else
            {
                ControllerLivro.CriarLivro(InputNome.Text, InputAutor.Text, InputGenero.Text, qtdPagina);
                MessageBox.Show("Livro cadastrado com sucesso");
                Listar();
            }
        }

        private void ClickExclui(object sender, EventArgs e)
        {
            int indice = ListarLivros.SelectedRows[0].Index;
            ControllerLivro.ExcluirLivro(indice);
            Listar();
        }

        private void ClickEdita(object sender, EventArgs e)
        {
            int qtdPagina = int.Parse(InputQtdPag.Text);
            int indice = ListarLivros.SelectedRows[0].Index;
            ControllerLivro.AlterarLivro(indice, InputNome.Text, InputAutor.Text, InputGenero.Text, qtdPagina);
            Listar();
        }

        private void ClickVoltar(object sender, EventArgs e)
        {
            LimparDataGridView();
            Close();
            ViewHome.CurrentInstance.Show();
        }

        public void Listar()
        {
            List<Livro> livros = ControllerLivro.ListarLivros();

            _bindingSource.DataSource = livros;
            ListarLivros.DataSource = _bindingSource;

            ListarLivros.Columns.Clear();
            ListarLivros.AutoGenerateColumns = false;

            AdicionarColunasAoDataGridView();
        }

        private void AdicionarColunasAoDataGridView()
        {
            ListarLivros.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_livro",
                HeaderText = "Id",
                Width = 30
            });

            ListarLivros.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 75
            });

            ListarLivros.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Autor",
                HeaderText = "Autor",
                Width = 75
            });

            ListarLivros.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Genero",
                HeaderText = "Gênero",
                Width = 75
            });

            ListarLivros.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Qtd_paginas",
                HeaderText = "Páginas",
                Width = 52
            });
        }

        private void LimparDataGridView()
        {
            _bindingSource.Clear();
            ListarLivros.Columns.Clear();
        }
    }
}
