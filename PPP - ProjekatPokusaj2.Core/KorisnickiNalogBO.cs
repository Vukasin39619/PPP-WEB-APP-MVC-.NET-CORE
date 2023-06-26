using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class KorisnickiNalogBO
    {
        [Key]
        private int id;
        private string ime;
        private string prezime;
        private string username;
        private string sifra;
        private string kontakt;
        private bool aktivnost;

        [Key]
        public int Id { get => id; set => id = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Username { get => username; set => username = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public string Kontakt { get => kontakt; set => kontakt = value; }
        public bool Aktivnost { get => aktivnost; set => aktivnost = value; }
    }
}
