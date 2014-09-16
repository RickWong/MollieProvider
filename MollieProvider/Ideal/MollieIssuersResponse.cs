using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider
{
  public class MollieIssuersResponse
  {
    public int TotalCount { get; set; }

    public int Offset { get; set; }

    public int Count { get; set; }

    public IEnumerable<MollieIssuer> Data { get; set; }
  }

  public class MollieIssuer
  {
    public string Id { get; set; }

    public string Name { get; set; }

    public string Method { get; set; }
  }
}
