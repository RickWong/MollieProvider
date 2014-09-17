using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paysafecard
{
  public class MolliePaysafecard : Mollie
  {
    public MolliePaysafecard(string Key) : base(Key) { }

    public async Task<MolliePaysafecardStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, string customerReference = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale) as MolliePaysafecardCreateRequest;
      requestData.Method = "paysafecard";
      requestData.CustomerReference = customerReference;

      return await CreateTransaction(requestData);
    }

    public async Task<MolliePaysafecardStatusResponse> CreateTransaction(MolliePaysafecardCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MolliePaysafecardStatusResponse>(requestData);
      return response;
    }

    new public async Task<MolliePaysafecardStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MolliePaysafecardStatusResponse>(id);
      return response;
    }

    new public async Task<MolliePaysafecardRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MolliePaysafecardRefundResponse>(id);
      return response;
    }
  }
}
