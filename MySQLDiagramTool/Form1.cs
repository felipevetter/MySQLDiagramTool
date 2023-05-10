using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLDiagramTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Coding cd = new Coding();
        Wrapper wp = new Wrapper();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            wp.TopLevel = false;
            wp.AutoScroll = true;
            cd.TopLevel = false;
            cd.AutoScroll = true;
            guna2Panel3.Controls.Add(wp);
            guna2Panel3.Controls.Add(cd);
            wp.Show();
            cd.Hide();
        }

        private void guna2Panel3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void guna2Panel3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            table tb = new table();
            tb.BackColor = Color.White;
            tb.Nome = "tb" + wp.Controls.OfType<table>().Count();
            tb.Location = new Point(tb.Location.X + 12, tb.Location.Y + 20);
            tb.BackColor = Color.FromArgb(35, 37, 40); 
            wp.Controls.Add(tb);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            cd.Show();
            wp.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            wp.Show();
            cd.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            cd.Hide();
            wp.Hide();
        }
    }
}
