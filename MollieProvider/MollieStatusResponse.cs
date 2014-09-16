using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider
{
  public class MollieStatusResponse
  {
    public string Id { get; set; }

    public string Mode { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public DateTime PaidDateTime { get; set; }

    public DateTime CancelledDateTime { get; set; }

    public DateTime ExpiredDateTime { get; set; }

    public string Status { get; set; }

    public double Amount { get; set; }

    public string Description { get; set; }

    public string Method { get; set; }

    public MollieLinks Links { get; set; }
  }

  public class MollieLinks
  {
    public string PaymentUrl { get; set; }

    public string redirectUrl { get; set; }
  }
}
