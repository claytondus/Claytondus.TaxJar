using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claytondus.TaxJar.Models
{
    public class TaxJarValidationContainer
    {
        public TaxJarValidation validation { get; set; }
    }

    public class TaxJarValidation
    {
        public bool? valid { get; set; }
        public bool? exists { get; set; }
        public bool? vies_available { get; set; }
        public dynamic vies_response { get; set; }
    }
}
