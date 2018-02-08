using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class clsBuddyList
    {
        public int Address_ID { get; set; }
        public int Author_ID { get; set; }
        public int Buddy_ID { get; set; }
        public string Description { get; set; }
        public bool Block { get; set; }
        public bool isApproved { get; set; }

        public clsRegistration author { get; set; }
        public clsRegistration buddy { get; set; }
    }
}
