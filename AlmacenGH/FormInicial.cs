using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlmacenGH
{
    public partial class FormInicial : Form
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        private void listadoDeProductosEnBajoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListaProductosBajoStock frm = new FormListaProductosBajoStock();
            frm.Show();
        }

        private void datosEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDatosEmpresa frm = new FormDatosEmpresa();
            frm.Show();
        }

        private void reponiendoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (Program.gestionAlamacen.LeerFichero(openFileDialog1.FileName.ToString()) != "")
            {
                MessageBox.Show(Program.gestionAlamacen.LeerFichero(openFileDialog1.FileName.ToString()));
            }
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
