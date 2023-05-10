using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLDiagramTool
{
    public partial class Wrapper : Form
    {
        public Wrapper()
        {
            InitializeComponent();
        }

        private void Wrapper_MouseMove(object sender, MouseEventArgs e)
        {

        }
        protected Graphics grphx = null;


        protected override void OnPaint(PaintEventArgs e)
        {

            Pen linePen = new Pen(System.Drawing.Color.White);
            grphx = this.CreateGraphics();
            grphx.Clear(this.BackColor);

            for (int i = 1; i < 10; i++)
            {
                //Draw verticle line
                grphx.DrawLine(linePen,
                    (this.ClientSize.Width / 10) * i,
                    0,
                    (this.ClientSize.Width / 10) * i,
                    this.ClientSize.Height);

                //Draw horizontal line
                grphx.DrawLine(linePen,
                    0,
                    (this.ClientSize.Height / 10) * i,
                    this.ClientSize.Width,
                    (this.ClientSize.Height / 10) * i);
            }
            linePen.Dispose();
            grphx.Dispose();
            //Continues the paint of other elements and controls
            base.OnPaint(e);
        }

        private void Wrapper_Load(object sender, EventArgs e)
        {
            table tb = new table();
            tb.BackColor = Color.White;
            tb.Nome = "tb" + this.Controls.OfType<table>().Count();
            tb.Location = new Point(tb.Location.X + 12, tb.Location.Y + 20);

            this.Controls.Add(tb);

        }
    }
}
