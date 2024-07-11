using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewHome : Form
    {
        private readonly Button BtnOpenForm1;
        private readonly Button BtnOpenForm2;
        private readonly Button BtnOpenForm3;
        public static ViewHome CurrentInstance { get; private set; }

        public ViewHome()
        {
            CurrentInstance = this;

            Text = "View Test";
            Size = new Size(400, 300);
            StartPosition = FormStartPosition.CenterScreen;

            BtnOpenForm1 = new Button
            {
                Text = "Abrir Form1",
                Location = new Point(50, 50),
                Size = new Size(100, 30)
            };
            BtnOpenForm1.Click += (sender, e) => OpenForm(new ViewEmprestimos());

            BtnOpenForm2 = new Button
            {
                Text = "Abrir Form2",
                Location = new Point(50, 100),
                Size = new Size(100, 30)
            };
            BtnOpenForm2.Click += (sender, e) => OpenForm(new ViewUser());

            BtnOpenForm3 = new Button
            {
                Text = "Abrir Form3",
                Location = new Point(50, 150),
                Size = new Size(100, 30)
            };
            BtnOpenForm3.Click += (sender, e) => OpenForm(new ViewUserEmprestimos(1));

            Controls.Add(BtnOpenForm1);
            Controls.Add(BtnOpenForm2);
            Controls.Add(BtnOpenForm3);
        }

        private void OpenForm(Form form)
        {
            this.Hide();
            form.Show();
        }
    }
}