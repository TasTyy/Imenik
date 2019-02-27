using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imenik_helper;

namespace Imenik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Imenik_helper.Imenik> seznamImenikov = new List<Imenik_helper.Imenik>();

            OsebeDatabase db = new OsebeDatabase();
            seznamImenikov = db.Imeniki();

            foreach (Imenik_helper.Imenik imenik in seznamImenikov)
            {
                comboBox1.Items.Add(imenik.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Osebe> seznamOseb = new List<Osebe>();

            OsebeDatabase db = new OsebeDatabase();
            seznamOseb = db.OdpriImenik();
            dataGridView1.DataSource = seznamOseb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vpisi ime imenika!");
            }
            else
            {
                string imeImenika = textBox1.Text;

                Imenik_helper.Imenik imenik = new Imenik_helper.Imenik(imeImenika);

                OsebeDatabase db = new OsebeDatabase();
                db.DodajImenik(imenik);

                textBox1.Text = "";
                MessageBox.Show("Imenik dodan");
                comboBox1.Items.Clear();

                List<Imenik_helper.Imenik> seznamImenikov = new List<Imenik_helper.Imenik>();
                seznamImenikov = db.Imeniki();

                foreach (Imenik_helper.Imenik imenik1 in seznamImenikov)
                {
                    comboBox1.Items.Add(imenik1.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 dodajOsebo = new Form2();
            dodajOsebo.Show();
        }
    }
}
