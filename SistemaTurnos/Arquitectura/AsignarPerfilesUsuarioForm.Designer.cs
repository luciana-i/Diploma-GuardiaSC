namespace SistemaTurnos
{
    partial class AsignarPerfilesUsuarioForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEliminarPerfil = new System.Windows.Forms.Button();
            this.btnAgregarPerfil = new System.Windows.Forms.Button();
            this.btnBuscarPerfil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPermisos = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEliminarPerfil);
            this.panel2.Controls.Add(this.btnAgregarPerfil);
            this.panel2.Controls.Add(this.btnBuscarPerfil);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbUsuarios);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbPermisos);
            this.panel2.Location = new System.Drawing.Point(23, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 367);
            this.panel2.TabIndex = 3;
            // 
            // btnEliminarPerfil
            // 
            this.btnEliminarPerfil.Location = new System.Drawing.Point(14, 295);
            this.btnEliminarPerfil.Name = "btnEliminarPerfil";
            this.btnEliminarPerfil.Size = new System.Drawing.Size(260, 23);
            this.btnEliminarPerfil.TabIndex = 4;
            this.btnEliminarPerfil.Tag = "AsigEliminarPerfil";
            this.btnEliminarPerfil.Text = "Eliminar Perfil";
            this.btnEliminarPerfil.UseVisualStyleBackColor = true;
            this.btnEliminarPerfil.Click += new System.EventHandler(this.btnEliminarPerfil_Click);
            // 
            // btnAgregarPerfil
            // 
            this.btnAgregarPerfil.Location = new System.Drawing.Point(14, 256);
            this.btnAgregarPerfil.Name = "btnAgregarPerfil";
            this.btnAgregarPerfil.Size = new System.Drawing.Size(260, 23);
            this.btnAgregarPerfil.TabIndex = 3;
            this.btnAgregarPerfil.Tag = "AsigAgregarPerfil";
            this.btnAgregarPerfil.Text = "Agregar Perfil";
            this.btnAgregarPerfil.UseVisualStyleBackColor = true;
            this.btnAgregarPerfil.Click += new System.EventHandler(this.btnAgregarPerfil_Click);
            // 
            // btnBuscarPerfil
            // 
            this.btnBuscarPerfil.Location = new System.Drawing.Point(14, 71);
            this.btnBuscarPerfil.Name = "btnBuscarPerfil";
            this.btnBuscarPerfil.Size = new System.Drawing.Size(260, 23);
            this.btnBuscarPerfil.TabIndex = 2;
            this.btnBuscarPerfil.Tag = "AsigBuscarPerfiles";
            this.btnBuscarPerfil.Text = "Buscar perfiles disponibles";
            this.btnBuscarPerfil.UseVisualStyleBackColor = true;
            this.btnBuscarPerfil.Click += new System.EventHandler(this.btnBuscarPerfil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "AsigNombreUsuario";
            this.label1.Text = "Nombre de Usuario";
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.FormattingEnabled = true;
            this.cbUsuarios.Location = new System.Drawing.Point(14, 44);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(260, 21);
            this.cbUsuarios.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 0;
            this.label3.Tag = "AsigPerfilesDisp";
            this.label3.Text = "Permisos disponibles";
            // 
            // cbPermisos
            // 
            this.cbPermisos.FormattingEnabled = true;
            this.cbPermisos.Location = new System.Drawing.Point(14, 212);
            this.cbPermisos.Name = "cbPermisos";
            this.cbPermisos.Size = new System.Drawing.Size(260, 21);
            this.cbPermisos.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(394, 38);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(373, 367);
            this.treeView1.TabIndex = 4;
            // 
            // AsignarPerfilesUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel2);
            this.Name = "AsignarPerfilesUsuarioForm";
            this.Tag = "AsignarPerfilesUsuarioForm";
            this.Text = "AsignarPerfilesUsuarioForm";
            this.Load += new System.EventHandler(this.AsignarPerfilesUsuarioForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBuscarPerfil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPermisos;
        private System.Windows.Forms.Button btnEliminarPerfil;
        private System.Windows.Forms.Button btnAgregarPerfil;
        private System.Windows.Forms.TreeView treeView1;
    }
}