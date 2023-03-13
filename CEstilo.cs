using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CEstilo : ICalificable
    {
        public string Nombre { get; set; }
        public static List<CEstilo> Estilos = new List<CEstilo>();
        public CEstilo(string _estilo)
        {
            Nombre = _estilo;
            Estilos.Add(this);

        }

        public void ObtenerTemas()
        {

        }
    }
}
