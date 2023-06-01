using appPractica.Winform.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appPractica.Winform.UI
{
    public partial class frmPersona : Form
    {

        public frmPersona()
        {
            InitializeComponent();
        }
        private void frmPersona_Load(object sender, EventArgs e)
        {
            cmbGenero.DataSource = Enum.GetValues(typeof(Genero));
            cmbNacionalidad.DataSource = Enum.GetValues(typeof(Nacionalidad));
        }

      

            private void btnInsertar_Click(object sender, EventArgs e)
            {
            try
            {
                var logica = new BLL.BLLPersona();

                Persona p = new Persona()
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Apellido1 = txtApellido1.Text,
                    Apellido2 = txtApellido2.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Genero = cmbGenero.SelectedValue.ToString(),
                    Direccion = txtDireccion.Text,
                    Telefono = int.Parse(txtTelefono.Text),
                    CorreoElectronico = txtCorreo.Text,
                    Nacionalidad = cmbNacionalidad.SelectedValue.ToString()
                };

                logica.Guardar(p);
                
                dgvPersonas.DataSource = logica.SeleccionarTodo().FindAll(x => x.Id.ToString().Equals(txtId.Text));

                LimpiarCampos();

                MessageBox.Show("Se ha guardado correctamente");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var logica = new BLL.BLLPersona();

                string id = txtId.Text;

                var p = logica.SeleccionarPorId(id);

                if (p != null)
                {
                    txtId.Enabled = false;
                    txtNombre.Text = p.Nombre;
                    txtApellido1.Text = p.Apellido1;
                    txtApellido2.Text = p.Apellido2;
                    txtCorreo.Text = p.CorreoElectronico;
                    txtDireccion.Text = p.Direccion;
                    txtTelefono.Text = p.Telefono.ToString();
                    dtpFechaNacimiento.Value = p.FechaNacimiento;
                    cmbGenero.Text = p.Genero;
                    cmbNacionalidad.Text = p.Nacionalidad;

                    dgvPersonas.DataSource = logica.SeleccionarTodo().FindAll(x => x.Id.ToString().Equals(txtId.Text));
                }
                else
                {
                    MessageBox.Show("No se ha encontrado persona con el Id:" + id);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var logica = new BLL.BLLPersona();

                Persona p = new Persona()
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Apellido1 = txtApellido1.Text,
                    Apellido2 = txtApellido2.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Genero = cmbGenero.SelectedValue.ToString(),
                    Direccion = txtDireccion.Text,
                    Telefono = int.Parse(txtTelefono.Text),
                    CorreoElectronico = txtCorreo.Text,
                    Nacionalidad = cmbNacionalidad.SelectedValue.ToString()
                };

                logica.Guardar(p);

                dgvPersonas.DataSource = logica.SeleccionarTodo().FindAll(x => x.Id.ToString().Equals(txtId.Text));

                LimpiarCampos();

                MessageBox.Show("Se ha actualizado correctamente");


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {


            LimpiarCampos();
               

        }

        private void LimpiarCampos()
        {
            txtId.Enabled = true;
            txtId.Text = "";
            cmbGenero.SelectedIndex = -1;
            cmbNacionalidad.SelectedIndex = -1;
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            dtpFechaNacimiento.Value = Convert.ToDateTime("01/01/1900");
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var logica = new BLL.BLLPersona();
            string id = txtId.Text;
            var p = logica.SeleccionarPorId(id);
            if (p != null)
            {

                logica.Eliminar(id);

                dgvPersonas.DataSource = logica.SeleccionarTodo().FindAll(x => x.Id.ToString().Equals(txtId.Text));

                LimpiarCampos();

                MessageBox.Show("Se ha eliminado correctamente el usuario con el Id:" + id);
            }
            else
            {
                MessageBox.Show("No se ha encontrado persona con el Id:" + id);
            }



        }
    }
}


