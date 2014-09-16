using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paysafecard
{
  public class MolliePaysafecardStatusResponse : MollieStatusResponse
  {
    public PaysafecardDetails Details { get; set; }
  }

  public class PaysafecardDetails
  {
    public string CustomerReference { get; set; }
  }
}
