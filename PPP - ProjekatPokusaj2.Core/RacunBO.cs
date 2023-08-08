using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class RacunBO
    {
        [Key]
        private int id_Knjige;
        private int id_Clana;
        private string kolicina;
        private string datum;

        [Key]
        public int Id_Knjige { get => id_Knjige; set => id_Knjige = value; }
        public int Id_Clana { get => id_Clana; set => id_Clana = value; }
        public string Kolicina { get => kolicina; set => kolicina = value; }
        public string Datum { get => datum; set => datum = value; }
    }
}
