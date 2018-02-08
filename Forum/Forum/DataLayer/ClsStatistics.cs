using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
   public static class ClsStatistics
    {
       private static string GetConnectionString()
       {
           return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
       }

       public static int GetNoOfThread()
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlQuery = "Select count(Thread_ID) As Thread From dbo.tblThread";
           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   return (Int32)SqlCom.ExecuteScalar();
               }
               catch
               {
                   return 0;
               }
               finally
               {
                   SqlConn.Close();
               }

           }
            
       }

       public static int GetNoOfPosts()
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlQuery = "Select count(Topic_ID) As Thread From dbo.tblTopic";
           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   return (Int32)SqlCom.ExecuteScalar();
               }
               catch
               {
                   return 0;
               }
               finally
               {
                   SqlConn.Close();
               }

           }

       }

       public static int GetNoOfUsers()
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlQuery = "Select count(Author_ID)As Topic From dbo.tblAuthor";
           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   return (Int32)SqlCom.ExecuteScalar();
               }
               catch
               {
                   return 0;
               }
               finally
               {
                   SqlConn.Close();
               }

           }

       }

       public static int GetUnreadEmail(int autherID)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlQuery = "Select Count(*) from tblPMMessage WHERE tblPMMessage.Author_ID ="+autherID+" and Read_Post = 'False'";
           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   return (Int32)SqlCom.ExecuteScalar();
               }
               catch
               {
                   return 0;
               }
               finally
               {
                   SqlConn.Close();
               }

           }

       }

       public static int getPenddingBuddyRequest(int autherID)
       {
           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlQuery = "SELECT   COUNT(*) FROM tblBuddyList WHere Buddy_id = "+autherID+" AND ISAPPROVED = 'False'" ;
           using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
           {
               try
               {
                   SqlConn.Open();
                   return (Int32)SqlCom.ExecuteScalar();
               }
               catch
               {
                   return 0;
               }
               finally
               {
                   SqlConn.Close();
               }

           }

       }

      //public static string StatusOfBuddy(int authorId, int buddyId)
      //{
      //      SqlConnection SqlConn = new SqlConnection();
      //     SqlConn.ConnectionString = GetConnectionString();
      //     string SqlQuery = "SELECT ISApproved FROM dbo.tblBuddyList  Where Author_ID  = " + authorId + " AND Buddy_id="+buddyId+""
      //                       + "UNION SELECT ISApproved FROM dbo.tblBuddyList WHERE Buddy_id = " + authorId + " and Buddy_id =" + buddyId;
      //     using (SqlCommand SqlCom = new SqlCommand(SqlQuery, SqlConn))
      //     {
      //     }
      //}
      
    }
}
