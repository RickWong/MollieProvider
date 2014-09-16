using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Ideal
{
  public class MollieIdealRefundResponse : MollieRefundResponse
  {
    public MollieIdealStatusResponse Payment { get; set; }
  }
}
