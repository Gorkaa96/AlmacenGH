
namespace AlmacenGH
{
    partial class FormInicial
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeProductosEnBajoStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reponiendoStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosEmpresaToolStripMenuItem,
            this.listadoDeProductosEnBajoStockToolStripMenuItem,
            this.reponiendoStockToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // datosEmpresaToolStripMenuItem
            // 
            this.datosEmpresaToolStripMenuItem.Name = "datosEmpresaToolStripMenuItem";
            this.datosEmpresaToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.datosEmpresaToolStripMenuItem.Text = "Datos Empresa";
            this.datosEmpresaToolStripMenuItem.Click += new System.EventHandler(this.datosEmpresaToolStripMenuItem_Click);
            // 
            // listadoDeProductosEnBajoStockToolStripMenuItem
            // 
            this.listadoDeProductosEnBajoStockToolStripMenuItem.Name = "listadoDeProductosEnBajoStockToolStripMenuItem";
            this.listadoDeProductosEnBajoStockToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.listadoDeProductosEnBajoStockToolStripMenuItem.Text = "Listado de Productos en bajo stock";
            this.listadoDeProductosEnBajoStockToolStripMenuItem.Click += new System.EventHandler(this.listadoDeProductosEnBajoStockToolStripMenuItem_Click);
            // 
            // reponiendoStockToolStripMenuItem
            // 
            this.reponiendoStockToolStripMenuItem.Name = "reponiendoStockToolStripMenuItem";
            this.reponiendoStockToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.reponiendoStockToolStripMenuItem.Text = "Reponiendo stock";
            this.reponiendoStockToolStripMenuItem.Click += new System.EventHandler(this.reponiendoStockToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(320, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormInicial";
            this.Text = "Inicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeProductosEnBajoStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reponiendoStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

