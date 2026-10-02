using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    internal class PermisoTag
    {   // esta clase se creo para tener los permisos en memoria sin tocar el composite de permisos, para poder crear un perfil y que tenga ciertos permisos
        // si el usuario escribe puede equivocarse en una letra, pero si la obtiene de un combo, no. Esta clase llena una lista que llena al combo del form
        public static readonly string[] PermisosNombreTags = new string[]
        {
    
            "GESTION_PERFILES", 
            "DESBLOQUEAR_USUARIO", 
            "CREAR_USUARIO", 
            "ASIGNAR_FAMILIAS", 
            "ASIGNAR_USUARIO_PERFIL", 
            "BITACORA", 
            "IDIOMA_MENU", 
            "SELECCION_IDIOMA", 
            "GESTIONAR_IDIOMA", 
            "MODIFICAR_MAIL", 
            "MODIFICAR_CLAVE", 
            "HISTORIAL_CONTROL_CAMBIOS", 
            "RESTAURAR_INTEGRIDAD", 
            "CERRAR_SESION", 
            "GESTION_USUARIOS_MENU", 
            "GESTION_PERFILES_MENU",  
            "USUARIO_BASICO", // menu
            "ADMIN_FULL",
            "ADMIN_BASICO",
            "RECEPCIONISTA",
            "EMPLEADOS",
            "RES_ADMISION",
            "ENFERMERIA",
            "ENFERMERIA_LISTA",
            "ENFERMERIA_ATENCION",
            "MEDICO",
            "MEDICO_LISTA",
            "MEDICO_ATENCION",
            "GERENCIAL"
        };
    }
}

