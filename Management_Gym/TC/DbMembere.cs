using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym.TC
{
    class DbMembere
    {
        private GestionGymEntities db = new GestionGymEntities();//data base Gym
        private membere m;

        
         
        

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlCommand participercmd;

        //fonction pour ajouter client dans la basse de donnee
        public bool ajouter_membere(string nom, string prenom, DateTime datenais,string telephone,string sexe,int id,string sport,DateTime datedebut,int duree,int tarif,int idsalle)
        {
             //ajouter la table membre
                m = new membere();
                m.nom = nom;
                m.prenom = prenom;
                m.datenaissence = datenais;
                m.telephone = telephone;
                m.sexe = sexe;
                m.idsalle = idsalle;


                //ajouter table participer
                con.Open();
                //tr = con.BeginTransaction();
                string idsport = "select id_sport from sport where nom_sport = '" + sport + "'";
                string idmembere = "select id_membere from membere where telephone = '" + telephone + "' ";
                cmd = new SqlCommand(idmembere, con);
                cmd1 = new SqlCommand(idsport, con);


                //ajouter table type_abonner


                //ajouter dans table abonner
                string dtdb = string.Format("{0:dd-MM-yyyy}", datedebut);
                string dtdf = string.Format("{0:dd-MM-yyyy}", datedebut.AddMonths(duree));






                //verifier si le nom_salle et le nom existe d'eja dans la basse de donne
                if (db.memberes.SingleOrDefault(s => s.telephone == telephone) == null)//si'nexist pas
                {
                    //add member
                    db.memberes.Add(m);
                    db.SaveChanges();

                    //Add participer;
                    int id_sport = (int)cmd1.ExecuteScalar();
                    int id_membere = (int)cmd.ExecuteScalar();
                    string participer = "insert into participer values('" + id_sport + "','" + id_membere + "')";
                    participercmd = new SqlCommand(participer, con);
                    participercmd.ExecuteNonQuery();


                    //add table type abonement

                    string type_abonnement = "insert into type_abonnement values('" + id + "','" + duree + "','" + tarif + "')";
                    cmd2 = new SqlCommand(type_abonnement, con);
                    cmd2.ExecuteNonQuery();

                    //add table abonner
                    string abonner = "insert into  abonner values('" + id + "','" + dtdb + "','" + dtdf + "','" + id_membere + "','" + id + "')";
                    cmd3 = new SqlCommand(abonner, con);
                    cmd3.ExecuteNonQuery();

                    con.Close();
                    return true;

                }
                else//si existe dans la base de donnee
                {
                    con.Close();
                    return false;
                }
            }
        public void modifier_Member(int id, string nom, string prenom,DateTime datex,string telephone,string sexe,string sport,DateTime datedebut,int duree,int prix,int idabonnement, int idsport)
        {

            m = new membere();
            m = db.memberes.SingleOrDefault(s => s.id_membere == id);

            cmd = new SqlCommand()
            {
                CommandText = "modifer_member",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter p1 = new SqlParameter()
            {
                ParameterName = "@idsport",
                SqlDbType = SqlDbType.VarChar,
                Value = idsport,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(p1);
            cmd.Parameters.AddWithValue("@idmember", id);
            cmd.Parameters.AddWithValue("@idabonnement", idabonnement);
            cmd.Parameters.AddWithValue("@datedebut", datedebut);
            cmd.Parameters.AddWithValue("@datefin", datedebut.AddMonths(duree));
            cmd.Parameters.AddWithValue("@prix", prix);



            if (m != null )
            {
                m.nom = nom;
                m.prenom = prenom;
                m.datenaissence = datex;
                m.telephone = telephone;
                m.sexe = sexe;

                db.SaveChanges();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void supp_sport(int id)
        {
            string sql = "DELETE FROM membere WHERE id_membere = " + id + "";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int IdAdmin()
        {
            int id = 0;
            string sql = "select id_salle FROM salle WHERE Type ='admin'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            id = (int)cmd.ExecuteScalar();
            con.Close();
            return id;
        }
        public void Renouvelleabonnement(int idmember, int idsport,int idabonnement,string sport,DateTime datedebut,int mois,int prix)
        {
            cmd = new SqlCommand()
            {
                CommandText = "spRenouvelle",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter p1 = new SqlParameter()
            {
                ParameterName = "@idsport",
                SqlDbType = SqlDbType.VarChar,
                Value = idsport,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(p1);
            cmd.Parameters.AddWithValue("@idmember", idmember);
            cmd.Parameters.AddWithValue("@dure", mois);
            cmd.Parameters.AddWithValue("@idabonnement", idabonnement);
            cmd.Parameters.AddWithValue("@datedebut", datedebut);
            cmd.Parameters.AddWithValue("@prix", prix);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int Getprixchoisport(string nomsport)
        {
            int prix ;
            
            cmd = new SqlCommand()
            {
                CommandText = "spGetprixchoixsport",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@sport",nomsport);
            con.Open();
            prix = (int)cmd.ExecuteScalar();

            con.Close();

            return prix;
        }
        public void onlynumber(KeyPressEventArgs e)
        {
            //textbox numeric
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }
    }



}

