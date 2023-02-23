using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public class CPerfil : ICalificable
    {
        //Atributo estático del Perfil del usuario del programa.
        public static CPerfil perfilUsuario;

        //Nombre del Perfil.
        public string Nombre { get; set; } 

        //Temas subidos por este Perfil.
        public List<CTema> temasPerfil = new List<CTema>();

        //Constructor.
        public CPerfil(string _nombre)
        {
            Nombre = _nombre;
        }


        //Implementación de métodos de ICalificable. 

        //Obtiene los temas publicados por este Perfil.
        public void ObtenerTemas()
        {
            foreach (CTema tema in CTema.temasTotales)
            {
                if (tema.publicador == this)
                {
                    temasPerfil.Add(tema);
                }
            }
        }



        //Obtiene el promedio de los temas publicados por este Perfil.
        public double ObtenerPromedio()
        {
            int contador = 0;
            double notas = 0;
            double promedio = 0;

            this.ObtenerTemas();

            foreach (CTema tema in temasPerfil)
            {
                    contador++;
                    notas += tema.notaTotal;
            }
            promedio = notas / contador;
            return promedio;
        }



    }
}
