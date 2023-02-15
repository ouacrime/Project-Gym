using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym
{
    public partial class UserControlUtilisateur : UserControl
    {
        public UserControlUtilisateur()
        {
            InitializeComponent();
        }
        DBSalle DBSalle = new DBSalle();
        public string nomsalle;
        public int idsalle;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");

        private static UserControlUtilisateur controlehome;
        public static UserControlUtilisateur Instance
        {
            get
            {
                if (controlehome == null)
                {
                    controlehome = new UserControlUtilisateur();
                }
                return controlehome;

            }
        }

        string testobligatoir()
        {
            if (txtemail.Text == "" )
            {
                return "Entre l'email de salle";
            }
            if (txtnom.Text == "" )
            {
                return "Entre le nom utilisateur";
            }
            if (txtmotpasse.Text == "" )
            {
                return "Entre Mot de passe";
            }
            if (txtemail.Text != "" || txtemail.Text != "Email")
            {
                try
                {
                    new MailAddress(txtemail.Text);//pour verifier email si valid ou non
                }
                catch
                {
                    return "Email invalide";
                }
            }


            return null;
        }

        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();

                string sql = "select id_salle,email,nom,motpasse,Type from salle ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3],rd[4]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testobligatoir() != null)
            {
                MessageBox.Show(testobligatoir(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DBSalle.ajouter_salle(txtemail.Text, txtnom.Text, nomsalle, txtmotpasse.Text, cmbtype.Text,idsalle) == true)
                {
                    MessageBox.Show("Compte ajouter avec sucess", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Actualisedatagrid();
                    txtemail.Text = txtmotpasse.Text = txtnom.Text = "";
                }
                else
                {
                    MessageBox.Show("nom de salle et nom utilisateur deja existant", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
        }

        private void UserControlUtilisateur_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
        }

       

        private void DGVM_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                txtemail.Text = row.Cells[1].Value.ToString();
                txtnom.Text = row.Cells[2].Value.ToString();
                txtmotpasse.Text = row.Cells[3].Value.ToString();
            }
        }

        private void DGVM_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVM.Columns[e.ColumnIndex].Name == "Modifier")
            {
                DialogResult dr = MessageBox.Show("voulez-vous vraiment Modifier l'utilisateur", "Mod", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DBSalle.modifierutilisateur(Convert.ToInt32(DGVM.Rows[e.RowIndex].Cells[0].Value.ToString()), txtemail.Text, txtnom.Text, txtmotpasse.Text, cmbtype.Text);
                    MessageBox.Show("utilisateur Modifier avec sucess", "Sup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Actualisedatagrid();
                    txtemail.Text = txtmotpasse.Text = txtnom.Text = "";
                }
                else
                {
                    MessageBox.Show("Modification est annule", "Mod", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            if (DGVM.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                DialogResult dr = MessageBox.Show("voulez-vous vraiment Supprimer l'utilisateur", "SUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DBSalle.supprimer(Convert.ToInt32(DGVM.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    MessageBox.Show("utilisateur Supprimer avec sucess", "Sup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Actualisedatagrid();
                    txtmotpasse.Text = txtnom.Text = txtemail.Text = "";
                }
                else
                {
                    MessageBox.Show("Supprimer est annule", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

    }
}
