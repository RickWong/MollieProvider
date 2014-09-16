using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Creditcard
{
  public class MollieCreditcardCreateRequest : MollieCreateRequest
  {
    public string BillingCity { get; set; }

    public string BillingRegion { get; set; }

    public string BillingPostal { get; set; }

    public string BillingCountry { get; set; }

    public string ShippingAddress { get; set; }

    public string ShippingCity { get; set; }

    public string ShippingRegion { get; set; }

    public string ShippingPostal { get; set; }

    public string ShippingCountry { get; set; }
  }
}
