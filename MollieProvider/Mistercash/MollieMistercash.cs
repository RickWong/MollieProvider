using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Mistercash
{
  public class MollieMistercash : Mollie
  {
    public MollieMistercash(string Key) : base(Key) { }

    new public async Task<MollieMistercashStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale, metadata) as MollieMistercashCreateRequest;
      requestData.Method = "mistercash";

      return await CreateTransaction(requestData);
    }

    public async Task<MollieMistercashStatusResponse> CreateTransaction(MollieMistercashCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieMistercashStatusResponse>(requestData);
      return response;
    }

    new public async Task<MollieMistercashStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieMistercashStatusResponse>(id);
      return response;
    }

    new public async Task<MollieMistercashRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieMistercashRefundResponse>(id);
      return response;
    }
  }
}
