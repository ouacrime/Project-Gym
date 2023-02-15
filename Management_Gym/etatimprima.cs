using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym
{
    public partial class etatimprima : Form
    {
        public string Date,name,prenom,sport,sexe;
        public etatimprima()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyyy");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryqr, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            PrintDialog printdialog1 = new PrintDialog();
            printdialog1.Document = printDocument1;
            DialogResult result = printdialog1.ShowDialog();





            if (result == DialogResult.OK)
            {
                getprintarea(panel1);
                printPreviewDialog1.Document = printDocument1;
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog1.ShowDialog();


            }


        }

        //private void Print(Panel p1)
        //{
        //    panel1 = p1;
        //    getprintarea(p1);
            

        //    printPreviewDialog1.Document = printDocument1;
        //    printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        //    printPreviewDialog1.ShowDialog();
        //}

        private Bitmap memoryqr;

        private void getprintarea(Panel p1)
        {
            memoryqr = new Bitmap(p1.Width, p1.Height);
            p1.DrawToBitmap(memoryqr, new Rectangle(0, 0, p1.Width, p1.Height));
        }

        private void etatimprima_Load(object sender, EventArgs e)
        {
            labeldate.Text = Date;
            labelname.Text = name;
            labelprenom.Text = prenom;
            labelsport.Text = sport;
            labelsexe.Text = sexe;
            if (labelname.Text != "?")
            {
                QRCoder.QRCodeGenerator QR = new QRCoder.QRCodeGenerator();
                var data = QR.CreateQrCode(labelname.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(data);
                pictureBox3.Image = code.GetGraphic(50);
            }
        }
    }
}
