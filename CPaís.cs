using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CPaís : ICalificable
    {
        public string Nombre { get; set; }

        public static List<CPaís> Países = new List<CPaís>();

        public CPaís(string _nombre)
        {
            Nombre = _nombre;
            Países.Add(this);

        }
        public void ObtenerTemas()
        {

        }
        public override string ToString()
        {
            return Nombre;
        }



    }
}
