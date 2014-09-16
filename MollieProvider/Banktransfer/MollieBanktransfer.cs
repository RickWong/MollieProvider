using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Banktransfer
{
  public class MollieBanktransfer : Mollie
  {
    public MollieBanktransfer(string Key) : base(Key) { }

    public async Task<MollieBanktransferStatusResponse> CreateTransaction(MollieBanktransferCreateRequest requestData)
    {
      var response = await base.CreateTransaction<MollieBanktransferStatusResponse>(requestData);
      return response;
    }

    public async Task<MollieBanktransferStatusResponse> GetTransactionStatus(string id)
    {
      var response = await base.GetTransactionStatus<MollieBanktransferStatusResponse>(id);
      return response;
    }

    public async Task<MollieBanktransferRefundResponse> RefundTransaction(string id)
    {
      var response = await base.RefundTransaction<MollieBanktransferRefundResponse>(id);
      return response;
    }
  }
}
