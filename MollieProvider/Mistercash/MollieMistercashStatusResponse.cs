using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Mistercash
{
  public class MollieMistercashStatusResponse : MollieStatusResponse
  {
    public MistercashDetails Details { get; set; }
  }

  public class MistercashDetails
  {
    public string CardNumber { get; set; }
  }
}
