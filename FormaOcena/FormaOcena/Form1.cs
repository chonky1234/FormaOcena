using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormaOcena
{
    public partial class Form1 : Form
    {

        int broj_sloga = 0;
        DataTable tabela;

        public Form1()
        {
            InitializeComponent();
        }


        void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Osoba", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);

        }

        void txt_Load()
        {
            if (tabela.Rows.Count == -1)
            {
                txtID.Text = "";
                txtIme.Text = "";
                txtPrezime.Text = "";
                txtAdresa.Text = "";
                txtJMBG.Text = "";
                txtEmail.Text = "";
                txtLozinka.Text = "";
                txtUloga.Text = "";
            }
            else
            {
                txtID.Text = tabela.Rows[broj_sloga]["id"].ToString();
                txtIme.Text = tabela.Rows[broj_sloga]["ime"].ToString();
                txtPrezime.Text = tabela.Rows[broj_sloga]["prezime"].ToString();
                txtAdresa.Text = tabela.Rows[broj_sloga]["adresa"].ToString();
                txtJMBG.Text = tabela.Rows[broj_sloga]["jmbg"].ToString();
                txtEmail.Text = tabela.Rows[broj_sloga]["email"].ToString();
                txtLozinka.Text = tabela.Rows[broj_sloga]["pass"].ToString();
                txtUloga.Text = tabela.Rows[broj_sloga]["uloga"].ToString();
            }

            if (broj_sloga == 0)
            {
                btnLevo.Enabled = false;
                btnSkrozLevo.Enabled = false;
            }
            else
            {
                btnLevo.Enabled = true;
                btnSkrozLevo.Enabled = true;
            }

            if (broj_sloga == tabela.Rows.Count-1)
            {
                btnDesno.Enabled = false;
                btnSkrozDesno.Enabled = false;
            }
            else
            {
                btnDesno.Enabled = true;
                btnSkrozDesno.Enabled = true;
            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Data();
            txt_Load();
        }

        private void btnSkrozLevo_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            txt_Load(); 
        }

        private void btnLevo_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            txt_Load();
        }

        private void btnDesno_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            txt_Load();
        }

        private void btnSkrozDesno_Click(object sender, EventArgs e)
        {
            broj_sloga = tabela.Rows.Count - 1;
            txt_Load();
        }
    }
}
