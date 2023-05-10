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
    public partial class AttributeType : UserControl
    {
        public AttributeType()
        {
            InitializeComponent();
        }

        private string atributo;
        public string Atributo
        {
            get
            {
                return this.atributo;
            }
            set
            {
                this.atributo = value;
                label1.Text = value;
            }
        }

        private string categoria;
        public string Categoria
        {
            get
            {
                return this.categoria;
            }
            set
            {
                this.categoria = value;
                label2.Text = value;
            }
        }

        private Dictionary<string, string> fkreference;
        public Dictionary<string, string> Reference
        {
            get
            {
                return this.fkreference;
            }
            set
            {
                this.fkreference = value;
            }
        }

        private void AttributeType_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            Form v = Application.OpenForms["Wrapper"];
            var f = ((Wrapper)v);
            var controles = f.Controls.OfType<table>();
            foreach (table tables in controles)
            {
                var tabela = tables.Controls.OfType<AttributeType>();
                foreach(AttributeType at in tabela)
                {
                    if(at == this)
                    {
                        tables.Controls.Remove(at);
                    }
                }
            }

        }
    }
}
