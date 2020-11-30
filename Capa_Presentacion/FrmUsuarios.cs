using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capap_Negocios;
using Capa_Entidades;

namespace Capa_Presentacion
{
    public partial class FrmUsuarios : Form
    {
        N_Login objNegocio = new N_Login();

        public FrmUsuarios()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            foreach (Control tool in Controls)
            {
                if (tool is TextBox)
                {
                    tool.Text = "";
                }
                if (tool is MaskedTextBox)
                {
                    tool.Text = "";
                }
                if (tool is ComboBox)
                {
                    tool.Text = "";
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            dataGridViewUsers.DataSource = objNegocio.Mostrando_N();

        }
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            dataGridViewUsers.DataSource = objNegocio.Mostrando_N();

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Login.User = txtUser.Text; //int.Parse(txtCode.Text);
                E_Login.Pass = txtPass.Text; 
                E_Login.Nombre1 = txtNombre.Text.ToUpper(); 
                E_Login.Apellido1 = txtApellido.Text.ToUpper();
                E_Login.Fecha1 = Convert.ToDateTime(dateTimePickerFecha.Text);
                if (radioButtonUser.Checked == true)
                { E_Login.Cargo1 = (radioButtonUser.Text); }
                else
                { E_Login.Cargo1 = (radioButtonAdimin.Text); }


                objNegocio.Guardando_N();

                MessageBox.Show("Registro Guardado");

                dataGridViewUsers.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Login.ID1 = int.Parse(txtCode.Text);
                E_Login.User = txtUser.Text; 
                E_Login.Pass = txtPass.Text;
                E_Login.Nombre1 = txtNombre.Text.ToUpper();
                E_Login.Apellido1 = txtApellido.Text.ToUpper();
                E_Login.Fecha1 = Convert.ToDateTime(dateTimePickerFecha.Text);
                if (radioButtonUser.Checked == true)
                { E_Login.Cargo1 = (radioButtonUser.Text); }
                else
                { E_Login.Cargo1 = (radioButtonAdimin.Text); }


                objNegocio.Editando_N();

                MessageBox.Show("Registro Editado");

                dataGridViewUsers.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Login.ID1 = int.Parse(txtCode.Text);
                E_Login.User = txtUser.Text;

                dataGridViewUsers.DataSource = objNegocio.Buscando_N();
            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Login.ID1 = int.Parse(txtCode.Text);

                objNegocio.Borrando_N();

                MessageBox.Show("Registro Eliminado");

                dataGridViewUsers.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

      
    }
}
