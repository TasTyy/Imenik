﻿using System;
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

        public string ime1;
        public string priimek1;

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
            string imeImenika = comboBox1.SelectedItem.ToString();
            List<Osebe> seznamOseb = new List<Osebe>();

            OsebeDatabase db = new OsebeDatabase();
            seznamOseb = db.OdpriImenik(imeImenika);
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OsebeDatabase db = new OsebeDatabase();

            var row = dataGridView1.CurrentCell.RowIndex;
            var collumn = dataGridView1.CurrentCell.ColumnIndex;

            string ime = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string priimek = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string naslov = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string telStevilka = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string email = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string imenik_id = dataGridView1.Rows[row].Cells[5].Value.ToString();

            Osebe oseba = new Osebe(ime, priimek, naslov, telStevilka, email, imenik_id);
            db.PosodobiOsebo(oseba, ime1, priimek1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.CurrentCell.RowIndex;
            var collumn = dataGridView1.CurrentCell.ColumnIndex;

            ime1 = dataGridView1.Rows[row].Cells[0].Value.ToString();
            priimek1 = dataGridView1.Rows[row].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string imeImenika = comboBox1.SelectedItem.ToString();

            OsebeDatabase db = new OsebeDatabase();

            var row = dataGridView1.CurrentCell.RowIndex;
            var collumn = dataGridView1.CurrentCell.ColumnIndex;


            string ime = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string priimek = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string naslov = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string telStevilka = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string email = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string imenik_id = dataGridView1.Rows[row].Cells[5].Value.ToString();

            Osebe oseba = new Osebe(ime, priimek, naslov, telStevilka, email, imenik_id);
            db.IzbrisiOsebo(oseba);

            List<Osebe> seznamOseb = new List<Osebe>();

            seznamOseb = db.OdpriImenik(imeImenika);
            dataGridView1.DataSource = seznamOseb;
        }
    }
}
