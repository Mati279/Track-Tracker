using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public sealed class SingletonData
    {

        public static SingletonData Instance { get; private set; }

        static SingletonData() //Constructor "static" significa que solamente se llama para la primer Instancia creada.
        {
            Instance = new SingletonData();
           
        }//Por algun motivo esto corre al inicio del programa, lo cual es bueno

        private SingletonData() //Constructor "privado" para que no se pueda instanciar desde afuera de la clase.
        {
        }

        public Form1 sForm1 { get; set; }

    }
}
