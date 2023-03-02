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
        FAgregarDisco fAgregarDisco = new FAgregarDisco();


        public string nombreUsuario { get; set; }
        //Constructor de FAgregarTema.
        public FAgregarTema()
        {
            InitializeComponent();
            ActualizarArtista();
            ActualizarDisco();
        }

        private void FAgregarTema_Load(object sender, EventArgs e)
        {
            //Para que cambie el título de la ventana.
            nombreUsuario = CPerfil.perfilUsuario.Nombre;
            this.Text = $"Publicar tema como {nombreUsuario}";


            ActualizarArtista();
            ActualizarDisco();
        }

        private void butAgrArtista_Click(object sender, EventArgs e)
        {
            fAgregarArtista.ShowDialog();
            ActualizarArtista();
            ActualizarDisco();
        }

        private void ActualizarArtista()
        {
            cbSelArtista.DataSource = null;
            cbSelArtista.DataSource = CArtista.Artistas;
            cbSelArtista.DisplayMember = "Nombre";
      
        }
        private void ActualizarDisco()
        {
            cbSelDisco.DataSource = null;
            cbSelDisco.DataSource = ((CArtista)cbSelArtista.SelectedItem)?.Discos;
            cbSelDisco.DisplayMember = "Nombre";
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            new CTema(CPerfil.perfilUsuario, (CArtista)cbSelArtista.SelectedItem, cbSelTipo.Text, tbNombreTema.Text, (CDisco)cbSelDisco.SelectedItem, ((CArtista)cbSelArtista.SelectedItem).País);



            this.Close();
        }

        private void cbSelArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cambia la Data Source del ComboBox de discos dependiendo de la banda seleccionada.
            cbSelDisco.DataSource = null;
            cbSelDisco.DataSource = ((CArtista)cbSelArtista.SelectedItem)?.Discos;
            cbSelDisco.DisplayMember = "Nombre";

        }

        private void butAgregarDisco_Click(object sender, EventArgs e)
        {
            //Selecciona el Artista del Disco nuevo dependiendo del Artista seleccionado en el cbSelArtista.

            if (cbSelArtista.SelectedItem is CArtista)
            {
                fAgregarDisco.ObtenerArtista((CArtista)cbSelArtista.SelectedItem);
                fAgregarDisco.ShowDialog();
                ActualizarDisco();
            }
            else
            {
                MessageBox.Show("Selecciona un artista para agregar el disco.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
