using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Claytondus.TaxJar;
using Claytondus.TaxJar.Models;
using Newtonsoft.Json;

namespace Claytondus.TaxJar.Test
{
    public class ClientTest
    {
        const string token = "";

        [Fact]
        public async Task ListOrdersForSingleDate()
        {
            var client = new TaxJarClient(token);
            var range = new TaxJarDateRange
            {
                from_transaction_date = new DateTime(2016,6,1),
                to_transaction_date = new DateTime(2016,6,2)
            };
            Console.WriteLine(JsonConvert.SerializeObject(range));
            var orders = await client.ListOrdersAsync(range);
            Console.WriteLine(JsonConvert.SerializeObject(orders));
            Assert.NotNull(orders);
        }

        [Fact]
        public async Task SummaryRatesCanBeGot()
        {
            var client = new TaxJarClient(token);
            var rates = await client.GetSummaryRatesAsync();
            Console.WriteLine(JsonConvert.SerializeObject(rates));
            Assert.NotNull(rates);
        }

        [Fact]
        public async Task VatNumberCanBeValidated()
        {
            var client = new TaxJarClient(token);
            var rates = await client.ValidateVatNumberAsync("FR40303265045");
            Console.WriteLine(JsonConvert.SerializeObject(rates));
            Assert.NotNull(rates);
        }
    }
}
