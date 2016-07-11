using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claytondus.TaxJar.Models
{
    public class TaxJarDateRange
    {
        public DateTime? transaction_date { get; set; }
        public DateTime? from_transaction_date { get; set; }
        public DateTime? to_transaction_date { get; set; }
    }
}
