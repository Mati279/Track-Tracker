using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Tracker
{
    public interface ICalificable
    {
        string Nombre { get; set; }
        void ObtenerTemas();
        double ObtenerPromedio()
        {
            double a = 0;
            return a;
        }




    }
}
