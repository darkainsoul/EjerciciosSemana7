using Controlador;
using Entidades;
using System;
using System.Windows.Forms;

namespace RegistroAlumnosYProfesores
{
    public partial class MenuAlumnos : Form
    {
        public MenuAlumnos()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Alumnos alumno = new Alumnos();
            AlumnoControler controlador = new AlumnoControler();
            if (!string.IsNullOrEmpty(txtEdad.Text.Trim()) && !string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                alumno.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                alumno.Nombre = txtNombre.Text.Trim();
                controlador.Registrar(alumno);

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
            Alumnos alumno = new Alumnos();
            AlumnoControler controlador = new AlumnoControler();
            if (!string.IsNullOrEmpty(txtEdad.Text.Trim()) && !string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                alumno.Edad = Convert.ToInt32(txtEdad.Text);
                alumno.Nombre = txtNombre.Text;
                alumno.ID = Convert.ToInt32(txtMatricula.Text);
                controlador.ActualizarDatos(alumno);

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
            Alumnos alumno = new Alumnos();
            AlumnoControler controlador = new AlumnoControler();
            if (!string.IsNullOrEmpty(txtMatricula.Text.Trim()))
            {
                alumno.ID = Convert.ToInt32(txtMatricula.Text);
                var respuesta = controlador.GetDatosPersona(alumno.ID);

                txtEdad.Text = respuesta.Edad.ToString();
                txtNombre.Text = respuesta.Nombre;
            }
            else
            {
                MessageBox.Show("No se encontro ningun alumno con esa matricula");
            }
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