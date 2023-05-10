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
    public partial class table : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private string name;
        public string Nome
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                guna2TextBox1.Text = value;
            }
        }

        public table()
        {
            InitializeComponent();
            
        }

        private Point initialClickedPoint;

        private void table_MouseDown(object sender, MouseEventArgs e)
        {
            initialClickedPoint = e.Location;
        }

        private void table_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(e.X + this.Left - initialClickedPoint.X,
                        e.Y + this.Top - initialClickedPoint.Y);
            }
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            name = guna2TextBox1.Text;
        }

        private void createPanel()
        {
            TableEditor tbEditor = new TableEditor();
            tbEditor.Nome = name;
            Form v = Application.OpenForms["Form1"];
            var f = ((Form1)v);

            //remove already existent panels
            var controles = f.guna2Panel3.Controls.OfType<TableEditor>();
            foreach (TableEditor tableEditor in controles)
            {
                f.guna2Panel3.Controls.Remove(tableEditor);
            }
            //add panel
            f.guna2Panel3.Controls.Add(tbEditor);
            tbEditor.BringToFront();
            tbEditor.Dock = DockStyle.Bottom;
        }

        private void table_DoubleClick(object sender, EventArgs e)
        {
            createPanel();
        }

        private void table_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void table_ControlAdded(object sender, ControlEventArgs e)
        {
            this.Size = new Size(this.Width, this.Height + 39);
        }

        private void guna2Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(this.Height + guna2Panel2.Top + e.Y > 170)
                this.Height = guna2Panel2.Top + e.Y;
            }
        }

        private void guna2Panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Width + guna2Panel3.Left + e.X > 350)
                    this.Width = guna2Panel3.Left + e.X;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form v = Application.OpenForms["Wrapper"];
            var f = ((Wrapper)v);
            var controles = f.Controls.OfType<table>();

            foreach (table tabela in controles)
            {
                if (tabela.Nome == name)
                {
                    f.Controls.Remove(tabela);
                }
            }
        }
    }
}
