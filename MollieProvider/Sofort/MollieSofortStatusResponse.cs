using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Sofort
{
  public class MollieSofortStatusResponse : MollieStatusResponse
  {
    public SofortDetails Details { get; set; }
  }

  public class SofortDetails
  {
    public string ConsumerName { get; set; }

    public string ConsumerAccount { get; set; }

    public string ConsumerBic { get; set; }
  }
}
