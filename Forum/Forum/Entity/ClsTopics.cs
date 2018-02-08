using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ClsTopics
    {
            public int TopicID { get; set; }
            public int ForumID { get; set; }
            public int MovedID{get;set;}
	        public string Subject{get;set;}
	        public string Icon{get;set;}
	        public int StartThreadID{get;set;}
	        public int LastThreadID{get;set;}
            public string StartThreadCreatedBy { get; set; }
            public string LastThreadCreatedBy { get; set; }
            public int StartThreadCreatedByID { get; set; }
            public int LastThreadCreatedByID { get; set; }
	        public int Noofreplies{get;set;}
	        public int Noofviews{get;set;}
	        public int Priority{get;set;}
	        public bool Locked{get;set;}
	        public bool Hide{get;set;}
	        public DateTime Eventdate{get;set;}
	        public DateTime Eventdateend{get;set;}
	        public float Rating{get;set;}
	        public int RatingTotal{get;set;}
            public int RatingVotes { get; set; }
            public int RowNum { get; set; }

            public ClsForum Forum { get; set; }
            public ClsThread Thread { get; set; }

   
        
    }
}
