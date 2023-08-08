using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class KnjigaBO
    {
        [Key]
        private int id_Knjige;
        private string nazivKnjige;
        private string autor;
        private string izdavac;
        private string izdavanje;
        private int cena;

        [Key]
        public int Id_Knjige { get => id_Knjige; set => id_Knjige = value; }
        public string NazivKnjige { get => nazivKnjige; set => nazivKnjige = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Izdavac { get => izdavac; set => izdavac = value; }
        public string Izdavanje { get => izdavanje; set => izdavanje = value; }
        public int Cena { get => cena; set => cena = value; }
    }
}
