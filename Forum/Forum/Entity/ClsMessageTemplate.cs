using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ClsMessageTemplate
    {
       public int Id {get;set;}
       public string Name {get;set;}
       public string BccEmailAddresses {get;set;}
       public string Subject {get;set;}
       public string Body {get;set;}
       public string IsActive {get;set;}
       public string EmailAccountId {get;set;}
       public string LimitedToStores { get; set; }
       public string FromEmail { get; set; }
       public List<string> To { get; set; }
       public List<string> CC { get; set; }
       public List<string> Bcc { get; set; }
       public List<string> ToUserName { get; set; }
       public string UID { get; set; }
      
    }
}
