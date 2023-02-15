using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CPerfil
    {
        public static CPerfil perfilUsuario; //---> Agregué esto como estático ya que todas las formas van a necesitar saberlo.
        public string Nombre { get; set; }

        
        public CPerfil(string _nombre)
        {
            Nombre = _nombre;
        }


    }
}
