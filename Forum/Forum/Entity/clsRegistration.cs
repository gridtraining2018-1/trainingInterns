
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class clsRegistration
    {
        public int AuthorID { get; set; }
        public int GroupID { get; set; }
        public string Username { get; set; }
        public string Realname { get; set; }
        public string Usercode { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Authoremail { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Homepage { get; set; }
        public string Location { get; set; }
        public string MSN { get; set; }
        public string Yahoo { get; set; }
        public string ICQ { get; set; }
        public string AIM { get; set; }
        public string Occupation { get; set; }
        public string Interests { get; set; }
        public DateTime DOB { get; set; }
        public string Signature { get; set; }
        public int Noofposts { get; set; }
        public int Points { get; set; }
        public DateTime Joindate { get; set; }
        public string strJoindate { get; set; }
        public string Avatar { get; set; }
        public string Avatartitle { get; set; }
        public DateTime Lastvisit { get; set; }
        public string strLastvisit { get; set; }
        public string Timeoffset { get; set; }
        public int Timeoffsethours { get; set; }
        public string Dateformat { get; set; }
        public int NoofPM { get; set; }
        public int InboxnoofPM { get; set; }
        public bool Showemail { get; set; }
        public bool Attachsignature { get; set; }
        public bool Active { get; set; }
        public bool Richeditor { get; set; }
        public bool Replynotify { get; set; }
        public bool PMnotify { get; set; }
        public string Skype { get; set; }
        public int Loginattempt { get; set; }
        public bool Banned { get; set; }
        public bool Newsletter { get; set; }
        public string Info { get; set; }
        public string LoginIP { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Bio { get; set; }
        public int Answered { get; set; }
        public int Thanked { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public DateTime ModifyDate { get; set; }
        public string UID { get; set; }

        public List<clsAlertModerator> alertModeraor { get; set; }
        public List<ClsThread> Thread { get; set; }
        public List<clsBuddyList> buddylist { get; set; }

    }
}
