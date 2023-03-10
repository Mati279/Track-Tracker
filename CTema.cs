using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
   
    public class CTema 
    {
        //Lista estática con todos los temas.
        public static List<CTema> temasTotales = new List<CTema> { };

        //Propiedades de cada tema.
        public CPerfil publicador { get; set; }

        public CArtista artista { get; set; }

        public CEstilo estilo { get; set; }

        public string nombre { get; set; }

        public CDisco disco { get; set; }

        public CPaís país { get; set; }

        public double notaTotal { get; set; }


        public CTema(CPerfil _publicador, CArtista _artista, CEstilo _estilo, string _nombre, CDisco _disco, CPaís _país)
        {
            publicador = _publicador;
            artista = _artista; 
            estilo = _estilo;
            nombre = _nombre;
            disco = _disco;
            país = _país;

            _publicador.temasPerfil.Add(this);
            temasTotales.Add(this);
        }

    }
}
