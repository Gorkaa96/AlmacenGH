using Entidades;
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
    public partial class FormListaProductosBajoStock : Form
    {
        public FormListaProductosBajoStock()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormListaProductosBajoStock_Load(object sender, EventArgs e)
        {
            lblFecha.Text += " " + DateTime.Today.Day.ToString()+"/"+ DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
             var empresa = Program.gestionAlamacen.BuscarEmpresa(out String mensaje);
            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
                lblNombreEmpresa.Text = "";
                picBoxLogo.Image = null;
            }
            else
            {
                lblNombreEmpresa.Text = empresa.Nombre;
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
                List<Producto> prods = Program.gestionAlamacen.ProductosBajoStock(out String msj);
                if (msj != "")
                {
                    MessageBox.Show(msj+" en la fecha "+ DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
                    Close();
                }
                else
                {
                    if (prods.Count() == 1)
                    {
                        dgvProductosBajoStock.Hide();
                        txtId.Text = prods[0].Id;
                        txtDescripcion.Text = prods[0].Descripcion;
                        txtStock.Text = prods[0].Stock.ToString();
                        txtStockMinimo.Text = prods[0].StockMinimo.ToString();
                        txtPrecioCompra.Text = prods[0].PrecioCompra.ToString();
                        txtPrecioVenta.Text = prods[0].PrecioVenta.ToString();
                        
                    }
                    else
                    {
                        txtId.Hide();
                        txtDescripcion.Hide();
                        txtStock.Hide();
                        txtStockMinimo.Hide();
                        txtPrecioCompra.Hide();
                        txtPrecioVenta.Hide();
                        lblId.Hide();
                        lblDescripcion.Hide();
                        lblStock.Hide();
                        lblStockMinimo.Hide();
                        lblPrecioCompra.Hide();
                        lblPrecioVenta.Hide();
                        dgvProductosBajoStock.DataSource = prods;
                    }
                }
            }
            //List<Empresa> productosBajoStock = Program.gestionAlamacen.BuscarCuentas(txtBuscarCuentasPorDNI.Text, out String mensaje);
            //dgvProductosBajoStock.DataSource = productosBajoStock;
            // if (mensaje != "")
            //{
            //MessageBox.Show(mensaje);
            //}
        }

        
    }
}
