using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym.TC
{
    class DBsport
    {

        private GestionGymEntities db = new GestionGymEntities();//data base Gym
        private sport s;//tablle sport
        private offrir o;//tablle offrir
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        SqlCommand cmd;

        //fonction pour ajouter client dans la basse de donnee
        public bool ajouter_sport(string nom_sport, string categorie,int capacity,int tarif,int idsalle)
        {
            
            //string sql = "select id_salle from salle";
            s = new sport();//nouveau sport
            o = new offrir();
            s.nom_sport = nom_sport;
            s.ctaegorie = categorie;
            s.tarif = tarif;
            o.capacity = capacity;
            
            //verifier si le nom_salle et le nom existe d'eja dans la basse de donne
            //if (db.sports.SingleOrDefault(s => s.nom_sport == nom_sport) == null)//si'nexist pas
            //{
                //cmd = new SqlCommand(sql, con);

                db.sports.Add(s);//ajouter dans la table sport
                db.SaveChanges();//enregistre dans la basse de donne
                //con.Open();
                o.numsport = s.id_sport;
                o.numsalle = idsalle;//(Int32)cmd.ExecuteScalar();
                db.offrirs.Add(o);
                db.SaveChanges();
                //con.Close();
                return true;
            //}
            //else//si existe dans la base de donnee
            //{
            //    return false;
            //}
        }

        public void modifier_sport(int id,string nom_sport, string categorie, int capacity,int tarif,int idsalle)
        {
            s = new sport();//nouveau sport
            o = new offrir();
            s = db.sports.SingleOrDefault(s => s.id_sport == id) ;

            string sql = "update offrir set capacity = "+capacity+"where numsport = "+id+" and numsalle = '"+idsalle+"' ";
            cmd = new SqlCommand(sql, con);
            if (s !=null)
            {
                con.Open();
                cmd.ExecuteScalar();
                s.nom_sport = nom_sport;
                s.ctaegorie = categorie;
                s.tarif = tarif;
                db.SaveChanges();
                con.Close();
            }
        }
        public void supp_sport(int id_sport)
        {
            string sql = "DELETE FROM sport WHERE id_sport = '"+id_sport+"'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int numbermemberpaticipersport(string name)
        {
            int typex;

            cmd = new SqlCommand()
            {
                CommandText = "N_M_P_S",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter p1 = new SqlParameter()
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = name,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(p1);

            SqlParameter outparametre = new SqlParameter
            {
                ParameterName = "@info",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outparametre);
            con.Open();
            cmd.ExecuteNonQuery();
            typex = int.Parse(outparametre.Value.ToString());
            con.Close();
            return typex;

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
