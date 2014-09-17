using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider
{
  public class MollieRefundResponse : MollieResponse
  {
    public string Id { get; set; }

    public string AmountRefunded { get; set; }

    public string AmountRemaining { get; set; }

    public DateTime RefundedDatetime { get; set; }
  }
}
