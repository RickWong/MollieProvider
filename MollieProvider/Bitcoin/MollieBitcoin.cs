using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Bitcoin
{
  public class MollieBitcoin : Mollie
  {
    public MollieBitcoin(string Key) : base(Key) { }

    new public async Task<MollieBitcoinStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale, metadata) as MollieBitcoinCreateRequest;
      requestData.Method = "bitcoin";

      return await CreateTransaction(requestData);
    }

    public async Task<MollieBitcoinStatusResponse> CreateTransaction(MollieBitcoinCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieBitcoinStatusResponse>(requestData);
      return response;
    }

    new public async Task<MollieBitcoinStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieBitcoinStatusResponse>(id);
      return response;
    }

    new public async Task<MollieBitcoinRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieBitcoinRefundResponse>(id);
      return response;
    }
  }
}
