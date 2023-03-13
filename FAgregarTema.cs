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

            
        }

        private void FAgregarTema_Load(object sender, EventArgs e)
        {
            
            //Para que cambie el título de la ventana.
            nombreUsuario = CPerfil.perfilUsuario.Nombre;
            this.Text = $"Publicar tema como {nombreUsuario}";

            ActualizarArtista();
            ActualizarDisco();
            ActualizarEstilo();
        }

        private void butAgrArtista_Click(object sender, EventArgs e)
        {
            fAgregarArtista.ShowDialog();

            ActualizarArtista();
            ActualizarDisco();
            ActualizarEstilo();
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
          private void ActualizarEstilo()
        {
            cbSelEstilo.DataSource = null;
            cbSelEstilo.DataSource = CEstilo.Estilos;
            cbSelEstilo.DisplayMember = "Nombre";
        }



        private void btOK_Click(object sender, EventArgs e)
        {
            new CTema(CPerfil.perfilUsuario, (CArtista)cbSelArtista.SelectedItem, (CEstilo)cbSelEstilo.SelectedItem, tbNombreTema.Text, (CDisco)cbSelDisco.SelectedItem, ((CArtista)cbSelArtista.SelectedItem).País);



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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbSelEstilo.Text != "")
            {

                bool bRepetido = false;
                foreach (CEstilo estilo in CEstilo.Estilos)
                {
                    if (estilo.Nombre.ToLower() == cbSelEstilo.Text.ToLower()) { bRepetido = true; break; }
                }


                if (!bRepetido)
                {
                    CEstilo oEstilo = new CEstilo(cbSelEstilo.Text);
                    MessageBox.Show($"{cbSelEstilo.Text} agregado a Estilo.");
                    ActualizarEstilo();

                    int cantidad = CEstilo.Estilos.Count;
                    cbSelEstilo.SelectedIndex = cantidad - 1;
                }
                else { MessageBox.Show($"Ese estilo ya existe."); cbSelEstilo.Text = ""; }
            }
            else
            {
                MessageBox.Show("Nombre inválido.");
            }
        }
    }
}
