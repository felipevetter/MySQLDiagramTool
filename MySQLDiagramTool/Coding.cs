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
    public partial class Coding : Form
    {
        public Coding()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckKeyword("create", Color.CornflowerBlue, 0);
            CheckKeyword("table", Color.CornflowerBlue, 0);
            CheckKeyword("if", Color.CornflowerBlue, 0);
            CheckKeyword("exists", Color.CornflowerBlue, 0);
            CheckKeyword("not", Color.CadetBlue, 0);
            CheckKeyword("null", Color.CadetBlue, 0);
            CheckKeyword("constraint", Color.CadetBlue, 0);
            CheckKeyword("primary", Color.CadetBlue, 0);
            CheckKeyword("foreign", Color.CadetBlue, 0);
            CheckKeyword("key", Color.CadetBlue, 0);
            CheckKeyword("references", Color.CadetBlue, 0);
            CheckKeyword("INT", Color.CornflowerBlue, 0);
            CheckKeyword("CHAR", Color.CornflowerBlue, 0);
            CheckKeyword("VARCHAR", Color.CornflowerBlue, 0);
            CheckKeyword("DATE", Color.CornflowerBlue, 0);
            CheckKeyword("TIME", Color.CornflowerBlue, 0);
            CheckKeyword("DATETIME", Color.CornflowerBlue, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Gainsboro;
                }
            }
        }
        private void writeDiagramInCode()
        {
            Form f = Application.OpenForms["Wrapper"];
            var tables = ((Wrapper)f).Controls.OfType<table>();
            var finalText = "";
            foreach (table table in tables)
            {
                var content = "";
                List<string> constraints = new List<string>();

                var attributes = table.Controls.OfType<AttributeType>();
                for(int i = 0; i < attributes.Count(); i++)
                {
                    var atributo = attributes.Reverse().ElementAt(i);
                    if (atributo.Reference == null)
                    {
                        if (i == 0)
                        {
                            content += $"{atributo.Atributo} {atributo.Categoria} not null,";
                            constraints.Add($"\nconstraint pk_{atributo.Atributo}\n    primary key({atributo.Atributo})");
                        }
                        else
                        {
                            content += $"\n{atributo.Atributo} {atributo.Categoria},";
                        }
                    }
                    else
                    {
                        constraints.Add($"\nconstraint fk_{atributo.Reference["from"]}_{atributo.Reference["where"]}_{atributo.Reference["attribute_from"]}\n    foreign key({atributo.Reference["attribute_from"]})\n        references {atributo.Reference["where"]}({atributo.Reference["attribute_where"]})");
                    }
                }
                for (int c = 0; c < constraints.Count; c++)
                {
                    content += constraints[c];
                    if(c + 1 < constraints.Count)
                    {
                        content += ",";
                    }
                }
                finalText += $"create table if not exists {table.Nome}(\n{content});\n\n";
                richTextBox1.Text = finalText;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            writeDiagramInCode();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }
    }
}
