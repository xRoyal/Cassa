using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cassa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 15; i++)
            {
                quantCB.Items.Add(i);
            }

            quantCB.SelectedIndex = 0;
        }

        private void prodottobtn_Click(object sender, EventArgs e)
        {
            if ((Desctxt.Text == "") || (przkg.Text == ""))
            {
                MessageBox.Show("Inserisci un prodotto e il rispettivo prezzo!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double x = 0;

                if (!double.TryParse(przkg.Text, out x))
                    MessageBox.Show("Devi Specificare un numero come prezzo!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (!descacq.Enabled)
                    {
                        descacq.Enabled = true;
                        catakg.Enabled = true;
                        quantCB.Enabled = true;
                        button1.Enabled = true;
                    }
                    descacq.Items.Add(Desctxt.Text.ToUpper());
                    catakg.Items.Add(przkg.Text);
                    Desctxt.Clear();
                    przkg.Clear();
                    Desctxt.Focus();
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void quantCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Desctxt.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (quantCB.Text == "")
            {
                MessageBox.Show("Seleziona una Quantità!", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (descacq.SelectedIndex < 0)
                    MessageBox.Show("Scegli prima un Prodotto!", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    double prezzo = Convert.ToDouble(catakg.Items[catakg.SelectedIndex]);
                    double qta = Convert.ToDouble(quantCB.Text);
                    listBox3.Items.Add(Convert.ToString(qta) + "kg di " + descacq.Items[descacq.SelectedIndex]);
                    listBox4.Items.Add(prezzo * qta);
                    textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) + prezzo * qta);
                    button2.Enabled = true;

                }
            }
        }

        private void descacq_SelectedIndexChanged(object sender, EventArgs e)
        {
            catakg.SelectedIndex = descacq.SelectedIndex;
        }

        private void catakg_SelectedIndexChanged(object sender, EventArgs e)
        {
            descacq.SelectedIndex = catakg.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<Controls.Count; i++)
                if (Controls[i] is Panel)
                    for (int c = 0; c<Controls[i].Controls.Count; c++)
                        if (Controls[i].Controls[c] is ListBox)
                            ((ListBox)Controls[i].Controls[c]).Items.Clear();
                        else
                            if (Controls[i].Controls[c] is TextBox)
                                ((TextBox)Controls[i].Controls[c]).Clear();
            textBox1.Text = "0";
            Desctxt.Focus();
            button2.Enabled = false;
                                              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i] is Panel)
                    for (int c = 0; c < Controls[i].Controls.Count; c++)
                        if (Controls[i].Controls[c] is ListBox)
                            ((ListBox)Controls[i].Controls[c]).Items.Clear();
                        else
                            if (Controls[i].Controls[c] is TextBox)
                                ((TextBox)Controls[i].Controls[c]).Clear();
            textBox1.Text = "0";
            Desctxt.Focus();
        }
    }
}
