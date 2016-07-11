using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Claytondus.TaxJar.Models;

namespace Claytondus.TaxJar
{

	public class TaxJarClient : RestClient
	{

		public TaxJarClient(string authToken) : base(authToken)
		{
		}

	    public async Task<TaxJarCategoryList> ListCategoriesAsync()
	    {
	        const string resource = "/categories";
	        return await GetAsync<TaxJarCategoryList>(resource);
	    }

	    public async Task<TaxJarUSCARateContainer> GetUSCARateAsync(TaxJarRateRequest request)
	    {
	        var resource = "/rates/" + request.zip;
	        return await GetAsync<TaxJarUSCARateContainer>(resource);
	    }

	    public async Task<TaxJarIntlRateContainer> GetIntlRateAsync(TaxJarRateRequest request)
	    {
	        var resource = "/rates/" + request.zip;
	        return await GetAsync<TaxJarIntlRateContainer>(resource);
	    }

	    public async Task<TaxJarTaxContainer> CalculateSalesTax(TaxJarTaxRequest request)
	    {
	        var resource = "/taxes";
	        return await PostAsync<TaxJarTaxContainer>(resource, request);
	    }

	    public async Task<TaxJarOrderList> ListOrdersAsync(TaxJarDateRange range = null)
	    {
	        const string resource = "/transactions/orders";
	        return await GetAsync<TaxJarOrderList>(resource, range);
	    }

        public async Task<TaxJarOrder> GetOrderAsync(string transactionId)
        {
            var resource = "/transactions/orders/"+transactionId;
            return await GetAsync<TaxJarOrder>(resource);
        }

        public async Task<TaxJarOrder> CreateOrderAsync(TaxJarTransaction txn)
        {
            const string resource = "/transactions/orders";
            return await PostAsync<TaxJarOrder>(resource, txn);
        }

        public async Task<TaxJarOrder> UpdateOrderAsync(string transactionId, TaxJarTransaction txn)
        {
            var resource = "/transactions/orders/" + transactionId;
            return await PutAsync<TaxJarOrder>(resource, txn);
        }

        public async Task<TaxJarOrder> DeleteOrderAsync(string transactionId)
        {
            var resource = "/transactions/orders/" + transactionId;
            return await DeleteAsync<TaxJarOrder>(resource);
        }

        public async Task<TaxJarOrderList> ListRefundsAsync(TaxJarDateRange range = null)
        {
            const string resource = "/transactions/refunds";
            return await GetAsync<TaxJarOrderList>(resource, range);
        }

        public async Task<TaxJarRefund> GetRefundAsync(string transactionId)
        {
            var resource = "/transactions/refunds/" + transactionId;
            return await GetAsync<TaxJarRefund>(resource);
        }

        public async Task<TaxJarOrder> CreateRefundAsync(TaxJarTransaction txn)
        {
            const string resource = "/transactions/refunds";
            return await PostAsync<TaxJarOrder>(resource, txn);
        }

        public async Task<TaxJarOrder> UpdateRefundAsync(string transactionId, TaxJarTransaction txn)
        {
            var resource = "/transactions/refunds/" + transactionId;
            return await PutAsync<TaxJarOrder>(resource, txn);
        }

        public async Task<TaxJarOrder> DeleteRefundAsync(string transactionId)
        {
            var resource = "/transactions/refunds/" + transactionId;
            return await DeleteAsync<TaxJarOrder>(resource);
        }

	    public async Task<TaxJarRegionContainer> ListNexusLocationsAsync()
	    {
	        const string resource = "/nexus/regions";
	        return await GetAsync<TaxJarRegionContainer>(resource);
	    }

	    public async Task<TaxJarValidationContainer> ValidateVatNumberAsync(string vatNumber)
	    {
	        const string resource = "/validation";
	        return await GetAsync<TaxJarValidationContainer>(resource, new {vat = vatNumber});
	    }

	    public async Task<TaxJarSummaryRatesContainer> GetSummaryRatesAsync()
	    {
	        const string resource = "/summary_rates";
	        return await GetAsync<TaxJarSummaryRatesContainer>(resource);
	    }
	}
}