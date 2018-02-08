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
    public class ClsGetRecord
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<ClsForum> GetForum()
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();





            string SqlQuery = "SELECT tblCategory.Cat_ID, tblCategory.Cat_name, tblForum.Forum_ID, tblForum.Forum_name,"
                                + " tblForum.Forum_description, tblForum.No_of_topics, tblForum.No_of_posts, CASE Last_topic_ID WHEN 0 THEN NULL ELSE tblAuthor.Username END AS Username ,"
                                + " tblForum.Last_post_author_ID, "
                                + " tblForum.Last_post_date, tblForum.Last_topic_ID, "
                                + " tblTopic.Subject,tblForum.Forum_URL FROM tblCategory INNER JOIN tblForum ON tblCategory.Cat_ID = tblForum.Cat_ID "
                                + " LEFT JOIN tblTopic ON tblForum.Last_topic_ID = tblTopic.Topic_ID "
                                + " INNER JOIN tblAuthor ON tblForum.Last_post_author_ID = tblAuthor.Author_ID "
                                + " ORDER BY tblCategory.Cat_order, tblForum.Forum_Order ;  ";
            List<ClsForum> lstSqlForum = new List<ClsForum>();

            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {

                SqlConn.Open();


                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();
                while (Reader.Read())
                {
                    ClsForum clsForum = new ClsForum();

                    clsForum.ForumID = Convert.ToInt32(Reader["Forum_ID"]);
                    clsForum.Formname = Convert.ToString(Reader["Forum_name"]);
                    clsForum.Formumdescription = Convert.ToString(Reader["Forum_description"]);
                    clsForum.NoOfTopics = Convert.ToInt32(Reader["No_of_topics"]);
                    clsForum.NoOfPosts = Convert.ToInt32(Reader["No_of_posts"]);
                    clsForum.LastPostDate = Convert.IsDBNull((Reader["Last_post_date"])) ? default(DateTime) : Convert.ToDateTime(Reader["Last_post_date"]);
                    clsForum.strLastPostDate = DateFormate.PostDate(clsForum.LastPostDate);


                    ClsCategory category = new ClsCategory();

                    category.CatID = Convert.ToInt32(Reader["Cat_ID"]);
                    category.CatName = Convert.ToString(Reader["Cat_name"]);

                    clsForum.Category = category;

                    clsRegistration Auther = new clsRegistration();

                    Auther.Username = Convert.ToString(Reader["Username"]);
                    Auther.AuthorID = Convert.ToInt32(Reader["Last_post_author_ID"]);

                    clsForum.Auther = Auther;

                    ClsTopics topic = new ClsTopics();
                    topic.Subject = Convert.ToString(Reader["Subject"]);
                    topic.TopicID = Convert.ToInt32(Reader["Last_topic_ID"]);

                    clsForum.Topics = topic;


                    lstSqlForum.Add(clsForum);
                }

            } 
                return lstSqlForum;
             

            
            
        }

        public List<ClsForum> GetForumSearch(string strSearch)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();

            string SqlQuery = "SELECT tblCategory.Cat_ID, tblCategory.Cat_name, tblForum.Forum_ID, tblForum.Forum_name,"
                                + " tblForum.Forum_description, tblForum.No_of_topics, tblForum.No_of_posts, CASE Last_topic_ID WHEN 0 THEN NULL ELSE tblAuthor.Username END AS Username ,"
                                + " tblForum.Last_post_author_ID, "
                                + " tblForum.Last_post_date, tblForum.Last_topic_ID, "
                                + " tblTopic.Subject,tblForum.Forum_URL FROM tblCategory INNER JOIN tblForum ON tblCategory.Cat_ID = tblForum.Cat_ID "
                                + " LEFT JOIN tblTopic ON tblForum.Last_topic_ID = tblTopic.Topic_ID "
                                + " INNER JOIN tblAuthor ON tblForum.Last_post_author_ID = tblAuthor.Author_ID "
                                + " where tblForum.Forum_name like '%"+strSearch+"%' "
                                + " ORDER BY tblCategory.Cat_order, tblForum.Forum_Order DESC;  ";

            List<ClsForum> lstSqlForum = new List<ClsForum>();

            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();
                while (Reader.Read())
                {
                    ClsForum clsForum = new ClsForum();

                    clsForum.ForumID = Convert.ToInt32(Reader["Forum_ID"]);
                    clsForum.Formname = Convert.ToString(Reader["Forum_name"]);
                    clsForum.Formumdescription = Convert.ToString(Reader["Forum_description"]);
                    clsForum.NoOfTopics = Convert.ToInt32(Reader["No_of_topics"]);
                    clsForum.NoOfPosts = Convert.ToInt32(Reader["No_of_posts"]);
                    clsForum.LastPostDate = Convert.IsDBNull((Reader["Last_post_date"])) ? default(DateTime) : Convert.ToDateTime(Reader["Last_post_date"]);
                    clsForum.strLastPostDate = DateFormate.PostDate(clsForum.LastPostDate);


                    ClsCategory category = new ClsCategory();

                    category.CatID = Convert.ToInt32(Reader["Cat_ID"]);
                    category.CatName = Convert.ToString(Reader["Cat_name"]);

                    clsForum.Category = category;

                    clsRegistration Auther = new clsRegistration();

                    Auther.Username = Convert.ToString(Reader["Username"]);
                    Auther.AuthorID = Convert.ToInt32(Reader["Last_post_author_ID"]);

                    clsForum.Auther = Auther;

                    ClsTopics topic = new ClsTopics();
                    topic.Subject = Convert.ToString(Reader["Subject"]);
                    topic.TopicID = Convert.ToInt32(Reader["Last_topic_ID"]);

                    clsForum.Topics = topic;


                    lstSqlForum.Add(clsForum);
                }
            }

            return lstSqlForum;

        }
        public List<ClsTopics> GetForumTopics(int ForumID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            
            string SqlQuery = "SELECT  tblTopic.Topic_ID, tblTopic.Poll_ID, tblTopic.Moved_ID, tblTopic.Subject, tblTopic.Icon, tblTopic.Start_Thread_ID,"
                              + " tblTopic.Last_Thread_ID, tblTopic.No_of_replies, tblTopic.No_of_views,tblTopic.Event_date, tblTopic.Event_date_end,"
                              +" tblTopic.Rating, tblTopic.Rating_Votes ,Forum_Name,Forum_description,(Select USERNAME FROM tblAuthor Where AUTHOR_ID = (Select Author_ID From "
                              + " tblThread Where Thread_ID = tblTopic.Start_Thread_ID)) AS CreatedBy, (Select Author_ID FROM tblAuthor Where AUTHOR_ID = (Select Author_ID From "
                              + " tblThread Where Thread_ID = tblTopic.Start_Thread_ID)) AS CreatedByID,(Select USERNAME FROM tblAuthor Where AUTHOR_ID = "
                              + " (Select Author_ID From tblThread Where Thread_ID = tblTopic.Last_Thread_ID)) AS LastPostBy,(Select Author_ID FROM tblAuthor Where AUTHOR_ID = "
                              + " (Select Author_ID From tblThread Where Thread_ID = tblTopic.Last_Thread_ID)) AS LastPostByID FROM tblTopic INNER JOIN tblForum ON "
                              +" tblForum.Forum_ID = tblTopic.Forum_ID Where tblTopic.Forum_ID =" + ForumID;
            
            List<ClsTopics> lstSqlTopic = new List<ClsTopics>();
          //  List<ClsForum> lstForum = new List<ClsForum>();
            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();
                
                while (Reader.Read())
                {
                    ClsTopics clsTopic = new ClsTopics();
                    ClsForum clsForum = new ClsForum();

                    clsTopic.TopicID = Convert.ToInt32(Reader["Topic_ID"]);
                    clsTopic.Subject = Convert.ToString(Reader["Subject"]);
                    clsTopic.Noofreplies = Convert.ToInt32(Reader["No_of_replies"]);
                    clsTopic.Noofviews = Convert.ToInt32(Reader["No_of_views"]);
                    clsTopic.StartThreadCreatedBy = Convert.ToString(Reader["CreatedBy"]);
                    clsTopic.LastThreadCreatedBy = Convert.ToString(Reader["LastPostBy"]);
                    clsTopic.StartThreadID = Convert.ToInt32(Reader["Start_Thread_ID"]);
                    clsTopic.LastThreadID = Convert.ToInt32(Reader["Last_Thread_ID"]);
                    clsTopic.StartThreadCreatedByID = Convert.ToInt32(Reader["CreatedByID"]);
                    clsTopic.LastThreadCreatedByID = Convert.ToInt32(Reader["LastPostByID"]);

                    clsForum.Formumdescription = Convert.ToString(Reader["Forum_description"]);
                    clsTopic.Forum = clsForum;
                    
                    lstSqlTopic.Add(clsTopic);
                }
            }

            return lstSqlTopic;

        }

        public List<ClsTopics> GetForumTopicsSearch(int ForumID,string strForumTopicSearch)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();

            string SqlQuery = "SELECT  tblTopic.Topic_ID, tblTopic.Poll_ID, tblTopic.Moved_ID, tblTopic.Subject, tblTopic.Icon, tblTopic.Start_Thread_ID,"
                              + " tblTopic.Last_Thread_ID, tblTopic.No_of_replies, tblTopic.No_of_views,tblTopic.Event_date, tblTopic.Event_date_end,"
                              + " tblTopic.Rating, tblTopic.Rating_Votes ,Forum_Name,Forum_description,(Select USERNAME FROM tblAuthor Where AUTHOR_ID = (Select Author_ID From "
                              + " tblThread Where Thread_ID = tblTopic.Start_Thread_ID)) AS CreatedBy, (Select Author_ID FROM tblAuthor Where AUTHOR_ID = (Select Author_ID From "
                              + " tblThread Where Thread_ID = tblTopic.Start_Thread_ID)) AS CreatedByID,(Select USERNAME FROM tblAuthor Where AUTHOR_ID = "
                              + " (Select Author_ID From tblThread Where Thread_ID = tblTopic.Last_Thread_ID)) AS LastPostBy,(Select Author_ID FROM tblAuthor Where AUTHOR_ID = "
                              + " (Select Author_ID From tblThread Where Thread_ID = tblTopic.Last_Thread_ID)) AS LastPostByID FROM tblTopic INNER JOIN tblForum ON "
                              + " tblForum.Forum_ID = tblTopic.Forum_ID Where tblTopic.Subject like '%" + strForumTopicSearch + "%' and tblTopic.Forum_ID =" + ForumID;

            List<ClsTopics> lstSqlTopic = new List<ClsTopics>();
            //  List<ClsForum> lstForum = new List<ClsForum>();
            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();

                while (Reader.Read())
                {
                    ClsTopics clsTopic = new ClsTopics();
                    ClsForum clsForum = new ClsForum();

                    clsTopic.TopicID = Convert.ToInt32(Reader["Topic_ID"]);
                    clsTopic.Subject = Convert.ToString(Reader["Subject"]);
                    clsTopic.Noofreplies = Convert.ToInt32(Reader["No_of_replies"]);
                    clsTopic.Noofviews = Convert.ToInt32(Reader["No_of_views"]);
                    clsTopic.StartThreadCreatedBy = Convert.ToString(Reader["CreatedBy"]);
                    clsTopic.LastThreadCreatedBy = Convert.ToString(Reader["LastPostBy"]);
                    clsTopic.StartThreadID = Convert.ToInt32(Reader["Start_Thread_ID"]);
                    clsTopic.LastThreadID = Convert.ToInt32(Reader["Last_Thread_ID"]);
                    clsTopic.StartThreadCreatedByID = Convert.ToInt32(Reader["CreatedByID"]);
                    clsTopic.LastThreadCreatedByID = Convert.ToInt32(Reader["LastPostByID"]);

                    clsForum.Formumdescription = Convert.ToString(Reader["Forum_description"]);
                    clsTopic.Forum = clsForum;

                    lstSqlTopic.Add(clsTopic);
                }
            }

            return lstSqlTopic;

        }

        public List<ClsThread> GetForumPost(int TopicID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();

            string SqlQuery = "SELECT tblThread.Thread_ID,tblThread.Message, tblThread.Message_date,tblThread.Thanks,tblAuthor.Author_ID, "
                             + " tblAuthor.Username, tblAuthor.Location,tblAuthor.No_of_posts,tblAuthor.Points,tblAuthor.Join_date,tblAuthor.Signature, "
                             + " ISNULL(tblAuthor.Avatar,'avatars/butterfly2.jpg') As Avatar,tblAuthor.Avatar_title, ROW_NUMBER() OVER (ORDER BY tblThread.Message_date ASC) AS RowNum,tblTopic.subject FROM tblAuthor "
                             + "  tblAuthor INNER JOIN  tblThread ON tblAuthor.Author_ID = tblThread.Author_ID INNER JOIN tblTopic ON tblThread.Topic_ID = tblTopic.Topic_ID "
                             + "  WHERE tblThread.Topic_ID =" + TopicID;  

            List<ClsThread> lstThread = new List<ClsThread>();
         
            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();

                while (Reader.Read())
                {
                    ClsThread thread = new ClsThread();

                    thread.Thread_ID = Convert.ToInt32(Reader["Thread_ID"]);
                    thread.Message = Convert.ToString(Reader["Message"]);
                    thread.Message_date = Convert.ToDateTime(Reader["Message_date"]);
                    thread.strMessageDate = DateFormate.PostDate(thread.Message_date);
                   
                    thread.Thanks = Convert.ToInt32(Reader["Thanks"]);
                    thread.Topic_ID = TopicID;

                    clsRegistration auther = new clsRegistration();

                    auther.AuthorID = Convert.ToInt32(Reader["Author_ID"]);
                    auther.Username = Convert.ToString(Reader["Username"]);
                    auther.Location = string.IsNullOrEmpty(Convert.ToString(Reader["Location"])) ? "N/A" : Convert.ToString(Reader["Location"]);
                    auther.Noofposts = Convert.ToInt32(Reader["No_of_posts"]);
                    auther.Points = Convert.ToInt32(Reader["Points"]);
                    auther.Joindate = Convert.ToDateTime(Reader["Join_date"]);
                    auther.Avatar = Convert.ToString(Reader["Avatar"]);
                    
                    thread.Auther = auther;

                    ClsTopics topic = new ClsTopics();
                    topic.Subject = Convert.ToInt32(Reader["RowNum"]) != 1 ? "Re: " + Convert.ToString(Reader["subject"]) : Convert.ToString(Reader["subject"]);
                    topic.RowNum = Convert.ToInt32(Reader["RowNum"]);

                    thread.Topic = topic;

                    lstThread.Add(thread);
                }
            }

            return lstThread;

        }

        public List<ClsThread> GetForumPostSearch(int TopicID,string strForumPostSearch)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();

            string SqlQuery = "SELECT tblThread.Thread_ID,tblThread.Message, tblThread.Message_date,tblThread.Thanks,tblAuthor.Author_ID, "
                             + " tblAuthor.Username, tblAuthor.Location,tblAuthor.No_of_posts,tblAuthor.Points,tblAuthor.Join_date,tblAuthor.Signature, "
                             + " ISNULL(tblAuthor.Avatar,'avatars/butterfly2.jpg') As Avatar,tblAuthor.Avatar_title, ROW_NUMBER() OVER (ORDER BY tblThread.Message_date ASC) AS RowNum,tblTopic.subject FROM tblAuthor "
                             + "  tblAuthor INNER JOIN  tblThread ON tblAuthor.Author_ID = tblThread.Author_ID INNER JOIN tblTopic ON tblThread.Topic_ID = tblTopic.Topic_ID "
                             + "  WHERE tblThread.Message like '%" + strForumPostSearch + "%' and tblThread.Topic_ID =" + TopicID;

            List<ClsThread> lstThread = new List<ClsThread>();

            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();

                while (Reader.Read())
                {
                    ClsThread thread = new ClsThread();

                    thread.Thread_ID = Convert.ToInt32(Reader["Thread_ID"]);
                    thread.Message = Convert.ToString(Reader["Message"]);
                    thread.Message_date = Convert.ToDateTime(Reader["Message_date"]);
                    thread.strMessageDate = DateFormate.PostDate(thread.Message_date);

                    thread.Thanks = Convert.ToInt32(Reader["Thanks"]);
                    thread.Topic_ID = TopicID;

                    clsRegistration auther = new clsRegistration();

                    auther.AuthorID = Convert.ToInt32(Reader["Author_ID"]);
                    auther.Username = Convert.ToString(Reader["Username"]);
                    auther.Location = string.IsNullOrEmpty(Convert.ToString(Reader["Location"])) ? "N/A" : Convert.ToString(Reader["Location"]);
                    auther.Noofposts = Convert.ToInt32(Reader["No_of_posts"]);
                    auther.Points = Convert.ToInt32(Reader["Points"]);
                    auther.Joindate = Convert.ToDateTime(Reader["Join_date"]);
                    auther.Avatar = Convert.ToString(Reader["Avatar"]);

                    thread.Auther = auther;

                    ClsTopics topic = new ClsTopics();
                    topic.Subject = Convert.ToInt32(Reader["RowNum"]) != 1 ? "Re: " + Convert.ToString(Reader["subject"]) : Convert.ToString(Reader["subject"]);
                    topic.RowNum = Convert.ToInt32(Reader["RowNum"]);

                    thread.Topic = topic;

                    lstThread.Add(thread);
                }
            }

            return lstThread;

        }
         public List<ClsTopics> GetMyTopics(int AutherID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();

            string SqlQuery = " SELECT tblForum.Forum_ID,tblForum.Forum_name, tblTopic.Subject, tblTopic.No_of_replies, tblTopic.No_of_views, tblTopic.Last_Thread_ID,"
                              + " tblAuthor.Author_ID,(Select USERNAME FROM tblAuthor Where AUTHOR_ID = (Select Author_ID From tblThread Where Thread_ID = tblTopic.Last_Thread_ID)) AS LastPostBy, "
                              + " (Select Author_ID FROM tblAuthor Where AUTHOR_ID = (Select Author_ID From tblThread Where Thread_ID = tblTopic.Last_Thread_ID)) AS LastPostByID, (Select Author_ID FROM tblAuthor Where AUTHOR_ID = "
                              + " (Select Author_ID From tblThread Where Thread_ID = tblTopic.Start_Thread_ID)) AS StartPostByID,tblThread.Thanks, "
                              + " tblTopic.Topic_ID FROM tblTopic INNER JOIN tblThread ON tblTopic.Topic_ID = tblThread.Topic_ID INNER JOIN tblAuthor ON "
                              + " tblThread.Author_ID = tblAuthor.Author_ID INNER JOIN tblForum ON tblTopic.Forum_ID = tblForum.Forum_ID Where tblAuthor.Author_ID =" + AutherID;
            
            List<ClsTopics> lstSqlTopic = new List<ClsTopics>();
          //  List<ClsForum> lstForum = new List<ClsForum>();
            using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                SqlCom.CommandType = CommandType.Text;
                SqlDataReader Reader = SqlCom.ExecuteReader();
                
                while (Reader.Read())
                {
                    ClsTopics clsTopic = new ClsTopics();
                    ClsForum clsForum = new ClsForum();
                    ClsThread thread = new ClsThread();

                    clsTopic.TopicID = Convert.ToInt32(Reader["Topic_ID"]);
                    clsTopic.Subject = Convert.ToString(Reader["Subject"]);
                    clsTopic.Noofreplies = Convert.ToInt32(Reader["No_of_replies"]);
                    clsTopic.Noofviews = Convert.ToInt32(Reader["No_of_views"]);
                    clsTopic.LastThreadID = Convert.ToInt32(Reader["Last_Thread_ID"]);
                    clsTopic.LastThreadCreatedByID = Convert.ToInt32(Reader["LastPostByID"]);
                    clsTopic.LastThreadCreatedBy = Convert.ToString(Reader["LastPostBy"]);
                    clsTopic.StartThreadCreatedByID = Convert.ToInt32(Reader["StartPostByID"]);
                    clsForum.Formname = Convert.ToString(Reader["Forum_name"]);
                    clsForum.ForumID = Convert.ToInt32(Reader["Forum_ID"]);
                    thread.Thanks = Convert.ToInt32(Reader["Thanks"]);
                    
                   
                    clsTopic.Forum = clsForum;
                    clsTopic.Thread = thread;

                  //  clsForum.Formname = Convert.ToString(Reader["Forum_Name"]);
                  //  clsTopic.Forum.Add(clsForum);

                    lstSqlTopic.Add(clsTopic);
                }
            }

            return lstSqlTopic;

        }

         public List<ClsTopics> GetAutherRecentTopics(int AutherID)
         {
             SqlConnection SqlConn = new SqlConnection();
             SqlConn.ConnectionString = GetConnectionString();

             string SqlQuery = " SELECT TOP (5) tblTopic.Topic_ID, tblTopic.Subject, tblThread.Author_ID, tblThread.Message, tblThread.Message_date,"
                               + " tblTopic.Start_Thread_ID, tblThread.Thread_ID FROM tblTopic INNER JOIN tblThread ON tblTopic.Topic_ID = tblThread.Topic_ID"
                               + " WHERE     (tblThread.Author_ID = " + AutherID + ") ORDER BY tblThread.Message_date DESC";

             List<ClsTopics> lstSqlTopic = new List<ClsTopics>();
             //  List<ClsForum> lstForum = new List<ClsForum>();
             using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
             {
                 SqlConn.Open();
                 SqlCom.CommandType = CommandType.Text;
                 SqlDataReader Reader = SqlCom.ExecuteReader();

                 while (Reader.Read())
                 {
                     ClsTopics clsTopic = new ClsTopics();
                     ClsForum clsForum = new ClsForum();
                     ClsThread thread = new ClsThread();

                     clsTopic.TopicID = Convert.ToInt32(Reader["Topic_ID"]);
                     clsTopic.Subject = Convert.ToString(Reader["Subject"]).Trim();
                     clsTopic.StartThreadID = Convert.ToInt32(Reader["Start_Thread_ID"]);
                     string message = RemoveHTML.StripTagsRegex(Convert.ToString(Reader["Message"]).Trim());
                     if (message.Length > 500)
                     {
                         thread.Message = message.Substring(0, 200);
                     }
                     else
                     {
                         thread.Message = message;
                     }
                     thread.Message_date = Convert.ToDateTime(Reader["Message_date"]);
                     thread.strMessageDate = DateFormate.PostDate(thread.Message_date);
                     thread.Thread_ID = Convert.ToInt32(Reader["Thread_ID"]);
                    
                     clsTopic.Thread = thread;

                     //  clsForum.Formname = Convert.ToString(Reader["Forum_Name"]);
                     //  clsTopic.Forum.Add(clsForum);

                     lstSqlTopic.Add(clsTopic);
                 }
             }

             return lstSqlTopic;

         }

         public List<clsCountry> getCountry()
         {
             SqlConnection SqlConn = new SqlConnection();
             SqlConn.ConnectionString = GetConnectionString();
             List<clsCountry> lstCountry = new List<clsCountry>();

             string SqlQuery = "Select ID,NameEN From Countries";

             using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
             {
                 try
                 {
                     SqlConn.Open();
                     SqlCom.CommandType = CommandType.Text;
                     SqlDataReader Reader = SqlCom.ExecuteReader();
                     while (Reader.Read())
                     {
                         clsCountry country = new clsCountry();
                         country.ID = Convert.ToInt32(Reader["ID"]);
                         country.NameEN = Convert.ToString(Reader["NameEN"]);
                         lstCountry.Add(country);
                     }
                     SqlConn.Close();
                 }
                 catch
                 {
                 }
             }
             return lstCountry;

         }

         public List<System.Web.UI.WebControls.ListItem> PopulatePager(int recordCount, int currentPage)
         {
             double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(10));
             int pageCount = (int)Math.Ceiling(dblPageCount);
             List<System.Web.UI.WebControls.ListItem> pages = new List<System.Web.UI.WebControls.ListItem>();
             if (pageCount > 0)
             {
                 for (int i = 1; i <= pageCount; i++)
                 {
                     pages.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString(), i != currentPage));
                 }
             }
             return pages;
         }
    }
}
