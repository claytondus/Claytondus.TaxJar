using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Claytondus.TaxJar;
using Claytondus.TaxJar.Models;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Claytondus.TaxJar.Test
{
    public class ClientTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ClientTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

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
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(orders));
            Assert.NotNull(orders);
        }

        [Fact]
        public async Task SummaryRatesCanBeGot()
        {
            var client = new TaxJarClient(token);
            var rates = await client.GetSummaryRatesAsync();
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(rates));
            Assert.NotNull(rates);
        }

        [Fact]
        public async Task VatNumberCanBeValidated()
        {
            var client = new TaxJarClient(token);
            var rates = await client.ValidateVatNumberAsync("FR40303265045");
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(rates));
            Assert.NotNull(rates);
        }

        [Fact]
        public async Task GetLocalRate()
        {
            var client = new TaxJarClient(token);
            var rate = await client.GetUSCARateAsync(new TaxJarRateRequest
            {
                city = "New York",
                country = "US",
                state = "NY",
                street = "350 5th Avenue",
                zip = "10118"
            });
            Assert.NotNull(rate);
            Assert.Equal(0.08875m, rate.rate.combined_rate);
            Assert.True(rate.rate.freight_taxable);
        }
    }
}
