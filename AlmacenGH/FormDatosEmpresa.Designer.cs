
namespace AlmacenGH
{
    partial class FormDatosEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNif = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.txtLogoUrl = new System.Windows.Forms.TextBox();
            this.lblLogoUrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNif
            // 
            this.lblNif.AutoSize = true;
            this.lblNif.Location = new System.Drawing.Point(247, 78);
            this.lblNif.Name = "lblNif";
            this.lblNif.Size = new System.Drawing.Size(25, 17);
            this.lblNif.TabIndex = 0;
            this.lblNif.Text = "Nif";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(247, 222);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(40, 17);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "Logo";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(247, 145);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNif
            // 
            this.txtNif.Location = new System.Drawing.Point(331, 78);
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(193, 22);
            this.txtNif.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(331, 140);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(193, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(245, 374);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(121, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(420, 374);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(121, 50);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLogo.Location = new System.Drawing.Point(331, 194);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(126, 108);
            this.picBoxLogo.TabIndex = 10;
            this.picBoxLogo.TabStop = false;
            // 
            // txtLogoUrl
            // 
            this.txtLogoUrl.Location = new System.Drawing.Point(147, 321);
            this.txtLogoUrl.Name = "txtLogoUrl";
            this.txtLogoUrl.Size = new System.Drawing.Size(524, 22);
            this.txtLogoUrl.TabIndex = 11;
            // 
            // lblLogoUrl
            // 
            this.lblLogoUrl.AutoSize = true;
            this.lblLogoUrl.Location = new System.Drawing.Point(144, 301);
            this.lblLogoUrl.Name = "lblLogoUrl";
            this.lblLogoUrl.Size = new System.Drawing.Size(72, 17);
            this.lblLogoUrl.TabIndex = 12;
            this.lblLogoUrl.Text = "Logo URL";
            // 
            // FormDatosEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLogoUrl);
            this.Controls.Add(this.txtLogoUrl);
            this.Controls.Add(this.picBoxLogo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtNif);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblNif);
            this.Name = "FormDatosEmpresa";
            this.Text = "Datos de la empresa";
            this.Load += new System.EventHandler(this.FormDatosEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNif;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNif;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.TextBox txtLogoUrl;
        private System.Windows.Forms.Label lblLogoUrl;
    }
}