using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Creditcard
{
  public class MollieCreditcardStatusResponse : MollieStatusResponse
  {
    public CreditcardDetails Details { get; set; }
  }

  public class CreditcardDetails
  {
    public string CardHolder { get; set; }

    public string CardNumber { get; set; }

    public string CardSecurity { get; set; }
  }
}
