using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claytondus.TaxJar.Models
{
    public class TaxJarTransaction
    {
        public string transaction_id { get; set; }
        public string user_id { get; set; }
        public DateTime? transaction_date { get; set; }
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
        public decimal sales_tax { get; set; }
        public List<TaxJarLineItem> line_items { get; set; }
    }

    public class TaxJarLineItem
    {
        public string id { get; set; }
        public uint? quantity { get; set; }
        public string product_identifier { get; set; }
        public string description { get; set; }
        public string product_tax_code { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? discount { get; set; }
        public decimal? sales_tax { get; set; }
    }

    public class TaxJarOrderList
    {
        public List<string> orders { get; set; }
    }

    public class TaxJarOrder
    {
        public TaxJarTransaction order { get; set; }
    }

    public class TaxJarRefund
    {
        public TaxJarTransaction refund { get; set; }
    }
}
