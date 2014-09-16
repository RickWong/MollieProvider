using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Banktransfer
{
  public class MollieBanktransferRefundResponse : MollieRefundResponse
  {
    public MollieBanktransferStatusResponse Payment { get; set; }
  }
}
