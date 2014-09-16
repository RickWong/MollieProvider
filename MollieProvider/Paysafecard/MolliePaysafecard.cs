using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paysafecard
{
  public class MolliePaysafecard : Mollie
  {
    public MolliePaysafecard(string Key) : base(Key) { }

    public async Task<MolliePaysafecardStatusResponse> CreateTransaction(MolliePaysafecardCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MolliePaysafecardStatusResponse>(requestData);
      return response;
    }

    public async Task<MolliePaysafecardStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MolliePaysafecardStatusResponse>(id);
      return response;
    }

    public async Task<MolliePaysafecardRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MolliePaysafecardRefundResponse>(id);
      return response;
    }
  }
}
