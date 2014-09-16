using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paypal
{
  public class MolliePaypalStatusResponse : MollieStatusResponse
  {
    public PaypalDetails Details { get; set; }
  }

  public class PaypalDetails
  {
    public string ConsumerName { get; set; }

    public string ConsumerAccount { get; set; }

    public string PaypalReference { get; set; }
  }
}
