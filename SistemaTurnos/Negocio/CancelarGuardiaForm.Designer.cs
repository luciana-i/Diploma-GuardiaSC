namespace SistemaTurnos.Negocio
{
    partial class CancelarGuardiaForm
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
            this.pnlModalHeader = new System.Windows.Forms.Panel();
            this.lblModalTitulo = new System.Windows.Forms.Label();
            this.pnlModalAbandono = new System.Windows.Forms.Panel();
            this.btnModalConfirmar = new System.Windows.Forms.Button();
            this.btnModalCancelar = new System.Windows.Forms.Button();
            this.pnlModalResumen = new System.Windows.Forms.Panel();
            this.lblModalPaciente = new System.Windows.Forms.Label();
            this.lblModalEpisodioDni = new System.Windows.Forms.Label();
            this.lblModalPregunta = new System.Windows.Forms.Label();
            this.pnlModalHeader.SuspendLayout();
            this.pnlModalAbandono.SuspendLayout();
            this.pnlModalResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlModalHeader
            // 
            this.pnlModalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlModalHeader.Controls.Add(this.lblModalTitulo);
            this.pnlModalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModalHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlModalHeader.Name = "pnlModalHeader";
            this.pnlModalHeader.Size = new System.Drawing.Size(466, 46);
            this.pnlModalHeader.TabIndex = 4;
            // 
            // lblModalTitulo
            // 
            this.lblModalTitulo.AutoSize = true;
            this.lblModalTitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblModalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblModalTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblModalTitulo.Name = "lblModalTitulo";
            this.lblModalTitulo.Size = new System.Drawing.Size(299, 19);
            this.lblModalTitulo.TabIndex = 0;
            this.lblModalTitulo.Text = "⚠ Confirmación de Registro de Abandono";
            // 
            // pnlModalAbandono
            // 
            this.pnlModalAbandono.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlModalAbandono.Controls.Add(this.pnlModalHeader);
            this.pnlModalAbandono.Controls.Add(this.btnModalConfirmar);
            this.pnlModalAbandono.Controls.Add(this.btnModalCancelar);
            this.pnlModalAbandono.Controls.Add(this.pnlModalResumen);
            this.pnlModalAbandono.Controls.Add(this.lblModalPregunta);
            this.pnlModalAbandono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModalAbandono.Location = new System.Drawing.Point(0, 0);
            this.pnlModalAbandono.Name = "pnlModalAbandono";
            this.pnlModalAbandono.Padding = new System.Windows.Forms.Padding(1);
            this.pnlModalAbandono.Size = new System.Drawing.Size(468, 282);
            this.pnlModalAbandono.TabIndex = 2;
            this.pnlModalAbandono.Visible = false;
            // 
            // btnModalConfirmar
            // 
            this.btnModalConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnModalConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModalConfirmar.FlatAppearance.BorderSize = 0;
            this.btnModalConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnModalConfirmar.Location = new System.Drawing.Point(272, 175);
            this.btnModalConfirmar.Name = "btnModalConfirmar";
            this.btnModalConfirmar.Size = new System.Drawing.Size(140, 34);
            this.btnModalConfirmar.TabIndex = 3;
            this.btnModalConfirmar.Text = "Confirmar";
            this.btnModalConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnModalCancelar
            // 
            this.btnModalCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnModalCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModalCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnModalCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnModalCancelar.Location = new System.Drawing.Point(24, 175);
            this.btnModalCancelar.Name = "btnModalCancelar";
            this.btnModalCancelar.Size = new System.Drawing.Size(141, 34);
            this.btnModalCancelar.TabIndex = 2;
            this.btnModalCancelar.Text = "Cancelar";
            this.btnModalCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlModalResumen
            // 
            this.pnlModalResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlModalResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModalResumen.Controls.Add(this.lblModalPaciente);
            this.pnlModalResumen.Controls.Add(this.lblModalEpisodioDni);
            this.pnlModalResumen.Location = new System.Drawing.Point(23, 88);
            this.pnlModalResumen.Name = "pnlModalResumen";
            this.pnlModalResumen.Size = new System.Drawing.Size(389, 70);
            this.pnlModalResumen.TabIndex = 2;
            // 
            // lblModalPaciente
            // 
            this.lblModalPaciente.AutoSize = true;
            this.lblModalPaciente.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblModalPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblModalPaciente.Location = new System.Drawing.Point(12, 39);
            this.lblModalPaciente.Name = "lblModalPaciente";
            this.lblModalPaciente.Size = new System.Drawing.Size(50, 19);
            this.lblModalPaciente.TabIndex = 1;
            this.lblModalPaciente.Text = "label1";
            // 
            // lblModalEpisodioDni
            // 
            this.lblModalEpisodioDni.AutoSize = true;
            this.lblModalEpisodioDni.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModalEpisodioDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblModalEpisodioDni.Location = new System.Drawing.Point(12, 11);
            this.lblModalEpisodioDni.Name = "lblModalEpisodioDni";
            this.lblModalEpisodioDni.Size = new System.Drawing.Size(38, 15);
            this.lblModalEpisodioDni.TabIndex = 0;
            this.lblModalEpisodioDni.Text = "label1";
            // 
            // lblModalPregunta
            // 
            this.lblModalPregunta.AutoSize = true;
            this.lblModalPregunta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblModalPregunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblModalPregunta.Location = new System.Drawing.Point(21, 54);
            this.lblModalPregunta.Name = "lblModalPregunta";
            this.lblModalPregunta.Size = new System.Drawing.Size(426, 19);
            this.lblModalPregunta.TabIndex = 1;
            this.lblModalPregunta.Text = "¿Está seguro de que desea registrar el abandono del paciente?";
            // 
            // CancelarGuardiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 282);
            this.Controls.Add(this.pnlModalAbandono);
            this.Name = "CancelarGuardiaForm";
            this.ShowInTaskbar = false;
            this.Text = "CancelarGuardiaForm";
            this.pnlModalHeader.ResumeLayout(false);
            this.pnlModalHeader.PerformLayout();
            this.pnlModalAbandono.ResumeLayout(false);
            this.pnlModalAbandono.PerformLayout();
            this.pnlModalResumen.ResumeLayout(false);
            this.pnlModalResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlModalHeader;
        private System.Windows.Forms.Label lblModalTitulo;
        private System.Windows.Forms.Panel pnlModalAbandono;
        private System.Windows.Forms.Button btnModalConfirmar;
        private System.Windows.Forms.Button btnModalCancelar;
        private System.Windows.Forms.Panel pnlModalResumen;
        private System.Windows.Forms.Label lblModalPaciente;
        private System.Windows.Forms.Label lblModalEpisodioDni;
        private System.Windows.Forms.Label lblModalPregunta;
    }
}