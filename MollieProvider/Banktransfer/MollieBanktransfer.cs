using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Banktransfer
{
  public class MollieBanktransfer : Mollie
  {
    public MollieBanktransfer(string Key) : base(Key) { }

    public async Task<MollieBanktransferStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null,
      string billingEmail = null, DateTime? dueDate = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale, metadata) as MollieBanktransferCreateRequest;
      requestData.Method = "banktransfer";
      requestData.BillingEmail = billingEmail;
      requestData.DueDate = dueDate;

      return await CreateTransaction(requestData);
    }

    public async Task<MollieBanktransferStatusResponse> CreateTransaction(MollieBanktransferCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieBanktransferStatusResponse>(requestData);
      return response;
    }

    new public async Task<MollieBanktransferStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieBanktransferStatusResponse>(id);
      return response;
    }

    new public async Task<MollieBanktransferRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieBanktransferRefundResponse>(id);
      return response;
    }
  }
}
