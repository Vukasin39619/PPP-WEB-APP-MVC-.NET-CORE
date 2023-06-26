using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class VoznjaBO
    {

        [Key]
        private int id;
        [Key]
        private int id_voznje;
       
        private string vremeVoznjeMin;
        private int id_ulice;
        [Key]
        public int Id { get => id; set => id = value; }
        [Key]
        public int Id_voznje { get => id_voznje; set => id_voznje = value; }
        
        public int Id_ulice { get => id_ulice; set => id_ulice = value; }

        [Column("vremeVoznjeMin")]
        public string VremeVoznjeMin { get => this.vremeVoznjeMin; set => this.vremeVoznjeMin = value; }
    }
}
