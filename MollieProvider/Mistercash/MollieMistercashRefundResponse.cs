using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Mistercash
{
  public class MollieMistercashRefundResponse : MollieRefundResponse
  {
    public MollieMistercashStatusResponse Payment { get; set; }
  }
}
