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
    public partial class TableEditor : UserControl
    {
        public TableEditor()
        {
            InitializeComponent();
        }

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
                label4.Text = "Editing table: " + value;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form v = Application.OpenForms["Form1"];
            var f = ((Form1)v);
            var controles = f.guna2Panel3.Controls.OfType<TableEditor>();
            foreach (TableEditor tableEditor in controles)
            {
                f.guna2Panel3.Controls.Remove(tableEditor);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text == "")
            {
                MessageBox.Show("Select a valid name!", "SQL Diagram Tool");
                return;
            }

            //find control and add attribute
            Form v = Application.OpenForms["Wrapper"];
            var f = ((Wrapper)v);
            var controles = f.Controls.OfType<table>();

            foreach (table tabela in controles)
            {
                if(tabela.Nome == name)
                {
                    AttributeType att = new AttributeType();
                    att.Size = new Size(187, 29);
                    att.Dock = DockStyle.Top;
                    att.BackColor = Color.FromArgb(35, 37, 40);
                    att.Atributo = guna2TextBox1.Text;
                    att.Categoria = guna2ComboBox1.Text;
                    tabela.Controls.Add(att);
                    tabela.Controls.SetChildIndex(att, 0);
                }
            }
            // ------------------------------------------------- //
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(guna2TextBox2.Text == "")
            {
                MessageBox.Show("Select a valid value!", "SQL Diagram Tool");
                return;
            }
            if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("Select a valid value!", "SQL Diagram Tool");
                return;
            }
            if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Select a valid value!", "SQL Diagram Tool");
                return;
            }

            //find control and add attribute
            Form v = Application.OpenForms["Wrapper"];
            var f = ((Wrapper)v);
            var controles = f.Controls.OfType<table>();

            foreach (table tabela in controles)
            {
                if (tabela.Nome == name)
                {
                    AttributeType att = new AttributeType();
                    att.Size = new Size(187, 29);
                    att.Dock = DockStyle.Top;
                    att.BackColor = Color.FromArgb(35, 37, 40);
                    att.Atributo = $"fk_{guna2TextBox3.Text}_{guna2TextBox4.Text}";
                    att.Categoria = "FK";
                    var dc = new Dictionary<string, string>();
                    dc["from"] = name;
                    dc["attribute_from"] = guna2TextBox2.Text;
                    dc["attribute_where"] = guna2TextBox3.Text;
                    dc["where"] = guna2TextBox4.Text;
                    att.Reference = dc;

                    tabela.Controls.Add(att);
                    tabela.Controls.SetChildIndex(att, 0);
                }
            }
            // ------------------------------------------------- //
        }
    }
}
