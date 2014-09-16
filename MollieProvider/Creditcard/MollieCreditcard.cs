using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Creditcard
{
  public class MollieCreditcard : Mollie
  {

    public MollieCreditcard(string Key) : base(Key) { }

    public async Task<MollieCreditcardStatusResponse> CreateTransaction(MollieCreditcardCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieCreditcardStatusResponse>(requestData);
      return response;
    }

    public async Task<MollieCreditcardStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieCreditcardStatusResponse>(id);
      return response;
    }

    public async Task<MollieCreditcardRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieCreditcardRefundResponse>(id);
      return response;
    }
  }
}
