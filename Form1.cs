namespace Track_Tracker
{
    public partial class Form1 : Form
    {
        
        //=============================================================================================
        //Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancia
        //=============================================================================================

        //Instanciación de Formas secundarias.
        FAgregarTema fAgregarTema = new FAgregarTema();

        //Instanciación de Perfiles.
        CPerfil Gabi = new CPerfil("Gabi");
        CPerfil Pablo = new CPerfil("Pablo");
        CPerfil Mati = new CPerfil("Mati");

        //=============================================================================================
        //Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- At
        //=============================================================================================

        //Perfil del usuario.
        CPerfil perfilUsuario;

        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();
            //Perfil del usuario seteado como Gabi por defecto.
            perfilUsuario = Gabi;
<<<<<<< Updated upstream
            MessageBox.Show("Testasdfdsf");
=======
           
>>>>>>> Stashed changes
        }
       
        //=============================================================================================
        //Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  
        //=============================================================================================

        //(Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) 
        private void Form1_Load(object sender, EventArgs e)
        {
            //Label "Viendo como:" = al nombre del usuario.
            lbViendo.Text = perfilUsuario.Nombre;
        }
        //|Publicar Tema| -- |Publicar Tema| -- |Publicar Tema| -- |Publicar Tema| -- |Publicar Tema| -
        private void butPublicarTema_Click(object sender, EventArgs e)
        {
            //Envía el objeto CPerfil de quien publicará el tema. 
            fAgregarTema.RecibirPerfil(perfilUsuario);
            fAgregarTema.ShowDialog();
        }

        //|Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Ga
        private void butGabi_Click(object sender, EventArgs e)
        {

        }
        //|Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pabl
        private void butPablo_Click(object sender, EventArgs e)
        {

        }
        //|Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Ma
        private void butMati_Click(object sender, EventArgs e)
        {

        }

    }
}