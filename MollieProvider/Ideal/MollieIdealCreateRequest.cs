using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Ideal
{
  public class MollieIdealCreateRequest : MollieCreateRequest
  {
    public string Issuer { get; set; }
  }
}
