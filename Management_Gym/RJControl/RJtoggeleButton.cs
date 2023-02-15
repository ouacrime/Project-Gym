using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;



namespace Management_Gym.RJControl
{
    class RJtoggeleButton : CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;


        public Color OnBackColor { get => onBackColor; set { onBackColor = value;this.Invalidate(); } }
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; this.Invalidate(); } }
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; this.Invalidate(); } }
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; this.Invalidate(); } }


        public override string Text { get => base.Text; set { } }

        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set { solidStyle = value; this.Invalidate(); }

        }


        //Constructor
        public RJtoggeleButton()
        {
            this.MinimumSize = new Size(22, 10);
        }
        //Methode
        private GraphicsPath GetFigurePath()
        {
            int arcsize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcsize, arcsize);
            Rectangle rightArc = new Rectangle(this.Width - arcsize - 2, 0, arcsize, arcsize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc,90,180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;

        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)//on
            {
                //draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                //draw the toggle
                else pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                    pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                          new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                
            }
            else//off
            {
                //draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                //draw the toggle
                else pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                    pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),new Rectangle(2, 2, toggleSize, toggleSize));
                
            }

        }



    }
}
