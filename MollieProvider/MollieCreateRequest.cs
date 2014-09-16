using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider
{
  public class MollieCreateRequest
  {
    public double Amount { get; set; }

    public string Description { get; set; }

    public string RedirectUrl { get; set; }

    public string Method { get; set; }

    public string WebhookUrl { get; set; }

    public string Locale { get; set; }
  }
}
