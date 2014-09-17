using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Sofort
{
  public class MollieSofort : Mollie
  {
    public MollieSofort(string Key) : base(Key) { }

    public async Task<MollieSofortStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, string issuer = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale) as MollieSofortCreateRequest;
      requestData.Method = "sofort";

      return await CreateTransaction(requestData);
    }

    public async Task<MollieSofortStatusResponse> CreateTransaction(MollieSofortCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieSofortStatusResponse>(requestData);
      return response;
    }

    new public async Task<MollieSofortStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieSofortStatusResponse>(id);
      return response;
    }

    new public async Task<MollieSofortRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieSofortRefundResponse>(id);
      return response;
    }
  }
}
