using Controlador;
using Entidades;
using System;
using System.Windows.Forms;

namespace RegistroAlumnosYProfesores
{
    public partial class MenuProfesores : Form
    {
        public MenuProfesores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            var frm = new MenuPrincipal();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Profesores profesor = new Profesores();
            ProfesorControler controlador = new ProfesorControler();
            if (!string.IsNullOrEmpty(txtEdad.Text.Trim()) && !string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                profesor.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                profesor.Nombre = txtNombre.Text.Trim();
                controlador.Registrar(profesor);

                MessageBox.Show("Se realizó el alta con éxito");
                Clean();
            }
            else
            {
                MessageBox.Show("Los campos de edad y nombre no pueden ir vacios");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Profesores profesor = new Profesores();
            ProfesorControler controlador = new ProfesorControler();
            if (!string.IsNullOrEmpty(txtEdad.Text.Trim()) && !string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                profesor.Edad = Convert.ToInt32(txtEdad.Text);
                profesor.Nombre = txtNombre.Text;
                profesor.ID = Convert.ToInt32(txtMatricula.Text);
                controlador.ActualizarDatos(profesor);

                MessageBox.Show("Se realizó el actualización con éxito");
                Clean();
            }
            else
            {
                MessageBox.Show("Los campos de edad y nombre no pueden ir vacios");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Profesores profesor = new Profesores();
            ProfesorControler controlador = new ProfesorControler();
            if (!string.IsNullOrEmpty(txtMatricula.Text.Trim()))
            {
                profesor.ID = Convert.ToInt32(txtMatricula.Text);
                var respuesta = controlador.GetDatosPersona(profesor.ID);

                txtEdad.Text = respuesta.Edad.ToString();
                txtNombre.Text = respuesta.Nombre;
            }
            else
            {
                MessageBox.Show("No se encontro ningun profesor con ese ID");
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
        }

        private void txtEdad_Enter(object sender, EventArgs e)
        {
            txtEdad.Text = String.Empty;
        }

        private void Clean()
        {
            txtNombre.Text = String.Empty;
            txtEdad.Text = String.Empty;
        }

        private void txtMatricula_Enter(object sender, EventArgs e)
        {
            txtMatricula.Text = String.Empty;
        }
    }
}