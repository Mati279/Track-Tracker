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
        public string País { get; set; }
        public int Año { get; set; }
        public CEstilo Estilo { get; set; }

        public List<CTema> temasArtista = new List<CTema>();
        public CArtista()
        {

        }


        //Implementación de métodos de ICalificable. 

        //Obtiene los temas publicados por este Perfil.
        public void ObtenerTemas()
        {
            
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
