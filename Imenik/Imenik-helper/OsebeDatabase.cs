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

        public List<Osebe> OdpriImenik(string imeImenika)
        {
            List<Osebe> seznamOseb = new List<Osebe>();
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "SELECT * FROM Osebe WHERE imenik_id = '" + imeImenika + "'";
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Osebe oseba = new Osebe(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    seznamOseb.Add(oseba);
                }
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
                com.CommandText = "DELETE FROM Osebe WHERE ime = '" + deleteOseba.ime + "' AND priimek = '" + deleteOseba.priimek + "' AND naslov = '" + deleteOseba.naslov + "' AND telStevilka = '" + deleteOseba.telStevilka + "' AND email = '" + deleteOseba.email + "' AND imenik_id = '" + deleteOseba.imenikID + "' ; ";
                com.ExecuteNonQuery();
            }
        }

        public void PosodobiOsebo(Osebe updateOseba, string ime, string priimek)
        {
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                com.CommandText = "UPDATE Osebe SET ime = '" + updateOseba.ime + "', priimek = '" + updateOseba.priimek + "', naslov = '" + updateOseba.naslov + "', telStevilka = '" + updateOseba.telStevilka + "', email = '" + updateOseba.email + "' WHERE ((ime = '" + ime + "') AND (priimek = '" + priimek + "')); ";
                com.ExecuteNonQuery();
            }
        }
    }
}
