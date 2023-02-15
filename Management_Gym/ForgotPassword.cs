using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Management_Gym
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        //conectionstring 
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");


        private void closebox_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu me = new Menu();
            Login m = new Login(me);
            m.Show();

        }

        //this strings will take up the values from which user will send email
        string emailid;
        string password;
        string gymname;
        string OTPCode;
        int i = 0;


        //this strings will be passed to next page
        public static string to; //this contains email id of the user
        public static string Type; // this contains user type
        private void button1_Click(object sender, EventArgs e)
        {
            //if email existe to bdgym
            SqlCommand cmd = new SqlCommand("Select id_salle,email, nom_salle, motpasse from salle", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if(EmailTextbox.Text == sdr.GetValue(1).ToString())
                {
                    emailid = sdr.GetValue(0).ToString();
                    password = sdr.GetValue(3).ToString();
                    gymname = sdr.GetValue(2).ToString();
                    i = 1;
                    break;
                }
            }
            con.Close();
            if (i == 1)
            {
                to = EmailTextbox.Text;
                Random rand = new Random();
                OTPCode = (rand.Next(999999)).ToString();

                try
                {
                    SmtpClient salle = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential()
                        {
                            UserName = emailid,
                            Password = password
                        }
                    };
                    MailAddress fromEmail = new MailAddress(to, gymname);
                    MailAddress ToEmail = new MailAddress(EmailTextbox.Text, "Dear User");
                    MailMessage Message = new MailMessage()
                    {
                        From = fromEmail,
                        Subject = "Password Recovery OTP Code",
                        Body = "Please Enter this OTP Code to recover your password " + "Your OTP Code = " + OTPCode
                    };
                    Message.To.Add(ToEmail);
                    salle.SendCompleted += Client_SendCompleted;
                    salle.SendMailAsync(Message);
                    MessageBox.Show("OTP Sent Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Email d'osent exist", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("OTP Sent Successful");
            }
        }
    }

}
