using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class SendPM
    {
      public int PM_ID{get;set;}
      public int Author_ID{get; set;}
      public int  From_ID{get; set;}
      public string PM_Tittle{get; set;}
      public string PM_Message{get; set;}
      public DateTime PM_Message_date{get; set;}
      public string strPm_Message_date { get; set; }
      public bool Read_Post{get; set;}
      public bool Email_notify { get; set; }
      public string PM_IDuni { get; set; }

      public clsRegistration toautor { get; set; }
      public clsRegistration fromAuthor { get; set; }
    }
}
