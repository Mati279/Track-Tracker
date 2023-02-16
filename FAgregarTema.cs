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

        public string nombreUsuario { get; set; }
        //Constructor de FAgregarTema.
        public FAgregarTema()
        {
            InitializeComponent();
        }

        private void FAgregarTema_Load(object sender, EventArgs e)
        {
            //Para que cambie el título de la ventana.
            nombreUsuario = CPerfil.perfilUsuario.Nombre;
            this.Text = $"Publicar tema como {nombreUsuario}";
        }
    }
}
