using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Paysafecard
{
  public class MolliePaysafecardCreateRequest : MollieCreateRequest
  {
    public string CustomerReference { get; set; }
  }
}
