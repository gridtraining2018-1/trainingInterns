using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ClsForum 
    {

        public int ForumID { get; set; }
        public int CatID { get; set; }
        public int SubID { get; set; }
        public int ForumOrder { get; set; }
        public string Formname { get; set; }
        public string Formumdescription { get; set; }
        public int NoOfTopics { get; set; }
        public int NoOfPosts { get; set; }
        public int AuthorID { get; set; }
        public DateTime LastPostDate { get; set; }
        public string strLastPostDate { get; set; }
        public string Password { get; set; }
        public string ForumCode { get; set; }
        public bool ShowTopics { get; set; }
        public string ForumURL { get; set; }
        public string ForumIcon { get; set; }
        
         
        public ClsCategory Category { get; set; }
        public clsRegistration Auther { get; set; }
        public ClsTopics Topics { get; set; }



    }

}

