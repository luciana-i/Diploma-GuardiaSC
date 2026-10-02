using System;

namespace SistemaTurnos
{
    partial class MenuPrincipalForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desbloqueoDeUsuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarMailAnteriorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionPerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarPerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarPerfilesAUsuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarIdiomaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarIdiomaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.admisionPacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.admisionGuardiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enfermeriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaEsperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicoGuardiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaEsperaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorToolStripMenuItem,
            this.admisionPacientesToolStripMenuItem,
            this.enfermeriaToolStripMenuItem,
            this.medicoGuardiaToolStripMenuItem,
            this.gestionarIdiomaToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.gestionPerfilesToolStripMenuItem,
            this.bitacoraToolStripMenuItem1,
            this.seleccionarIdiomaToolStripMenuItem1,
            this.gEToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1700, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarMailToolStripMenuItem,
            this.cambiarClaveToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.administradorToolStripMenuItem.Tag = "USUARIO_BASICO";
            this.administradorToolStripMenuItem.Text = "Usuario";
            this.administradorToolStripMenuItem.Click += new System.EventHandler(this.administradorToolStripMenuItem_Click);
            // 
            // modificarMailToolStripMenuItem
            // 
            this.modificarMailToolStripMenuItem.Name = "modificarMailToolStripMenuItem";
            this.modificarMailToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.modificarMailToolStripMenuItem.Tag = "MODIFICAR_MAIL";
            this.modificarMailToolStripMenuItem.Text = "Modificar Mail";
            this.modificarMailToolStripMenuItem.Click += new System.EventHandler(this.modificarMailToolStripMenuItem_Click);
            // 
            // cambiarClaveToolStripMenuItem
            // 
            this.cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            this.cambiarClaveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cambiarClaveToolStripMenuItem.Tag = "MODIFICAR_CLAVE";
            this.cambiarClaveToolStripMenuItem.Text = "Cambiar Clave";
            this.cambiarClaveToolStripMenuItem.Click += new System.EventHandler(this.cambiarClaveToolStripMenuItem_Click_1);
            // 
            // gEToolStripMenuItem
            // 
            this.gEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desbloqueoDeUsuarioToolStripMenuItem1,
            this.crearUsuariosToolStripMenuItem1,
            this.restaurarMailAnteriorToolStripMenuItem1});
            this.gEToolStripMenuItem.Name = "gEToolStripMenuItem";
            this.gEToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.gEToolStripMenuItem.Tag = "GESTION_USUARIOS_MENU";
            this.gEToolStripMenuItem.Text = "Gestion Usuarios";
            // 
            // desbloqueoDeUsuarioToolStripMenuItem1
            // 
            this.desbloqueoDeUsuarioToolStripMenuItem1.Name = "desbloqueoDeUsuarioToolStripMenuItem1";
            this.desbloqueoDeUsuarioToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.desbloqueoDeUsuarioToolStripMenuItem1.Tag = "DESBLOQUEAR_USUARIO";
            this.desbloqueoDeUsuarioToolStripMenuItem1.Text = "Desbloqueo de Usuario";
            this.desbloqueoDeUsuarioToolStripMenuItem1.Click += new System.EventHandler(this.desbloqueoDeUsuarioToolStripMenuItem1_Click);
            // 
            // crearUsuariosToolStripMenuItem1
            // 
            this.crearUsuariosToolStripMenuItem1.Name = "crearUsuariosToolStripMenuItem1";
            this.crearUsuariosToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.crearUsuariosToolStripMenuItem1.Tag = "CREAR_USUARIO";
            this.crearUsuariosToolStripMenuItem1.Text = "Crear Usuarios";
            this.crearUsuariosToolStripMenuItem1.Click += new System.EventHandler(this.crearUsuariosToolStripMenuItem1_Click);
            // 
            // restaurarMailAnteriorToolStripMenuItem1
            // 
            this.restaurarMailAnteriorToolStripMenuItem1.Name = "restaurarMailAnteriorToolStripMenuItem1";
            this.restaurarMailAnteriorToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.restaurarMailAnteriorToolStripMenuItem1.Tag = "HISTORIAL_CONTROL_CAMBIOS";
            this.restaurarMailAnteriorToolStripMenuItem1.Text = "Restaurar Mail Anterior";
            this.restaurarMailAnteriorToolStripMenuItem1.Click += new System.EventHandler(this.restaurarMailAnteriorToolStripMenuItem1_Click);
            // 
            // gestionPerfilesToolStripMenuItem
            // 
            this.gestionPerfilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarPerfilesToolStripMenuItem,
            this.asignarToolStripMenuItem,
            this.asignarPerfilesAUsuarioToolStripMenuItem1});
            this.gestionPerfilesToolStripMenuItem.Name = "gestionPerfilesToolStripMenuItem";
            this.gestionPerfilesToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.gestionPerfilesToolStripMenuItem.Tag = "GESTION_PERFILES_MENU";
            this.gestionPerfilesToolStripMenuItem.Text = "Gestion Perfiles";
            // 
            // gestionarPerfilesToolStripMenuItem
            // 
            this.gestionarPerfilesToolStripMenuItem.Name = "gestionarPerfilesToolStripMenuItem";
            this.gestionarPerfilesToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.gestionarPerfilesToolStripMenuItem.Tag = "GESTION_PERFILES";
            this.gestionarPerfilesToolStripMenuItem.Text = "Gestionar Perfiles";
            this.gestionarPerfilesToolStripMenuItem.Click += new System.EventHandler(this.gestionarPerfilesToolStripMenuItem_Click);
            // 
            // asignarToolStripMenuItem
            // 
            this.asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            this.asignarToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.asignarToolStripMenuItem.Tag = "ASIGNAR_FAMILIAS";
            this.asignarToolStripMenuItem.Text = "Asignar Familias de Permisos";
            this.asignarToolStripMenuItem.Click += new System.EventHandler(this.asignarToolStripMenuItem_Click);
            // 
            // asignarPerfilesAUsuarioToolStripMenuItem1
            // 
            this.asignarPerfilesAUsuarioToolStripMenuItem1.Name = "asignarPerfilesAUsuarioToolStripMenuItem1";
            this.asignarPerfilesAUsuarioToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.asignarPerfilesAUsuarioToolStripMenuItem1.Tag = "ASIGNAR_USUARIO_PERFIL";
            this.asignarPerfilesAUsuarioToolStripMenuItem1.Text = "Asignar Perfiles a Usuario";
            this.asignarPerfilesAUsuarioToolStripMenuItem1.Click += new System.EventHandler(this.asignarPerfilesAUsuarioToolStripMenuItem1_Click);
            // 
            // bitacoraToolStripMenuItem1
            // 
            this.bitacoraToolStripMenuItem1.Name = "bitacoraToolStripMenuItem1";
            this.bitacoraToolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.bitacoraToolStripMenuItem1.Tag = "BITACORA";
            this.bitacoraToolStripMenuItem1.Text = "Bitacora";
            this.bitacoraToolStripMenuItem1.Click += new System.EventHandler(this.bitacoraToolStripMenuItem1_Click);
            // 
            // gestionarIdiomaToolStripMenuItem
            // 
            this.gestionarIdiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarIdiomaToolStripMenuItem1});
            this.gestionarIdiomaToolStripMenuItem.Name = "gestionarIdiomaToolStripMenuItem";
            this.gestionarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.gestionarIdiomaToolStripMenuItem.Tag = "IDIOMA_MENU";
            this.gestionarIdiomaToolStripMenuItem.Text = "Idioma";
            // 
            // gestionarIdiomaToolStripMenuItem1
            // 
            this.gestionarIdiomaToolStripMenuItem1.Name = "gestionarIdiomaToolStripMenuItem1";
            this.gestionarIdiomaToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.gestionarIdiomaToolStripMenuItem1.Tag = "GESTIONAR_IDIOMA";
            this.gestionarIdiomaToolStripMenuItem1.Text = "Gestionar Idioma";
            this.gestionarIdiomaToolStripMenuItem1.Click += new System.EventHandler(this.gestionarIdiomaToolStripMenuItem1_Click);
            // 
            // seleccionarIdiomaToolStripMenuItem1
            // 
            this.seleccionarIdiomaToolStripMenuItem1.Name = "seleccionarIdiomaToolStripMenuItem1";
            this.seleccionarIdiomaToolStripMenuItem1.Size = new System.Drawing.Size(119, 20);
            this.seleccionarIdiomaToolStripMenuItem1.Tag = "SELECCION_IDIOMA";
            this.seleccionarIdiomaToolStripMenuItem1.Text = "Seleccionar Idioma";
            this.seleccionarIdiomaToolStripMenuItem1.Click += new System.EventHandler(this.seleccionarIdiomaToolStripMenuItem1_Click);
            // 
            // admisionPacientesToolStripMenuItem
            // 
            this.admisionPacientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.admisionGuardiaToolStripMenuItem});
            this.admisionPacientesToolStripMenuItem.Name = "admisionPacientesToolStripMenuItem";
            this.admisionPacientesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.admisionPacientesToolStripMenuItem.Tag = "RECEPCIONISTA";
            this.admisionPacientesToolStripMenuItem.Text = "Recepcionista";
            // 
            // admisionGuardiaToolStripMenuItem
            // 
            this.admisionGuardiaToolStripMenuItem.Name = "admisionGuardiaToolStripMenuItem";
            this.admisionGuardiaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.admisionGuardiaToolStripMenuItem.Tag = "RES_ADMISION";
            this.admisionGuardiaToolStripMenuItem.Text = "Admision Guardia";
            this.admisionGuardiaToolStripMenuItem.Click += new System.EventHandler(this.admisionGuardiaToolStripMenuItem_Click);
            // 
            // enfermeriaToolStripMenuItem
            // 
            this.enfermeriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaEsperaToolStripMenuItem});
            this.enfermeriaToolStripMenuItem.Name = "enfermeriaToolStripMenuItem";
            this.enfermeriaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.enfermeriaToolStripMenuItem.Tag = "ENFERMERIA";
            this.enfermeriaToolStripMenuItem.Text = "Enfermeria";
            // 
            // listaEsperaToolStripMenuItem
            // 
            this.listaEsperaToolStripMenuItem.Name = "listaEsperaToolStripMenuItem";
            this.listaEsperaToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.listaEsperaToolStripMenuItem.Tag = "ENFERMERIA_LISTA";
            this.listaEsperaToolStripMenuItem.Text = "Lista Espera";
            this.listaEsperaToolStripMenuItem.Click += new System.EventHandler(this.listaEsperaToolStripMenuItem_Click);
            // 
            // medicoGuardiaToolStripMenuItem
            // 
            this.medicoGuardiaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaEsperaToolStripMenuItem1});
            this.medicoGuardiaToolStripMenuItem.Name = "medicoGuardiaToolStripMenuItem";
            this.medicoGuardiaToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.medicoGuardiaToolStripMenuItem.Tag = "MEDICO";
            this.medicoGuardiaToolStripMenuItem.Text = "Medico Guardia";
            // 
            // listaEsperaToolStripMenuItem1
            // 
            this.listaEsperaToolStripMenuItem1.Name = "listaEsperaToolStripMenuItem1";
            this.listaEsperaToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.listaEsperaToolStripMenuItem1.Tag = "MEDICO_LISTA";
            this.listaEsperaToolStripMenuItem1.Text = "Lista Espera";
            this.listaEsperaToolStripMenuItem1.Click += new System.EventHandler(this.listaEsperaToolStripMenuItem1_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarEmpleadosToolStripMenuItem});
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // agregarEmpleadosToolStripMenuItem
            // 
            this.agregarEmpleadosToolStripMenuItem.Name = "agregarEmpleadosToolStripMenuItem";
            this.agregarEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarEmpleadosToolStripMenuItem.Tag = "EMPLEADOS_ADD";
            this.agregarEmpleadosToolStripMenuItem.Text = "Agregar Empleados";
            this.agregarEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.agregarEmpleadosToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesionToolStripMenuItem.Tag = "CERRAR_SESION";
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 721);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipalForm";
            this.Tag = "MenuForm";
            this.Text = "MenuForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipalForm_FormClosing);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestionarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarIdiomaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionPerfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desbloqueoDeUsuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem crearUsuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restaurarMailAnteriorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestionarPerfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarPerfilesAUsuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem seleccionarIdiomaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem admisionPacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem admisionGuardiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enfermeriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaEsperaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicoGuardiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaEsperaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarEmpleadosToolStripMenuItem;
    }
}