using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Banktransfer
{
  public class MollieBanktransferStatusResponse : MollieStatusResponse
  {
    public BanktransferDetails Details { get; set; }
  }

  public class BanktransferDetails
  {
    public string BankName { get; set; }

    public string BankAccount { get; set; }

    public string BankBic { get; set; }

    public string TransferReference { get; set; }

    public string ConsumerName { get; set; }

    public string ConsumerAccount { get; set; }

    public string ConsumerBic { get; set; }
  }
}
