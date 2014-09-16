using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Bitcoin
{
  public class MollieBitcoinStatusResponse : MollieStatusResponse
  {
    public BitcoinDetails Details { get; set; }
  }

  public class BitcoinDetails
  {
    public string BitcoinAddress { get; set; }

    public string BitcoinAmount { get; set; }

    public string BitcoinRate { get; set; }

    public string BitcoinUri { get; set; }
  }
}
