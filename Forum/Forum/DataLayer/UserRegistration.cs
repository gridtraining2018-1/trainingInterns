using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using Entity;



namespace DataLayer
{
    public class UserRegistration
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        }


        public int CreateUser(clsRegistration UserDetails)
        {
            if (!IsUserExist(UserDetails.Username))
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "Insert Into tblAuthor (Username, Group_ID, Real_name,User_code,Password,Join_Date,Last_Visit,Author_email,Active) " +
                                   " Values('" + UserDetails.Username.Trim() + "',4,'" + UserDetails.Realname.Trim() + "','" + UserDetails.Username.Trim()+DateTime.Now + "','" + UserDetails.Password.Trim() +
                                   "','" + DateTime.Now + "','" + DateTime.Now + "','"+ UserDetails.Authoremail.Trim() +"',1)";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    try
                    {
                        SqlConn.Open();
                        SqlCom.ExecuteNonQuery();

                    }
                    catch (Exception Ex)
                    {
                        return 0;
                        throw new Exception(Ex.Message);


                    }
                    finally
                    {
                        SqlConn.Close();
                    }

               
                       

                }
                return 1;

            }
            else
            {
                return 2;
            }

        }

        public int UpdateProfile(clsRegistration profile)
        {
            
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString =  "Update tblAuthor Set Real_name = '"+profile.Realname+"',Bio ='"+profile.Bio+"',DOB ='"+profile.DOB+"',Facebook ='"+profile.Facebook+"'"
                                    +" ,Homepage ='"+profile.Homepage+"',Location ='"+profile.Location+"',Signature ='"+profile.Signature+"',Skype ='"+profile.Skype+"',LinkedIn = '"+profile.LinkedIn+"'"
                                    + ",Twitter ='" + profile.Twitter + "',MSN ='" + profile.MSN + "',Yahoo ='" + profile.Yahoo + "',Gender ='" + profile.Gender + "', Modify_date = '" + DateTime.Now + "'"
                                    + ", AIM ='"+profile.AIM+"' Where Author_ID = " + profile.AuthorID;
                
               
                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    try
                    {
                        SqlConn.Open();
                        SqlCom.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {
                        return 0;
                        throw new Exception(Ex.Message);


                    }
                    finally
                    {
                        SqlConn.Close();
                    }



                }
                return 1;

      

        }

        private bool IsUserExist(string UserName)   
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string IsExist;
           

            using (SqlCommand SqlCom = new SqlCommand("Select UserName from tblAuthor where UserName ='" + UserName+"'",SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                IsExist = Convert.ToString(SqlCom.ExecuteScalar());
                SqlConn.Close();
            }

            return string.IsNullOrEmpty(IsExist) ? false : true;
        }

        public List<clsRegistration> getUserDetails(string UserName, string Password, string AutherID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();

            string SqlQuery = null;
            if(AutherID =="0")
            {
            SqlQuery = "Select Author_ID, Real_name,Author_email, Gender, Photo, Location, "
                + " MSN, Yahoo, ICQ, AIM,Occupation,Interests,DOB, Signature,	No_of_posts, Points,Join_date, Avatar, Avatar_title,"
                + " Last_visit, Show_email,Attach_signature, Rich_editor,	Reply_notify, Skype, Newsletter,Info,Bio,"
                + " PM_notify, Answered, Thanked, LinkedIn,	Facebook,Twitter,HomePage,UID from tblAuthor where "
                + " Author_email ='" + UserName + "' AND Password ='" + Password + "' AND Active = 1";
            }
            else
            {
              SqlQuery =   "SELECT   Author_ID , Username , Real_name ,  Author_email, Gender, Photo, Homepage, Location, Yahoo, ICQ, MSN, AIM,"
                              + " Occupation, Interests, DOB, Signature, No_of_posts, Points, Join_date, ISNULL(tblAuthor.Avatar,'avatars/ImagenotAvailabel.gif') As Avatar, Avatar_title, Last_visit, Time_offset, "
                              + " Time_offset_hours, Date_format, No_of_PM, Inbox_no_of_PM, Show_email, Attach_signature, Active, Rich_editor, Reply_notify,"
                              + " PM_notify, Skype, Login_attempt, Banned, Newsletter, Info, Login_IP, Custom1, "
                              + " Custom2, Bio, Answered, Thanked,  LinkedIn, Facebook, Twitter,UID FROM tblAuthor Where Active = 1 AND ";
                int value;
                if(int.TryParse(AutherID, out value))
                {
                    SqlQuery = SqlQuery + " Author_ID = " + value;
                }
                else
                {
                    SqlQuery = SqlQuery + " UID = '" + AutherID +"'";
                }
                 
            }

            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.CommandType = CommandType.Text;
                    SqlDataReader Reader = SqlCom.ExecuteReader();

                    while (Reader.Read())
                    {
                        clsRegistration ClsUserDetail = new clsRegistration();

                        ClsUserDetail.AuthorID = Convert.ToInt32(Reader["Author_ID"]);
                        ClsUserDetail.Authoremail = Convert.ToString(Reader["Author_email"]);
                        ClsUserDetail.AIM = Convert.ToString(Reader["AIM"]);
                        ClsUserDetail.Avatar = string.IsNullOrEmpty(Convert.ToString(Reader["Avatar"])) ? "avatars/ImagenotAvailabel.gif" : Convert.ToString(Reader["Avatar"]);
                        ClsUserDetail.Avatartitle = Convert.ToString(Reader["Avatar_title"]);
                        ClsUserDetail.Answered = Convert.ToInt32(Reader["Answered"]);
                        ClsUserDetail.Bio = string.IsNullOrEmpty(Convert.ToString(Reader["Bio"])) ? "User has not yet added a bio to their profile." : Convert.ToString(Reader["Bio"]);
                        ClsUserDetail.DOB = Convert.IsDBNull((Reader["DOB"])) ? default(DateTime) : Convert.ToDateTime(Reader["DOB"]);
                        ClsUserDetail.Facebook = Convert.ToString(Reader["Facebook"]);
                        ClsUserDetail.Gender = Convert.ToString(Reader["Gender"]);
                        ClsUserDetail.Homepage = Convert.ToString(Reader["Homepage"]);
                        ClsUserDetail.Interests = Convert.ToString(Reader["Interests"]);
                        ClsUserDetail.Info = Convert.ToString(Reader["Info"]);
                        ClsUserDetail.Joindate = Convert.ToDateTime(Reader["Join_date"]);
                        ClsUserDetail.Lastvisit = Convert.ToDateTime(Reader["Last_visit"]);
                        ClsUserDetail.LinkedIn = Convert.ToString(Reader["LinkedIn"]);
                        ClsUserDetail.Location = Convert.ToString(Reader["Location"]);
                        ClsUserDetail.MSN = Convert.ToString(Reader["MSN"]);
                        ClsUserDetail.Newsletter = Convert.IsDBNull((Reader["Newsletter"])) ? false : Convert.ToBoolean(Reader["Newsletter"]);
                        ClsUserDetail.Noofposts = Convert.IsDBNull((Reader["No_of_posts"])) ? 0 : Convert.ToInt32(Reader["No_of_posts"]);
                        ClsUserDetail.Occupation = Convert.ToString(Reader["Occupation"]);
                        ClsUserDetail.Photo = Convert.ToString(Reader["Photo"]);
                        ClsUserDetail.Points = Convert.IsDBNull((Reader["Points"])) ? 0 : Convert.ToInt32(Reader["Points"]);
                        ClsUserDetail.Realname = Convert.ToString(Reader["Real_name"]);
                        ClsUserDetail.Replynotify = Convert.IsDBNull((Reader["Reply_notify"])) ? false : Convert.ToBoolean(Reader["Reply_notify"]);
                        ClsUserDetail.Signature = Convert.ToString(Reader["Signature"]);
                        ClsUserDetail.Showemail = Convert.IsDBNull((Reader["Show_email"])) ? false : Convert.ToBoolean(Reader["Show_email"]);
                        ClsUserDetail.Skype = Convert.ToString(Reader["Skype"]);
                        ClsUserDetail.Twitter = Convert.ToString(Reader["Twitter"]);
                        ClsUserDetail.Yahoo = Convert.ToString(Reader["Yahoo"]);
                        ClsUserDetail.UID = Convert.ToString(Reader["UID"]);
                        
                        lstUserDetails.Add(ClsUserDetail);
                    }
                    SqlConn.Close();
                }
                catch(Exception Ex)
                {
                    ExceptionUtility.LogException(Ex, "public List<clsRegistration> getUserDetails(string "+UserName+", string "+Password+", string "+AutherID+")");
                }   
            }
            return lstUserDetails;
            
        }


        public int ActivateProfile(string UID)
        {

            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "Update tblAuthor SET  Active = 1  Where UID = '" + UID +"'";


            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    return 0;
                    throw new Exception(Ex.Message);


                }
                finally
                {
                    SqlConn.Close();
                }



            }
            return 1;



        }
        public int UpdateLastVisit(string Author_ID)
        {

            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "Update tblAuthor SET  Last_visit = getdate()  Where Author_ID = '" + Author_ID + "'";


            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    return 0;
                    throw new Exception(Ex.Message);


                }
                finally
                {
                    SqlConn.Close();
                }



            }
            return 1;



        }
        public List<clsRegistration> getDetailsforPasswordRecovery(string Email)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();

           string SqlQuery = "Select Real_name, UID from tblAuthor where Author_email ='" + Email + "' AND Active = 1";

           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                    SqlConn.Open();
                    SqlCom.CommandType = CommandType.Text;
                    SqlDataReader Reader = SqlCom.ExecuteReader();
             while (Reader.Read())
                    {
                        clsRegistration ClsUserDetail = new clsRegistration();
                        ClsUserDetail.Realname = Convert.ToString(Reader["Real_name"]);
                        ClsUserDetail.UID = Convert.ToString(Reader["UID"]);
                        lstUserDetails.Add(ClsUserDetail);
                    }
                    SqlConn.Close();
                }
                catch
                {
                }   
            }
            return lstUserDetails;
        
        }

        public int UpdatePassword(string UID,string password)
        {

            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "Update tblAuthor SET  password = '" + password + "'  Where UID = '" + UID + "'";


            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    return 0;
                    throw new Exception(Ex.Message);


                }
                finally
                {
                    SqlConn.Close();
                }



            }
            return 1;



        }

        public List<clsRegistration> getMemberList(int AutherID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();

            string SqlQuery = "SELECT Author_ID, UserName, Join_date, Points, Last_visit FROM tblAuthor where Author_ID !=" + AutherID + " AND Active = 1 ORDER BY Last_visit DESC";

            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.CommandType = CommandType.Text;
                    SqlDataReader Reader = SqlCom.ExecuteReader();
                    while (Reader.Read())
                    {
                        clsRegistration ClsUserDetail = new clsRegistration();
                        ClsUserDetail.AuthorID = Convert.ToInt32(Reader["Author_ID"]);
                        ClsUserDetail.Joindate = Convert.ToDateTime(Reader["Join_date"]);
                        ClsUserDetail.Lastvisit = Convert.ToDateTime(Reader["Last_visit"]);
                        ClsUserDetail.Points = Convert.IsDBNull((Reader["Points"])) ? 0 : Convert.ToInt32(Reader["Points"]);
                        ClsUserDetail.Username = Convert.ToString(Reader["UserName"]); 
                       
                        lstUserDetails.Add(ClsUserDetail);
                    }
                    SqlConn.Close();
                }
                catch
                {
                }
            }
            return lstUserDetails;

        }

        public List<clsRegistration> getMyBuddyList(int AutherID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();

                    string SqlQuery = "SELECT tblAuthor.Author_ID, tblAuthor.Username, tblAuthor.Join_date,tblAuthor.Avatar, tblAuthor.Points, tblAuthor.Last_visit "
                                      + " FROM  tblAuthor INNER JOIN tblBuddyList ON tblAuthor.Author_ID = tblBuddyList.Buddy_ID Where tblAuthor.Author_ID IN"
                                      + " (SELECT Buddy_ID As Author_ID FROM dbo.tblBuddyList  Where Author_ID  = "+AutherID+" UNION SELECT Author_ID As Buddy_ID FROM dbo.tblBuddyList WHERE Buddy_id = "+AutherID+")"; 
       

            using ( SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.CommandType = CommandType.Text;
                    SqlDataReader Reader = SqlCom.ExecuteReader();
                    while (Reader.Read())
                    {
                        clsRegistration ClsUserDetail = new clsRegistration();
                        ClsUserDetail.AuthorID = Convert.ToInt32(Reader["Author_ID"]);
                        ClsUserDetail.Joindate = Convert.ToDateTime(Reader["Join_date"]);
                        ClsUserDetail.strJoindate = ClsUserDetail.Joindate.ToString("dd-MM-yyyy"); 
                        ClsUserDetail.Lastvisit = Convert.ToDateTime(Reader["Last_visit"]);
                        ClsUserDetail.strLastvisit = ClsUserDetail.Lastvisit.ToString("dd-MM-yyyy");
                        ClsUserDetail.Points = Convert.IsDBNull((Reader["Points"])) ? 0 : Convert.ToInt32(Reader["Points"]);
                        ClsUserDetail.Username = Convert.ToString(Reader["UserName"]);
                        ClsUserDetail.Avatar = string.IsNullOrEmpty(Convert.ToString(Reader["Avatar"])) ? "avatars/ImagenotAvailabel.gif" : Convert.ToString(Reader["Avatar"]);

                        lstUserDetails.Add(ClsUserDetail);
                    }
                    SqlConn.Close();
                }
                catch
                {
                }
            }
            return lstUserDetails;

        }

        public List<clsRegistration> getMyBuddyListSearch(int AutherID,string strBuddyName)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            List<clsRegistration> lstUserDetails = new List<clsRegistration>();

            string SqlQuery = "SELECT tblAuthor.Author_ID, tblAuthor.Username, tblAuthor.Join_date,tblAuthor.Avatar, tblAuthor.Points, tblAuthor.Last_visit "
                              + " FROM  tblAuthor INNER JOIN tblBuddyList ON tblAuthor.Author_ID = tblBuddyList.Buddy_ID Where tblAuthor.Author_ID IN"
                              + " (SELECT Buddy_ID As Author_ID FROM dbo.tblBuddyList  Where Author_ID  = " + AutherID + " UNION SELECT Author_ID As Buddy_ID FROM dbo.tblBuddyList WHERE Buddy_id = " + AutherID + ") and tblAuthor.username like '%" + strBuddyName + "%'";


            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.CommandType = CommandType.Text;
                    SqlDataReader Reader = SqlCom.ExecuteReader();
                    while (Reader.Read())
                    {
                        clsRegistration ClsUserDetail = new clsRegistration();
                        ClsUserDetail.AuthorID = Convert.ToInt32(Reader["Author_ID"]);
                        ClsUserDetail.Joindate = Convert.ToDateTime(Reader["Join_date"]);
                        ClsUserDetail.strJoindate = ClsUserDetail.Joindate.ToString("dd-MM-yyyy");
                        ClsUserDetail.Lastvisit = Convert.ToDateTime(Reader["Last_visit"]);
                        ClsUserDetail.strLastvisit = ClsUserDetail.Lastvisit.ToString("dd-MM-yyyy");
                        ClsUserDetail.Points = Convert.IsDBNull((Reader["Points"])) ? 0 : Convert.ToInt32(Reader["Points"]);
                        ClsUserDetail.Username = Convert.ToString(Reader["UserName"]);
                        ClsUserDetail.Avatar = string.IsNullOrEmpty(Convert.ToString(Reader["Avatar"])) ? "avatars/ImagenotAvailabel.gif" : Convert.ToString(Reader["Avatar"]);

                        lstUserDetails.Add(ClsUserDetail);
                    }
                    SqlConn.Close();
                }
                catch
                {
                }
            }
            return lstUserDetails;

        }

        public int UploadImage(string ImgName, int AutherID)
        {

            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "Update tblAuthor SET  avatar = 'avatars/" + ImgName + "'  Where Author_ID = '" + AutherID + "'";


            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                try
                {
                    SqlConn.Open();
                    SqlCom.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    return 0;
                    throw new Exception(Ex.Message);


                }
                finally
                {
                    SqlConn.Close();
                }



            }
            return 1;



        }

    }
}
