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
    public partial class FrmVisitantes : Form
    {
        private Form OpenContenedor;

        N_Visitas objNegocio = new N_Visitas();

        public FrmVisitantes()
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
                if (tool is PictureBox)
                {
                    tool.Text = "";
                }
            }
        }
      
        private void FrmVisitantes_Load(object sender, EventArgs e)
        {
            if (E_Login.Cargo1 == E_Cargos.General)
            {
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
            }
            dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();
        }
        
        private void OpenPanelConten(Form OpenFrm)
        {
            if (OpenContenedor != null)
            {
                OpenContenedor.Close();
            }
            OpenContenedor = OpenFrm;
            OpenFrm.TopLevel = false;
            OpenFrm.FormBorderStyle = FormBorderStyle.None;
            OpenFrm.Dock = DockStyle.Fill;
            panel1.Controls.Add(OpenFrm);
            panel1.Tag = OpenFrm;
            OpenFrm.BringToFront();
            OpenFrm.Show();



        }
     
        private void label13_Click(object sender, EventArgs e)
        {
            OpenPanelConten(new FrmBusqueda());

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();
            Limpiar();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                E_Visitas.Nombre1 = txtNombre.Text.ToUpper();
                E_Visitas.Apellido1 = txtApellido.Text.ToUpper();
                E_Visitas.Edificio1 = comboBoxEdificio.Text;
                E_Visitas.Aula1 = comboBoxAula.Text;
                E_Visitas.Telefono1 = mskTxtTelefono.Text;
                E_Visitas.FechaEntrada1 = Convert.ToDateTime(dateTimePickerFE.Text);
                E_Visitas.FechaSalida1 = Convert.ToDateTime(dateTimePickerFS.Text);
                E_Visitas.Carrera1 = comboBoxCarrera.Text;
                E_Visitas.Correo1 = mskTxtCorreo.Text;
                E_Visitas.MotivoVisita1 = txtMotivo.Text;
                E_Visitas.Foto1 = ms.GetBuffer();
                E_Visitas.Matricula1 = mskTxtMatricula.Text;
                if (radioButtonEstudiante.Checked == true)
                { E_Visitas.TipoVisitante1 = (radioButtonEstudiante.Text); }
                else
                { E_Visitas.TipoVisitante1 = (radioButtonVisitante.Text); }


                objNegocio.Guardando_N();

                MessageBox.Show("Registro Guardado");

                dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                E_Visitas.Id1 = int.Parse(txtCode.Text);
                E_Visitas.Nombre1 = txtNombre.Text;

                dataGridViewVisitas.DataSource = objNegocio.Buscando_N();
            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                E_Visitas.Nombre1 = txtNombre.Text.ToUpper();
                E_Visitas.Apellido1 = txtApellido.Text.ToUpper();
                E_Visitas.Edificio1 = comboBoxEdificio.Text;
                E_Visitas.Aula1 = comboBoxAula.Text;
                E_Visitas.Telefono1 = mskTxtTelefono.Text;
                E_Visitas.FechaEntrada1 = Convert.ToDateTime(dateTimePickerFE.Text);
                E_Visitas.FechaSalida1 = Convert.ToDateTime(dateTimePickerFS.Text);
                E_Visitas.Carrera1 = comboBoxCarrera.Text;
                E_Visitas.Correo1 = mskTxtCorreo.Text;
                E_Visitas.MotivoVisita1 = txtMotivo.Text;
                E_Visitas.Foto1 = ms.GetBuffer();
                E_Visitas.Matricula1 = mskTxtMatricula.Text;
                if (radioButtonEstudiante.Checked == true)
                { E_Visitas.TipoVisitante1 = (radioButtonEstudiante.Text); }
                else
                { E_Visitas.TipoVisitante1 = (radioButtonVisitante.Text); }


                objNegocio.Editando_N();

                MessageBox.Show("Registro Editar");

                dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                E_Visitas.Id1 = int.Parse(txtCode.Text);

                objNegocio.Borrando_N();

                MessageBox.Show("Registro Eliminado");

                dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

      

        private void pictureBoxFoto_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ft = new OpenFileDialog();
            DialogResult rt = ft.ShowDialog();
            if (rt == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(ft.FileName);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
