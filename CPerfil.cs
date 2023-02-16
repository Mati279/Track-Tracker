using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CPerfil
    {
        public static CPerfil perfilUsuario;
        public string Nombre { get; set; } 

        public CPerfil(string _nombre)
        {
            Nombre = _nombre;
        }


    }
}
