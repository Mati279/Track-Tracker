using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CArtista : ICalificable
    {
        public string Nombre { get; set; }
        public CPaís País { get; set; }
        public int Año { get; set; }
        public CEstilo Estilo { get; set; }

        public static List<CArtista> Artistas = new List<CArtista>();

        public List<CDisco> Discos = new List<CDisco>();

        public List<CTema> temasArtista = new List<CTema>();
        public CArtista(string _nombre, int _año, CPaís _país, CEstilo _estilo)
        {
            Nombre = _nombre;
            Año = _año;
            País = _país;
            Estilo = _estilo;

            Artistas.Add(this);
        }


        //Implementación de métodos de ICalificable. 

        //Obtiene los temas publicados por este Perfil.
        public void ObtenerTemas()
        {
            
        }

        public void ObtenerDisco(CDisco _disco)
        {
            Discos.Add(_disco);

        }



        //Obtiene el promedio de los temas publicados por este Perfil.
        public double ObtenerPromedio()
        {
            int contador = 0;
            double notas = 0;
            double promedio = 0;

            this.ObtenerTemas();

            //foreach (CTema tema in temasPerfil)
            //{
            //    contador++;
            //    notas += tema.notaTotal;
            //}
            //promedio = notas / contador;
            return promedio;
        }

     
    }
}
