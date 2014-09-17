using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider
{
  public class MollieResponse
  {
    public MollieError Error { get; set; }
  }

  public class MollieError
  {
    public string Type { get; set; }

    public string Message { get; set; }
  }
}
