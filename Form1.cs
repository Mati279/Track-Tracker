namespace Track_Tracker
{
    public partial class Form1 : Form
    {
        #region//Instanciaciones.
        //=============================================================================================
        //Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancia
        //=============================================================================================

        //Instanciación de Formas secundarias.
        FAgregarTema fAgregarTema = new FAgregarTema();

        //Instanciación de Perfiles.
        CPerfil Gabi = new CPerfil("Gabi");
        CPerfil Pablo = new CPerfil("Pablo");
        CPerfil Mati = new CPerfil("Mati");
        #endregion

        #region//Constructor.
        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region//Handlers.
        //=============================================================================================
        //Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  
        //=============================================================================================

        //(Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //|Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Ga
        private void butGabi_Click(object sender, EventArgs e)
        {
            fAgregarTema.ShowDialog();

        }

        #endregion
    }
}