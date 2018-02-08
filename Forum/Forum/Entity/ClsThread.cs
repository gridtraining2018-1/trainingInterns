using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class ClsThread
    {
       public int Thread_ID { get; set; }
       public int Topic_ID { get; set; }
       public int  Author_ID { get; set; }
       public DateTime  Message_date { get; set; }
       public string strMessageDate { get; set; }
       public string IP_addr { get; set; }
       public bool Show_signature { get; set; }
       public bool  Hide { get; set; }
       public bool  Answer { get; set; }
       public int Thanks { get; set; }
       public string Message { get; set; }

       public clsRegistration Auther { get; set; }
       public ClsTopics Topic { get; set; }
       public List<clsAlertModerator> alertModeraor { get; set; }

    }
}
