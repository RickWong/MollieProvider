using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paypal
{
  public class MolliePaypal : Mollie
  {
    public MolliePaypal(string Key) : base(Key) { }

    public async Task<MolliePaypalStatusResponse> CreateTransaction(MolliePaypalCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MolliePaypalStatusResponse>(requestData);
      return response;
    }

    public async Task<MolliePaypalStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MolliePaypalStatusResponse>(id);
      return response;
    }

    public async Task<MolliePaypalRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MolliePaypalRefundResponse>(id);
      return response;
    }
  }
}
