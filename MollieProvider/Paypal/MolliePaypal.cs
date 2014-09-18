using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paypal
{
  public class MolliePaypal : Mollie
  {
    public MolliePaypal(string Key) : base(Key) { }

    public async Task<MolliePaypalStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null,
      string shippingAddress = null, string shippingCity = null, string shippingRegion = null, string shippingPostal = null, string shippingCountry = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale, metadata) as MolliePaypalCreateRequest;
      requestData.Method = "paypal";
      requestData.ShippingAddress = shippingAddress;
      requestData.ShippingCity = shippingCity;
      requestData.ShippingRegion = shippingRegion;
      requestData.ShippingPostal = shippingPostal;
      requestData.ShippingCountry = shippingCountry;

      return await CreateTransaction(requestData);
    }

    public async Task<MolliePaypalStatusResponse> CreateTransaction(MolliePaypalCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MolliePaypalStatusResponse>(requestData);
      return response;
    }

    new public async Task<MolliePaypalStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MolliePaypalStatusResponse>(id);
      return response;
    }

    new public async Task<MolliePaypalRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MolliePaypalRefundResponse>(id);
      return response;
    }
  }
}
