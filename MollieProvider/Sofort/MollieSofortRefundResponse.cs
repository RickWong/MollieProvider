using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Sofort
{
  public class MollieSofortRefundResponse : MollieRefundResponse
  {
    public MollieSofortStatusResponse Payment { get; set; }
  }
}
