using System;
using System.Drawing;
using System.Windows.Forms;

namespace RegistroAlumnosYProfesores
{
    public partial class MenuPrincipal : Form
    {
        private Color ActiveColorLogo = Color.FromArgb(51, 7, 8);
        private Color InactiveColorLogo = Color.FromArgb(102, 12, 13);

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            var frm = new MenuAlumnos();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            var frm = new MenuProfesores();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            btnSalir.BackColor = ActiveColorLogo;
        }

        private void btnSalir_Leave(object sender, EventArgs e)
        {
            btnSalir.BackColor = InactiveColorLogo;
        }
    }
}