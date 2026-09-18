namespace SistemaTurnos
{
    partial class CambiarClaveForm
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
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.titulolbl = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNueva = new System.Windows.Forms.TextBox();
            this.txtVieja = new System.Windows.Forms.TextBox();
            this.contNuevaLbl = new System.Windows.Forms.Label();
            this.contActualLbl = new System.Windows.Forms.Label();
            this.pnlFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.Controls.Add(this.titulolbl);
            this.pnlFondo.Controls.Add(this.btnAceptar);
            this.pnlFondo.Controls.Add(this.btnCancelar);
            this.pnlFondo.Controls.Add(this.txtNueva);
            this.pnlFondo.Controls.Add(this.txtVieja);
            this.pnlFondo.Controls.Add(this.contNuevaLbl);
            this.pnlFondo.Controls.Add(this.contActualLbl);
            this.pnlFondo.Location = new System.Drawing.Point(76, 58);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Size = new System.Drawing.Size(547, 304);
            this.pnlFondo.TabIndex = 0;
            // 
            // titulolbl
            // 
            this.titulolbl.AutoSize = true;
            this.titulolbl.ForeColor = System.Drawing.Color.Black;
            this.titulolbl.Location = new System.Drawing.Point(41, 33);
            this.titulolbl.Name = "titulolbl";
            this.titulolbl.Size = new System.Drawing.Size(250, 13);
            this.titulolbl.TabIndex = 6;
            this.titulolbl.Tag = "ClaveText";
            this.titulolbl.Text = "Para cambiar la clave debera completar lo siguiente";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(44, 167);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(337, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Tag = "ClaveUpdate";
            this.btnAceptar.Text = "Actualizar Contraseña";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(44, 228);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(337, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Tag = "ClaveCancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNueva
            // 
            this.txtNueva.Location = new System.Drawing.Point(183, 119);
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.Size = new System.Drawing.Size(198, 20);
            this.txtNueva.TabIndex = 3;
            // 
            // txtVieja
            // 
            this.txtVieja.Location = new System.Drawing.Point(183, 82);
            this.txtVieja.Name = "txtVieja";
            this.txtVieja.Size = new System.Drawing.Size(198, 20);
            this.txtVieja.TabIndex = 2;
            // 
            // contNuevaLbl
            // 
            this.contNuevaLbl.AutoSize = true;
            this.contNuevaLbl.Location = new System.Drawing.Point(41, 119);
            this.contNuevaLbl.Name = "contNuevaLbl";
            this.contNuevaLbl.Size = new System.Drawing.Size(93, 13);
            this.contNuevaLbl.TabIndex = 1;
            this.contNuevaLbl.Tag = "ClaveNueva";
            this.contNuevaLbl.Text = "Contraseña actual";
            // 
            // contActualLbl
            // 
            this.contActualLbl.AutoSize = true;
            this.contActualLbl.Location = new System.Drawing.Point(41, 82);
            this.contActualLbl.Name = "contActualLbl";
            this.contActualLbl.Size = new System.Drawing.Size(93, 13);
            this.contActualLbl.TabIndex = 0;
            this.contActualLbl.Tag = "ClaveActual";
            this.contActualLbl.Text = "Contraseña actual";
            // 
            // CambiarClaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 454);
            this.Controls.Add(this.pnlFondo);
            this.Name = "CambiarClaveForm";
            this.Tag = "CambiarClaveForm";
            this.Text = "CambiarClave";
            this.Load += new System.EventHandler(this.CambiarClaveForm_Load);
            this.pnlFondo.ResumeLayout(false);
            this.pnlFondo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Label contActualLbl;
        private System.Windows.Forms.Label contNuevaLbl;
        private System.Windows.Forms.TextBox txtNueva;
        private System.Windows.Forms.TextBox txtVieja;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label titulolbl;
    }
}