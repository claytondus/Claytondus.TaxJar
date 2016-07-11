using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claytondus.TaxJar.Models
{
    public class TaxJarTaxContainer
    {
        public TaxJarTax tax { get; set; }
    }

    public class TaxJarTax
    {
        public decimal? order_total_amount { get; set; }
        public decimal? shipping { get; set; }
        public decimal? taxable_amount { get; set; }
        public decimal? amount_to_collect { get; set; }
        public decimal? rate { get; set; }
        public bool? has_nexus { get; set; }
        public bool? freight_taxable { get; set; }
        public string tax_source { get; set; }
        public dynamic breakdown { get;set; }
    }

    public class TaxJarTaxRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public decimal amount { get; set; }
        public decimal shipping { get; set; }
        public List<TaxJarNexusAddress> nexus_addresses { get; set; }
        public List<TaxJarLineItem> line_items { get; set; }
    }

    public class TaxJarNexusAddress
    {
        public string id { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }
}
