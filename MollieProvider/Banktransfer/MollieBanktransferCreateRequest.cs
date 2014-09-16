using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider.Banktransfer
{
  public class MollieBanktransferCreateRequest : MollieCreateRequest
  {
    public string BillingEmail { get; set; }

    public DateTime DueDate { get; set; }
  }
}
