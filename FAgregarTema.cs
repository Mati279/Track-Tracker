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
        FAgregarArtista fAgregarArtista = new FAgregarArtista();

        public string nombreUsuario { get; set; }
        //Constructor de FAgregarTema.
        public FAgregarTema()
        {
            InitializeComponent();
            Actualizar();
        }

        private void FAgregarTema_Load(object sender, EventArgs e)
        {
            //Para que cambie el título de la ventana.
            nombreUsuario = CPerfil.perfilUsuario.Nombre;
            this.Text = $"Publicar tema como {nombreUsuario}";
        }

        private void butAgrArtista_Click(object sender, EventArgs e)
        {
            fAgregarArtista.ShowDialog();
        }

        private void Actualizar()
        {
            cbSelArtista.DataSource = null;
            cbSelArtista.DataSource = CArtista.Artistas;
            cbSelArtista.DisplayMember = "Nombre";

        }

        private void FAgregarTema_Activated(object sender, EventArgs e)
        {
            Actualizar();
         
        }
    }
}
