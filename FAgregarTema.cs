using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_Tracker
{
    public partial class FAgregarTema : Form
    {
        //=============================================================================================
        //Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- At
        //=============================================================================================
        CPerfil perfilActual { get; set; }
        public string nombrePerfil { get; set; }



        //Constructor de FAgregarTema.
        public FAgregarTema()
        {
            InitializeComponent();
        }


        //=============================================================================================
        //Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  
        //=============================================================================================

        //FAgregarTema_Load -- FAgregarTema_Load -- FAgregarTema_Load -- FAgregarTema_Load -- FAgregarT
        private void FAgregarTema_Load(object sender, EventArgs e)
        {
            nombrePerfil = perfilActual.Nombre;
            this.Text = nombrePerfil;
        }

        //=============================================================================================
        //Métodos -- Métodos -- Métodos -- Métodos -- Métodos -- Métodos -- Métodos -- Métodos -- Métod
        //=============================================================================================
        public void RecibirPerfil(CPerfil _perfil)
        {
            perfilActual = _perfil; 
        }
    }
}
