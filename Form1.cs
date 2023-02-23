namespace Track_Tracker
{
    public partial class Form1 : Form
    {
        
        //Instanciación de Formas secundarias.
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
            AgregarPerfilNuevo("Mati");
            AgregarPerfilNuevo("Pablo");
           

            //Gabi por defecto, acá habría que hacer lo del archivo para que recuerde la setting local.
            CPerfil.perfilUsuario = lCPerfiles[0]; 



            ActualizarCBPerfiles();
        }


        private void butPublicarTema_Click_1(object sender, EventArgs e) //Tuve que agregar _1 al final del nombre del evento, no sé por qué.
        {
           fAgregarTema.ShowDialog();
        }

       
        private void butGabi_Click(object sender, EventArgs e)
        {
            AgregarPerfilNuevo("Julio");
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

                      
        }
        #endregion

        private void ActualizarCBPerfiles()
        {
            cboxPerfiles.DataSource = null;
            cboxPerfiles.DataSource = lCPerfiles;
            cboxPerfiles.DisplayMember = "Nombre";
        }

        public void AgregarPerfilNuevo(string sNombre) 
        {
            CPerfil perfilNuevo = new CPerfil(sNombre);
                     

            lCPerfiles.Add(perfilNuevo);
            ActualizarCBPerfiles();

            //Decisión de diseño, al crear perfil nuevo lo pone como perfil actual
            CPerfil.perfilUsuario = perfilNuevo;
            lbViendo.Text = CPerfil.perfilUsuario.Nombre;
            int cantidad = lCPerfiles.Count;
            cboxPerfiles.SelectedIndex = cantidad-1;



        }

       
    }
}