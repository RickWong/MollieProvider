using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Creditcard
{
  public class MollieCreditcard : Mollie
  {

    public MollieCreditcard(string Key) : base(Key) { }

    public async Task<MollieCreditcardStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null,
      string billingCity = null, string billingRegion = null, string billingPostal = null, string billingCountry = null, 
      string shippingAddress = null, string shippingCity = null, string shippingRegion = null, string shippingPostal = null, string shippingCountry = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale, metadata) as MollieCreditcardCreateRequest;
      requestData.Method = "creditcard";
      requestData.BillingCity = billingCity;
      requestData.BillingRegion = billingRegion;
      requestData.BillingPostal = billingPostal;
      requestData.BillingCountry = billingCountry;
      requestData.ShippingAddress = shippingAddress;
      requestData.ShippingCity = shippingCity;
      requestData.ShippingRegion = shippingRegion;
      requestData.ShippingPostal = shippingPostal;
      requestData.ShippingCountry = shippingCountry;

      return await CreateTransaction(requestData);
    }

    public async Task<MollieCreditcardStatusResponse> CreateTransaction(MollieCreditcardCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieCreditcardStatusResponse>(requestData);
      return response;
    }

    new public async Task<MollieCreditcardStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieCreditcardStatusResponse>(id);
      return response;
    }

    new public async Task<MollieCreditcardRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieCreditcardRefundResponse>(id);
      return response;
    }
  }
}
