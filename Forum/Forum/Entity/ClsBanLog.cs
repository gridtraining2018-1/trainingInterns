using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ClsBanLog
    {
        public string IP { get; set; }
        public string Reason { get; set; }
        public string Type { get; set; }
        public int Reported_By { get; set; }
        public int Thread_ID { get; set; }
        
        public clsRegistration Forum { get; set; }
        public ClsThread Thread { get; set; }
    }
}
