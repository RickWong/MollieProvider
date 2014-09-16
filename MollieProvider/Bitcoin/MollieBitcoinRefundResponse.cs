using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Bitcoin
{
  public class MollieBitcoinRefundResponse : MollieRefundResponse
  {
    public MollieBitcoinStatusResponse Payment { get; set; }
  }
}
