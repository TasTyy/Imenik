using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik_helper
{
    public class Osebe
    {
        public string ime { get; set; }
        public string priimek { get; set; }
        public string naslov { get; set; }
        public string telStevilka { get; set; }
        public string email { get; set; }
        public string imenikID { get; set; }

        public Osebe(string Ime, string Priimek, string Naslov, string TelStevilka, string Email, string ImenikID)
        {
            ime = Ime;
            priimek = Priimek;
            naslov = Naslov;
            telStevilka = TelStevilka;
            email = Email;
            imenikID = ImenikID;
        }

        public override string ToString()
        {
            string stringToReturn;
            stringToReturn = ime + " " + priimek + " " + naslov + " " + telStevilka + " " + email;
            return stringToReturn;
        }
    }

    public class Imenik
    {
        public string imeImenika { get; set; }
        public List<Osebe> seznamOseb = new List<Osebe>();

        public Imenik(string ImeImenika)
        {
            imeImenika = ImeImenika;
        }

        public override string ToString()
        {
            string stringToReturn;
            stringToReturn = imeImenika;
            return stringToReturn;
        }
    }
}
