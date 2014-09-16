using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Bitcoin
{
  public class MollieBitcoin : Mollie
  {
    public MollieBitcoin(string Key) : base(Key) { }

    public async Task<MollieBitcoinStatusResponse> CreateTransaction(MollieBitcoinCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieBitcoinStatusResponse>(requestData);
      return response;
    }

    public async Task<MollieBitcoinStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieBitcoinStatusResponse>(id);
      return response;
    }

    public async Task<MollieBitcoinRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieBitcoinRefundResponse>(id);
      return response;
    }
  }
}
