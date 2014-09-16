using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paypal
{
  public class MolliePaypalCreateRequest : MollieCreateRequest
  {
    public string ShippingAddress { get; set; }

    public string ShippingCity { get; set; }

    public string ShippingRegion { get; set; }

    public string ShippingPostal { get; set; }

    public string ShippingCountry { get; set; }
  }
}
