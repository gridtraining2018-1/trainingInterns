using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class ClsCategory
    {
       public int CatID { get; set; }
       public string CatName { get; set; }
       public int CatOrder { get; set; }
       public string CatDescription { get; set; }

       List<ClsForum> Forum { get; set; }
    }
}
