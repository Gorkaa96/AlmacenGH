using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlmacenGH
{
    public partial class FormVenta : Form
    {
        public Producto productoActual = null;
        public static List<Ticket> elementosTicket = new List<Ticket>();
        public FormVenta()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
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
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            var producto = Program.gestionAlamacen.BuscarProducto(txtIdentificador.Text, out String mensaje);
            if (mensaje != "")
            {
                txtIdentificador.Text = "";
                lblMostrarDescripcion.Text = "";
                txtCantidad.Text = "";
                productoActual = null;
                MessageBox.Show(mensaje);
            }
            else
            {
                if (elementosTicket.Count()!=0)
                {
                    for (int i = 0; i < elementosTicket.Count(); i++)
                    {
                        if (elementosTicket[i].IdProducto == txtIdentificador.Text)
                        {
                            MessageBox.Show("En esta venta ya se ha incluido el producto " + txtIdentificador.Text);
                            txtIdentificador.Text = "";
                            lblMostrarDescripcion.Text = "";
                        }
                        else
                        {
                            txtIdentificador.Text = producto.Id;
                            lblMostrarDescripcion.Text = producto.Descripcion;
                            productoActual = producto;
                        }
                    }
                }
                else
                {
                    txtIdentificador.Text = producto.Id;
                    lblMostrarDescripcion.Text = producto.Descripcion;
                    productoActual = producto;
                }
            }
        }

        private void btnAceptarVenta_Click(object sender, EventArgs e)
        {
            decimal precioProductoSegunCantidad = 0;
            decimal precioTotal = 0;
            if (lblMostrarDescripcion.Text == "")
            {
                MessageBox.Show("No has elegido ningun producto");
            }
            else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Introduce una cantidad");
                }
                else
                {
                    if (int.TryParse(txtCantidad.Text, out int number) == false)
                    {
                        MessageBox.Show("La cantidad debe de ser un numero entero");
                    }
                    else
                    {
                        if (int.Parse(txtCantidad.Text) > int.Parse(productoActual.Stock.ToString()))
                        {
                            MessageBox.Show(txtCantidad.Text + " supera el stock que está en " + productoActual.Stock.ToString());
                        }
                        else
                        {
                            elementosTicket.Add(new Ticket(0, productoActual.Id.ToString(),productoActual.PrecioVenta.ToString(),txtCantidad.Text));
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = elementosTicket;
                            dataGridView1.Columns["NumTicket"].Visible = false;
                            for (int i = 0; i < elementosTicket.Count(); i++)
                            {
                                precioProductoSegunCantidad = decimal.Parse(elementosTicket[i].PrecioVenta) * decimal.Parse(elementosTicket[i].Cantidad);
                                precioTotal += precioProductoSegunCantidad;
                                lblPrecio.Text = precioTotal.ToString();
                            }
                            txtIdentificador.Text = "";
                            lblMostrarDescripcion.Text = "";
                            txtCantidad.Text = "";
                        }
                    }
                }
            }
        }

        private void btnCancelarVentaProducto_Click(object sender, EventArgs e)
        {
            if (lblMostrarDescripcion.Text == "")
            {
                MessageBox.Show("No has elegido ningun producto");
            }
            else
            {
                txtIdentificador.Text = "";
                lblMostrarDescripcion.Text = "";
                txtCantidad.Text = "";
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("No hay productos seleccionados para comprar");
            }
            else
            {
                txtIdentificador.Text = "";
                lblMostrarDescripcion.Text = "";
                txtCantidad.Text = "";
                lblPrecio.Text = "0";
                elementosTicket.Clear();
                dataGridView1.DataSource = null;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("No hay productos seleccionados para comprar");
            }
            else
            {

                Program.gestionAlamacen.RecivirLista(elementosTicket);
                var msj1 = Program.gestionAlamacen.AñadirTicketEnTickets();
                if (msj1 != "")
                {
                    MessageBox.Show(msj1);
                }
                else
                {
                    var msj3 = "";
                    for (int i = 0; i < elementosTicket.Count(); i++)
                    {
                        var msj2 = Program.gestionAlamacen.AñadirTicketEnTicketsProductos(elementosTicket[i].IdProducto, decimal.Parse(elementosTicket[i].PrecioVenta), elementosTicket[i].Cantidad);
                        if (msj2 != "")
                        {
                            MessageBox.Show(msj2);
                        }
                        else
                        {
                            msj3 = Program.gestionAlamacen.ActualizarStockProducto(elementosTicket[i].IdProducto, elementosTicket[i].Cantidad);
                        }
                    }
                    if (msj3 != "")
                    {
                        MessageBox.Show(msj3);
                    }
                    else
                    {
                            
                                SaveFileDialog sfd = new SaveFileDialog();
                                sfd.Filter = "Archivos de texto|*.txt|Todos los archivos|*.*";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            List<string> nTicket = new List<string>();
                            var emp = Program.gestionAlamacen.BuscarEmpresa(out string msj);
                            nTicket.Add("Empresa: " + emp.Nombre.ToString() + "\n" +
                                "Cif: " + emp.Nif.ToString() + "\n"+
                                "Numero ticket: "+ Program.gestionAlamacen.NumeroDeTicket() + "\n" +
                                    "Fecha: " + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + "\n\n"+
                                    "Total a pagar: "+lblPrecio.Text);
                            
                            File.WriteAllLines(sfd.FileName, nTicket);
                        
                        }      
                    }
                }
                dataGridView1.DataSource = null;
                lblPrecio.Text = "0";
                elementosTicket.Clear();
            }
        }
    }
}
