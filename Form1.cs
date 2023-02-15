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
    public partial class Form1 : Form
    {

        //Instanciación de Formas secundarias.
        FAgregarTema fAgregarTema = new FAgregarTema();

        //Instanciación de Perfiles y lista de perfiles.
        CPerfil Gabi = new CPerfil("Gabi");
        CPerfil Pablo = new CPerfil("Pablo");
        CPerfil Mati = new CPerfil("Matías");
        List<CPerfil> listaPerfiles = new List<CPerfil> { };


        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();

            
            //Se agregan a listaPerfiles los tres perfiles por defecto.
            listaPerfiles.Add(Gabi);
            listaPerfiles.Add(Pablo);
            listaPerfiles.Add(Mati);

            //Default.
            CPerfil.perfilUsuario = Gabi;

            // ---> No es necesario setear default al parecer. Parece que el primer elemento de la listaPerfiles es seleccionado sólo en la ComboBox.
            cboxPerfiles.DisplayMember = "Nombre"; //---> Para que en el ComboBox aparezan los nombres de los perfiles y no de los objetos.
            cboxPerfiles.DataSource = listaPerfiles;

        }
       
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //Label "Viendo como:" = al nombre del usuario.
            lbViendo.Text = CPerfil.perfilUsuario.Nombre;
        }
       
        private void butPublicarTema_Click(object sender, EventArgs e) 
        {
            fAgregarTema.ShowDialog();
            
        }

        private void butGabi_Click(object sender, EventArgs e)
        {

        }
       
        private void butPablo_Click(object sender, EventArgs e)
        {

        }
       
        private void butMati_Click(object sender, EventArgs e)
        {

        }
        private void cboxPerfiles_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CPerfil.perfilUsuario = (CPerfil)cboxPerfiles.SelectedItem;
            lbViendo.Text = CPerfil.perfilUsuario.Nombre;
        }
    }
}