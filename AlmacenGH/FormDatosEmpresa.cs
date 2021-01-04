using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlmacenGH
{
    public partial class FormDatosEmpresa : Form
    {

        public FormDatosEmpresa()
        {
            InitializeComponent();
        }

        private void FormDatosEmpresa_Load(object sender, EventArgs e)
        {
            var empresa = Program.gestionAlamacen.BuscarEmpresa(out String mensaje);
            if (mensaje!="")
            {
                txtNif.Text = "";
                txtNombre.Text = "";
                picBoxLogo.Image = null;
                MessageBox.Show(mensaje);
            }
            else
            {
                    txtNif.Text = empresa.Nif;
                    txtNombre.Text = empresa.Nombre;
                    txtLogoUrl.Text = empresa.Logo;
                try
                {
                    var request = WebRequest.Create(empresa.Logo);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        picBoxLogo.Image = Image.FromStream(stream);
                        picBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch (Exception)
                {
                    picBoxLogo.Image = null;
                }

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mensaje = Program.gestionAlamacen.AgregarModificarEmpresa(txtNif.Text, txtNombre.Text, txtLogoUrl.Text);
            if (mensaje == "")
            {

                MessageBox.Show("No se ha modificado nada");

            }
            else
            {
                try
                {
                    var empresa = Program.gestionAlamacen.BuscarEmpresa(out String men);
                    var request = WebRequest.Create(empresa.Logo);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        picBoxLogo.Image = Image.FromStream(stream);
                        picBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    MessageBox.Show(mensaje);
                }
                catch (Exception)
                {
                    picBoxLogo.Image = null;
                    MessageBox.Show(mensaje);
                }

            }      
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
