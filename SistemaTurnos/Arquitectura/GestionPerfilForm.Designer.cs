namespace SistemaTurnos
{
    partial class GestionPerfilForm
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
            this.treeViewFamilias = new System.Windows.Forms.TreeView();
            this.groupBoxArbol = new System.Windows.Forms.GroupBox();
            this.btnQuitarHijo = new System.Windows.Forms.Button();
            this.btnAgregarHijo = new System.Windows.Forms.Button();
            this.treeViewPerfilesPosibles = new System.Windows.Forms.TreeView();
            this.groupBoxArbolEdicion = new System.Windows.Forms.GroupBox();
            this.groupBoxArbol.SuspendLayout();
            this.groupBoxArbolEdicion.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewFamilias
            // 
            this.treeViewFamilias.Location = new System.Drawing.Point(12, 19);
            this.treeViewFamilias.Name = "treeViewFamilias";
            this.treeViewFamilias.Size = new System.Drawing.Size(386, 400);
            this.treeViewFamilias.TabIndex = 0;
            this.treeViewFamilias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFamilias_AfterSelect);
            // 
            // groupBoxArbol
            // 
            this.groupBoxArbol.Controls.Add(this.treeViewFamilias);
            this.groupBoxArbol.Location = new System.Drawing.Point(40, 30);
            this.groupBoxArbol.Name = "groupBoxArbol";
            this.groupBoxArbol.Size = new System.Drawing.Size(414, 442);
            this.groupBoxArbol.TabIndex = 3;
            this.groupBoxArbol.TabStop = false;
            this.groupBoxArbol.Tag = "PerfilesFamiliaPanel";
            this.groupBoxArbol.Text = "Seleccione la Familia de perfiles para editar";
            // 
            // btnQuitarHijo
            // 
            this.btnQuitarHijo.Location = new System.Drawing.Point(479, 307);
            this.btnQuitarHijo.Name = "btnQuitarHijo";
            this.btnQuitarHijo.Size = new System.Drawing.Size(179, 66);
            this.btnQuitarHijo.TabIndex = 5;
            this.btnQuitarHijo.Tag = "PerfilesQuitar";
            this.btnQuitarHijo.Text = ">> Quitar del Perfil Seleccionado";
            this.btnQuitarHijo.UseVisualStyleBackColor = true;
            this.btnQuitarHijo.Click += new System.EventHandler(this.btnQuitarHijo_Click);
            // 
            // btnAgregarHijo
            // 
            this.btnAgregarHijo.Location = new System.Drawing.Point(479, 135);
            this.btnAgregarHijo.Name = "btnAgregarHijo";
            this.btnAgregarHijo.Size = new System.Drawing.Size(179, 66);
            this.btnAgregarHijo.TabIndex = 5;
            this.btnAgregarHijo.Tag = "PerfilesAgregar";
            this.btnAgregarHijo.Text = "<< Agregar al Perfil Seleccionado";
            this.btnAgregarHijo.UseVisualStyleBackColor = true;
            this.btnAgregarHijo.Click += new System.EventHandler(this.btnAgregarHijo_Click);
            // 
            // treeViewPerfilesPosibles
            // 
            this.treeViewPerfilesPosibles.Location = new System.Drawing.Point(18, 19);
            this.treeViewPerfilesPosibles.Name = "treeViewPerfilesPosibles";
            this.treeViewPerfilesPosibles.Size = new System.Drawing.Size(415, 400);
            this.treeViewPerfilesPosibles.TabIndex = 1;
            // 
            // groupBoxArbolEdicion
            // 
            this.groupBoxArbolEdicion.Controls.Add(this.treeViewPerfilesPosibles);
            this.groupBoxArbolEdicion.Location = new System.Drawing.Point(673, 30);
            this.groupBoxArbolEdicion.Name = "groupBoxArbolEdicion";
            this.groupBoxArbolEdicion.Size = new System.Drawing.Size(456, 442);
            this.groupBoxArbolEdicion.TabIndex = 6;
            this.groupBoxArbolEdicion.TabStop = false;
            this.groupBoxArbolEdicion.Tag = "PerfilesPosibles";
            this.groupBoxArbolEdicion.Text = "Perfiles posibles de elegir";
            // 
            // GestionPerfilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 492);
            this.Controls.Add(this.groupBoxArbolEdicion);
            this.Controls.Add(this.btnQuitarHijo);
            this.Controls.Add(this.btnAgregarHijo);
            this.Controls.Add(this.groupBoxArbol);
            this.Name = "GestionPerfilForm";
            this.Text = "PerfilesForm";
            this.groupBoxArbol.ResumeLayout(false);
            this.groupBoxArbolEdicion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFamilias;
        private System.Windows.Forms.GroupBox groupBoxArbol;
        private System.Windows.Forms.Button btnQuitarHijo;
        private System.Windows.Forms.Button btnAgregarHijo;
        private System.Windows.Forms.TreeView treeViewPerfilesPosibles;
        private System.Windows.Forms.GroupBox groupBoxArbolEdicion;
    }
}