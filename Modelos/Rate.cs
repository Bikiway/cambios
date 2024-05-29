using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambios.Modelos
{
    public class Rate
    {
        public string Country { get; set; }

        public string Currency { get; set; }

        public string IsoA3Code { get; set; }

        public string IsoA2Code { get; set; }

        public decimal Value { get; set; }


        //public override string ToString()
        //{
        //    return $"{Name}";
        //}
         

        // Outra forma de Polimorfismo
    }
}
