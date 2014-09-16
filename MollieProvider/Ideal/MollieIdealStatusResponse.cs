using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Ideal
{
  public class MollieIdealStatusResponse : MollieStatusResponse
  {
    public IdealDetails Details { get; set; }
  }

  public class IdealDetails
  {
    public string ConsumerName { get; set; }

    public string ConsumerAccount { get; set; }

    public string ConsumerBic { get; set; }
  }
}
