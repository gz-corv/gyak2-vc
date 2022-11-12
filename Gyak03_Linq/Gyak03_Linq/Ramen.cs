using System;
using System.Collections.Generic;
using System.Text;

namespace Gyak03_Linq
{
    class Ramen
    {
        public int ID { get; set; }
       
        public String Name { get; set; }

        public int BrandFk { get; set; }

        public Brand Brand { get; set; }

        public int CountryFK { get; set; }

        public Country Country { get; set; }

        public double Rating { get; set; }
    }
}
