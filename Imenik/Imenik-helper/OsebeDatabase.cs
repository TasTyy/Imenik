using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Imenik_helper
{
    public class OsebeDatabase
    {
        private SQLiteConnection con;

        public OsebeDatabase()
        {
            con = new SQLiteConnection(@"data source=Baza.db");
            con.Open();
        }

        public List<Imenik> Imeniki()
        {
            List<Imenik> seznamImenikov = new List<Imenik>();
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "SELECT * FROM Imeniki;";
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Imenik imenik = new Imenik(reader.GetString(1));
                    seznamImenikov.Add(imenik);
                }
            }

            return seznamImenikov;
        }

        public List<Osebe> OdpriImenik()
        {
            List<Osebe> seznamOseb = new List<Osebe>();
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "SELECT * FROM Osebe";
                SQLiteDataReader reader = com.ExecuteReader();
            }

            return seznamOseb;
        }

        public void DodajImenik(Imenik addImenik)
        {
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "INSERT INTO Imeniki (ime) VALUES ('" + addImenik.imeImenika + "')";
                com.ExecuteNonQuery();
            }
        }

        public void DodajOsebo(Osebe addOseba)
        {
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "INSERT INTO Osebe (ime, priimek, naslov, telStevilka, email, imenik_id) VALUES ('" + addOseba.ime + "', '" + addOseba.priimek + "', '" + addOseba.naslov + "'," +
                    " '" + addOseba.telStevilka + "', '" + addOseba.email + "', '" + addOseba.imenikID + "')";
                com.ExecuteNonQuery();
            }
        }

        public void IzbrisiOsebo(Osebe deleteOseba)
        {
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "DELETE";
                com.ExecuteNonQuery();
            }
        }

        public void PosodobiOsebo(Osebe updateOseba)
        {
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "UPDATE";
                com.ExecuteNonQuery();
            }
        }
    }
}
