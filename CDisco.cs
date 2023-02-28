using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CDisco : ICalificable
    {
        public string Nombre { get; set; }

        public static List<CDisco> Discos = new List<CDisco>();

        public int Año { get; set; }

        public CEstilo estilo = null;

        public CArtista artista = null;
        public CDisco (string _nombre, int _año, CEstilo _estilo, CArtista _artista)
        {

            Nombre = _nombre;
            Año = _año;
            estilo = _estilo;
            artista = _artista;
            
        }

        public void ObtenerTemas()
        {
            
        }
    }
}
