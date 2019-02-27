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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime = textBox1.Text;
            string priimek = textBox2.Text;
            string naslov = textBox3.Text;
            string telStevilka = textBox4.Text;
            string email = textBox5.Text;
            string imenikID = Convert.ToString(comboBox1.SelectedItem);

            Osebe oseba = new Osebe(ime, priimek, naslov, telStevilka, email, imenikID);
            OsebeDatabase db = new OsebeDatabase();
            db.DodajOsebo(oseba);

            MessageBox.Show("Oseba dodana");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Imenik_helper.Imenik> seznamImenikov = new List<Imenik_helper.Imenik>();
            OsebeDatabase db = new OsebeDatabase();
            seznamImenikov = db.Imeniki();
            foreach (Imenik_helper.Imenik imenik in seznamImenikov)
            {
                comboBox1.Items.Add(imenik.ToString());
            }
        }
    }
}
