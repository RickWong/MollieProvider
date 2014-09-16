using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paysafecard
{
  public class MolliePaysafecardRefundResponse : MollieRefundResponse
  {
    public MolliePaysafecardStatusResponse Payment { get; set; }
  }
}
