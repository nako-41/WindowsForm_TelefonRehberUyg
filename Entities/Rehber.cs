using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rehber
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TelefonNumarasi { get; set; }
        public string EmailAdres { get; set; }
        public string Adres { get; set; }
        public string WebAdres { get; set; }
        public string Aciklama { get; set; }

        public override string ToString()
        {
            return Isim + " " + Soyisim;
        }
    }
}
