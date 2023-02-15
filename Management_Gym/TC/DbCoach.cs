using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Gym.TC
{
    class DbCoach
    {
        private GestionGymEntities db = new GestionGymEntities();
        private coach c;
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        private SqlCommand cmd;

        public bool ajouter_couche(string nom,string prenom,string numero ,string sexe,string nomsport)
        {
            string sql = "update sport set idcoach =  (select id_coach from coach where nom_sport = '"+nomsport+"') where nom_sport = (select nom_sport from coach where nom_sport = '"+nomsport+"')";

            c = new coach();
            c.nom = nom;
            c.prenom = prenom;
            c.numero = numero;
            c.sexe = sexe;
            c.nom_sport = nomsport;
            if (db.coaches.SingleOrDefault(s => s.numero == numero && s.nom_sport == nomsport) == null)//si'nexist pas
            {

                db.coaches.Add(c);
                db.SaveChanges();
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteScalar();
                con.Close();
                return true;
            }
            else//si existe dans la base de donnee
            {
                return false;
            }

        }

        public void modifier_coach(int id, string nom, string prenom,string numero,string sexe)
        {
            c = new coach();
            c = db.coaches.SingleOrDefault(s => s.id_coach == id);
            if (c != null)
            {
                c.nom = nom;
                c.prenom = prenom;
                c.numero = numero;
                c.sexe = sexe;
                db.SaveChanges();
            }
        }

        public void supp_coach(string nomsport)
        {
            string sql = "DELETE FROM coach WHERE nom_sport = '" + nomsport + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int verifercoach(string namesport)
        {
            int typex;

            cmd = new SqlCommand()
            {
                CommandText = "supp_coach",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter p1 = new SqlParameter()
            {
                ParameterName = "@nomsport",
                SqlDbType = SqlDbType.VarChar,
                Value = namesport,
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

    }
}
