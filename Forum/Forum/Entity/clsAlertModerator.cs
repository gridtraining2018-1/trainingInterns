using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
  public  class clsAlertModerator
    {
      public int AleartModeratorID { get; set; }
      public string Type { get; set; }
      public string Reason { get; set; }
      public int ThreadID { get; set; }
      public int ReportedByID { get; set; }
      public DateTime ReportedOnDate { get; set; }

      public ClsThread thread { get; set; }
      public clsRegistration author { get; set; }
    }
}
