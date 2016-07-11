using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claytondus.TaxJar.Models
{
    public class TaxJarRegionContainer
    {
        public List<TaxJarRegion> regions { get; set; }
    }

    public class TaxJarRegion
    {
        public string country_code { get; set; }
        public string country { get; set; }
        public string region_code { get; set; }
        public string region { get; set; }
    }
}
