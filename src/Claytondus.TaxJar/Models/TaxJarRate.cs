using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claytondus.TaxJar.Models
{
    public class TaxJarRateRequest
    {
        public string country { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }

    public class TaxJarUSCARateContainer
    {
        public TaxJarUSCARate rate { get; set; }
    }

    public class TaxJarUSCARate
    {
        public string zip { get; set; }
        public string state { get; set; }
        public decimal? state_rate { get; set; }
        public string county { get; set; }
        public decimal? county_rate { get; set; }
        public string city { get; set; }
        public decimal? city_rate { get; set; }
        public decimal? combined_district_rate { get; set; }
        public decimal? combined_rate { get; set; }
    }

    public class TaxJarIntlRateContainer
    {
        public TaxJarIntlRate rate { get; set; }
    }

    public class TaxJarIntlRate
    {
        public string country { get; set; }
        public string name { get; set; }
        public decimal? standard_rate { get; set; }
        public decimal? reduced_rate { get; set; }
        public decimal? super_reduced_rate { get; set; }
        public decimal? parking_rate { get; set; }
        public decimal? distance_sale_threshold { get; set; }
        public bool? freight_taxable { get; set; }
    }


}
