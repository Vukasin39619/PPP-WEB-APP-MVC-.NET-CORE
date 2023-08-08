using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class ClanBO
    {

        [Key]
        private int id_Clana;
        private string ime;
        private string prezime;
        private string username;
        private string datumRodjenja;
        private string pol;
        private string role;
        private string password;

        [Key]
        public int Id_Clana { get => id_Clana; set => id_Clana = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Pol { get => pol; set => pol = value; }
        public string Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
