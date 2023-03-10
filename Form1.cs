using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Track_Tracker
{
    public partial class Form1 : Form
    {

        //Instanciaci�n de Formas secundarias.
        FAgregarTema fAgregarTema = new FAgregarTema();
        FAgregarPerfil fAgregarPerfil = new FAgregarPerfil();


        List<CPerfil> lCPerfiles = new List<CPerfil>();



        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();

        }

        //|| Interacciones con la Interfaz - Forms ||
        #region 
        private void Form1_Load(object sender, EventArgs e)
        {
            //Se agrega referencia al Singleton_Data de este mismo objeto
            SingletonData.Instance.sForm1 = this;

            //Se agregan a la lista de perfiles los 3 predefinidos
            AgregarPerfilNuevo("Gabi");
            AgregarPerfilNuevo("Pablo");
            AgregarPerfilNuevo("Mati");

            //Crea a Sonata default, para testing. 
            CArtista Sonata = new CArtista("Sonata Arctica", 1996, new CPaís("Finlandia"), new CEstilo("Power Metal"));

            //Gabi por defecto, ac� habr�a que hacer lo del archivo para que recuerde la setting local.
            CPerfil.perfilUsuario = lCPerfiles[0];

            Actualizar();


        }


        private void butPublicarTema_Click_1(object sender, EventArgs e) //Tuve que agregar _1 al final del nombre del evento, no s� por qu�.
        {
            fAgregarTema.ShowDialog();
            Actualizar();

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
        private void butAgregarPerfil_Click(object sender, EventArgs e)
        {
            fAgregarPerfil.ShowDialog();
        }
        private void cboxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CPerfil.perfilUsuario = (CPerfil)cboxPerfiles.SelectedItem;

            //Si perfilusuario = null, entonces se asigna Gabi.
            CPerfil.perfilUsuario ??= lCPerfiles[0];

            //Etiqueta para probar.
            lbViendo.Text = CPerfil.perfilUsuario.Nombre;

            ActualizarFondo();
        }
        #endregion

        private void Actualizar()
        {
            cboxPerfiles.DataSource = null;
            cboxPerfiles.DataSource = lCPerfiles;
            cboxPerfiles.DisplayMember = "Nombre";

            ActualizarFondo();

            MostrarTemaActual();
            //dgArtista.Columns[1].Disp;

        }
        private void ActualizarFondo()
        {
            switch (CPerfil.perfilUsuario.Nombre)
            {
                case "Gabi": butPublicarTema.ForeColor = Color.FromArgb(0, 0, 155); break;
                case "Pablo": butPublicarTema.ForeColor = Color.FromArgb(155, 0, 0); break;
                case "Mati": butPublicarTema.ForeColor = Color.FromArgb(0, 155, 0); break;

            }

        }

        public void AgregarPerfilNuevo(string sNombre)
        {
            CPerfil perfilNuevo = new CPerfil(sNombre);


            lCPerfiles.Add(perfilNuevo);
            Actualizar();

            //Decisi�n de dise�o, al crear perfil nuevo lo pone como perfil actual
            CPerfil.perfilUsuario = perfilNuevo;
            lbViendo.Text = CPerfil.perfilUsuario.Nombre;
            int cantidad = lCPerfiles.Count;
            cboxPerfiles.SelectedIndex = cantidad - 1;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MostrarTemaActual()
        {
            if (lCPerfiles.Count > 0)
            {
                if (lCPerfiles[0].temasPerfil.Count > 0) //Gabi
                {
                    cbGabGab.Visible = true;
                    cbGabPab.Visible = true;
                    cbGabMat.Visible = true;

                    lbGabTemActual.Text = "TemaActual:";
                    lbGabBandaTema.Text = lCPerfiles[0].temasPerfil.Last().artista.Nombre;
                    lbGabNombreTema.Text = lCPerfiles[0].temasPerfil.Last().nombre;
                }
                else
                {
                    cbGabGab.Visible = false;
                    cbGabPab.Visible = false;
                    cbGabMat.Visible = false;

                    lbGabTemActual.Text = "Sin Temas.";
                    lbGabBandaTema.Text = "";
                    lbGabNombreTema.Text = "";
                }
            }

            if (lCPerfiles.Count > 1)
            {
                if (lCPerfiles[1].temasPerfil.Count > 0) //Pablo
                {
                    cbPabGab.Visible = true;
                    cbPabPab.Visible = true;
                    cbPabMat.Visible = true;

                    lbPabTemaActual.Text = "TemaActual:";
                    lbPabBandaTema.Text = lCPerfiles[1].temasPerfil.Last().artista.Nombre;
                    lbPabNombreTema.Text = lCPerfiles[1].temasPerfil.Last().nombre;
                }
                else
                {
                    cbPabGab.Visible = false;
                    cbPabPab.Visible = false;
                    cbPabMat.Visible = false;

                    lbPabTemaActual.Text = "Sin Temas.";
                    lbPabBandaTema.Text = "";
                    lbPabNombreTema.Text = "";
                }
            }

            if (lCPerfiles.Count > 2)
            {
                if (lCPerfiles[2].temasPerfil.Count > 0) //Mati
                {
                    cbMatGab.Visible = true;
                    cbMatPab.Visible = true;
                    cbMatMat.Visible = true;

                    lbMatTemaActual.Text = "TemaActual:";
                    lbMatBandaTema.Text = lCPerfiles[2].temasPerfil.Last().artista.Nombre;
                    lbMatNombreTema.Text = lCPerfiles[2].temasPerfil.Last().nombre;
                }
                else
                {
                    lbMatTemaActual.Text = "Sin Temas.";
                    lbMatBandaTema.Text = "";
                    lbMatNombreTema.Text = "";

                    cbMatGab.Visible = false;
                    cbMatPab.Visible = false;
                    cbMatMat.Visible = false;

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://google.com");
        }

     
    }
}