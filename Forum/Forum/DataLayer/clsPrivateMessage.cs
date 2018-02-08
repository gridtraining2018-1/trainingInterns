using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using Entity;
using System.Xml;
using System.Collections;
using System.IO;

namespace DataLayer
{
   public class clsPrivateMessage
    {
       public string GetConnectionString()
       {
           return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
       }

       public int sendMessage(SendPM pm)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();

           string SqlQuery = "INSERT INTO tblPMMessage (Author_ID,From_ID,PM_Tittle,PM_Message) VALUES("+pm.Author_ID+","+pm.From_ID+",'"+pm.PM_Tittle+"','"+pm.PM_Message+"')";

           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   SqlCom.CommandType = CommandType.Text;
                   SqlCom.ExecuteNonQuery();
                   SqlConn.Close();
                   return 1;
               }
               catch
               {
                   return 0;
               }
           }
       }

       public List<clsBuddyList> toUserdetail(int FromID, int ToID)
       {
           
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            List<clsBuddyList> lstUserDetails = new List<clsBuddyList>();

            string SqlQuery = " SELECT tblBuddyList.Author_ID, tblBuddyList.Buddy_ID, tblAuthor.Real_name, tblBuddyList.isApproved, tblBuddyList.Block FROM"
                              + " tblAuthor INNER JOIN  tblBuddyList ON tblAuthor.Author_ID = tblBuddyList.Buddy_ID Where tblAuthor.Author_ID = " + ToID;

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
                        clsBuddyList buddlylist = new clsBuddyList();
                        ClsUserDetail.Realname = Convert.ToString(Reader["Real_Name"]);
                        buddlylist.buddy = ClsUserDetail;
                        buddlylist.isApproved = Convert.IsDBNull(Reader["isApproved"]) ? false : Convert.ToBoolean(Reader["isApproved"]);

                        lstUserDetails.Add(buddlylist);
                    }
                    SqlConn.Close();
                }
                catch
                {
                }
            }
            return lstUserDetails;     
       }

       public List<SendPM> inbox(Int32 AuthorID, Int32 startRowIndex, Int32 pageSize)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           List<SendPM> lstUserDetails = new List<SendPM>();

           startRowIndex = Convert.ToInt32(startRowIndex / pageSize) + 1;
           using (SqlCommand SqlCmd = new SqlCommand("getMyPrivateMessage", SqlConn))
           {
               SqlConn.Open();
               SqlCmd.CommandType = CommandType.StoredProcedure;
               SqlCmd.Parameters.AddWithValue("@AuthorID", AuthorID);
               SqlCmd.Parameters.AddWithValue("@startRowIndex", startRowIndex);
               SqlCmd.Parameters.AddWithValue("@maximumRows", pageSize);
               
               SqlDataReader reader = SqlCmd.ExecuteReader();
               while (reader.Read())
               {
                   SendPM inbox = new SendPM();
                   inbox.Author_ID = Convert.ToInt32(reader["Author_ID"]);
                   inbox.strPm_Message_date = DateFormate.PostDate(Convert.ToDateTime(reader["PM_Message_date"]));
                   inbox.PM_Tittle = reader["PM_Tittle"].ToString();
                   inbox.PM_IDuni = reader["PM_IDuni"].ToString();
                   inbox.Read_Post = Convert.ToBoolean(reader["Read_Post"]);
                   clsRegistration fromName = new clsRegistration();
                   fromName.Realname = reader["Real_name"].ToString();

                   inbox.fromAuthor = fromName;
                   lstUserDetails.Add(inbox);
               }
                   
           }

           return lstUserDetails;

       }

       public List<SendPM> inboxSearch(Int32 AuthorID, Int32 startRowIndex, Int32 pageSize,string strSubject)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           List<SendPM> lstUserDetails = new List<SendPM>();

           startRowIndex = Convert.ToInt32(startRowIndex / pageSize) + 1;

           string SqlQuery = " Select Real_name , PM_Tittle, PM_Message_date,Author_ID , PM_ID, PM_IDuni,Read_Post FROM ( "
		                        +" SELECT  ROW_NUMBER() OVER (ORDER BY tblPMMessage.PM_Message_date DESC) AS RowNumber,   tblAuthor.Real_name, tblPMMessage.PM_Tittle, "
		                        +" tblPMMessage.PM_Message_date, tblPMMessage.PM_ID, tblPMMessage.Author_ID,PM_IDuni,tblPMMessage.Read_Post "
                                + " FROM   tblAuthor INNER JOIN  tblPMMessage ON tblAuthor.Author_ID = tblPMMessage.From_ID WHERE tblPMMessage.Author_ID =  '" + AuthorID + "') a "
                                + " WHERE (RowNumber >=  '" + startRowIndex + "' AND RowNumber <= ( '" + startRowIndex + "' +  '" + pageSize + "')) "
                                + " and PM_Tittle like '%" + strSubject + "%'";


           using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlConn))
           {
               SqlConn.Open();
               SqlCmd.CommandType = CommandType.Text;
              

               SqlDataReader reader = SqlCmd.ExecuteReader();
               while (reader.Read())
               {
                   SendPM inbox = new SendPM();
                   inbox.Author_ID = Convert.ToInt32(reader["Author_ID"]);
                   inbox.strPm_Message_date = DateFormate.PostDate(Convert.ToDateTime(reader["PM_Message_date"]));
                   inbox.PM_Tittle = reader["PM_Tittle"].ToString();
                   inbox.PM_IDuni = reader["PM_IDuni"].ToString();
                   inbox.Read_Post = Convert.ToBoolean(reader["Read_Post"]);
                   clsRegistration fromName = new clsRegistration();
                   fromName.Realname = reader["Real_name"].ToString();

                   inbox.fromAuthor = fromName;
                   lstUserDetails.Add(inbox);
               }

           }

           return lstUserDetails;

       }

       public List<SendPM> getPrivateMessage(string MessageID)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           List<SendPM> lstUserDetails = new List<SendPM>();
           string patentID = null;
           do
           {
               string strSql = "Select PM_ID,tblPMMessage.PM_ID, tblPMMessage.Author_ID,tblPMMessage.ParentPM_ID, tblPMMessage.From_ID, tblPMMessage.PM_Tittle, tblPMMessage.PM_Message, "
                               + " tblPMMessage.PM_Message_date, tblPMMessage.PM_IDUni From tblPMMessage Where PM_IDUni = '" + MessageID + "'";
               using (SqlCommand SqlCmd = new SqlCommand(strSql, SqlConn))
               {
                   SqlConn.Open();
                   SqlDataReader reader = SqlCmd.ExecuteReader();
                   while (reader.Read())
                   {
                       SendPM inbox = new SendPM();
                       inbox.Author_ID = Convert.ToInt32(reader["Author_ID"]);
                       inbox.strPm_Message_date = DateFormate.PostDate(Convert.ToDateTime(reader["PM_Message_date"]));
                       inbox.PM_Tittle = reader["PM_Tittle"].ToString();
                       inbox.PM_IDuni = reader["PM_IDuni"].ToString();
                       inbox.PM_Message = reader["PM_Message"].ToString();
                       inbox.From_ID = Convert.ToInt32(reader["From_ID"]);
                       MessageID = patentID = reader["ParentPM_ID"].ToString();

                       lstUserDetails.Add(inbox);
                   }
                   SqlConn.Close();

               }
           } while (!string.IsNullOrEmpty(MessageID));

           return lstUserDetails;

       }

       public int replyMessage(SendPM pm)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();

           string SqlQuery = "INSERT INTO tblPMMessage (Author_ID,From_ID,PM_Tittle,PM_Message,ParentPM_ID) VALUES(" + pm.Author_ID + "," + pm.From_ID + ",'" + pm.PM_Tittle + "','" + pm.PM_Message + "','" + pm.PM_IDuni + "')";

           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   SqlCom.CommandType = CommandType.Text;
                   SqlCom.ExecuteNonQuery();
                   SqlConn.Close();
                   return 1;
               }
               catch
               {
                   return 0;
               }
           }
       }


       public int SaveBuddy(clsBuddyList buddy)
       {

           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlString = "INSERT into tblBuddyList (Author_ID,Buddy_ID) values(" + buddy.Author_ID + "," + buddy.Buddy_ID + ") ";


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

        public void updateUnreadEmail(string MessageID)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlQuery = "update tblPMMessage set Read_Post = 'True' Where PM_IDUni='" + MessageID + "'";
           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   SqlCom.ExecuteNonQuery();
               }
               catch
               {
                   
               }
               finally
               {
                   SqlConn.Close();
               }

           }

       }
    }
}
