using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class UlicaBO
    {
        
        public  int id_ulice;

        private string nazivulice;
        [Key]
        public  int Id_ulice { get => id_ulice; set => id_ulice = value; }
        public string Nazivulice { get => nazivulice; set => nazivulice = value; }

    }
}
