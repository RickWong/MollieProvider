using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Ideal
{
  public class MollieIdeal : Mollie
  {
    private readonly string mollieIssuersUrl = "https://api.mollie.nl/v1/issuers/";

    public MollieIdeal(string Key) : base(Key)
    {

    }
    public async Task<MollieIssuersResponse> GetIssuers()
    {
      var response = await base.SendJsonRequest<MollieIssuersResponse>(mollieIssuersUrl, HttpMethod.Get);
      return response;
    }

    public async Task<MollieIdealStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, string issuer = null, Dictionary<string, string> metadata = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale, metadata) as MollieIdealCreateRequest;
      requestData.Method = "ideal";
      requestData.Issuer = issuer;

      return await CreateTransaction(requestData);
    }

    public async Task<MollieIdealStatusResponse> CreateTransaction(MollieIdealCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieIdealStatusResponse>(requestData);
      return response;
    }

    new public async Task<MollieIdealStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieIdealStatusResponse>(id);
      return response;
    }

    new public async Task<MollieIdealRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieIdealRefundResponse>(id);
      return response;
    }
  }
}
