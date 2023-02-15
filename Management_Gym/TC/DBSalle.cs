using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym
{
    class DBSalle
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        SqlCommand cmd;
        private GestionGymEntities db = new GestionGymEntities();//data base Gym
        private salle c;
        public bool ajouter_salle(string email,string nom,string nom_salle,string motdepasse,string type,int idadmin )
        {
            c = new salle();//nouveau client
            c.email = email;
            c.nom = nom;
            c.nom_salle = nom_salle;
            c.motpasse = motdepasse;
            c.Type = type;
            //verifier si le nom_salle et le nom existe d'eja dans la basse de donne
            if(db.salles.SingleOrDefault(s => s.email == email)==null)//si'nexist pas
            {
                db.salles.Add(c);//ajouter dans la table salle
                db.SaveChanges();//enregistre dans la basse de donne
                return true;
            }
            else//si existe dans la base de donnee
            {
                return false;
            }
        }
        public bool changeapssword(string email, string name,string motdepass)
        {
            //verifier si le email et le nom existe d'eja dans la basse de donne
            if (db.salles.SingleOrDefault(s => s.nom == name && s.email == email) != null)//si'nexist pas
            {
                cmd = new SqlCommand()
                {
                    CommandText = "spchangerMDP",
                    Connection = con,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter p1 = new SqlParameter()
                {
                    ParameterName = "@motpasse",
                    SqlDbType = SqlDbType.VarChar,
                    Value = motdepass,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(p1);
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else//si existe dans la base de donnee
            {
                
                return false;
            }
        }
        public void modifierutilisateur(int idsalle,string email,string nom,string motpasse,string type)
        {
            c = new salle();
            c = db.salles.SingleOrDefault(s => s.id_salle == idsalle );
            if(c != null)
            {
                c.email = email;
                c.nom = nom;
                c.motpasse = motpasse;
                c.Type = type;
                db.SaveChanges();
            }

        }
        public void supprimer(int id)
        {
            c = new salle();
            c = db.salles.SingleOrDefault(s => s.id_salle == id);

            if(c != null)
            {
                db.salles.Remove(c);
                db.SaveChanges();
            }
        }




    }
}
