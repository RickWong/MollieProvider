using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paypal
{
  public class MolliePaypalRefundResponse : MollieRefundResponse
  {
    public MolliePaypalStatusResponse Payment { get; set; }
  }
}
