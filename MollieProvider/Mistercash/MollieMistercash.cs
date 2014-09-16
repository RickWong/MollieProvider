using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Mistercash
{
  public class MollieMistercash : Mollie
  {
    public MollieMistercash(string Key) : base(Key) { }

    public async Task<MollieMistercashStatusResponse> CreateTransaction(MollieMistercashCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieMistercashStatusResponse>(requestData);
      return response;
    }

    public async Task<MollieMistercashStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieMistercashStatusResponse>(id);
      return response;
    }

    public async Task<MollieMistercashRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieMistercashRefundResponse>(id);
      return response;
    }
  }
}
