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
   public class ClsModifyData
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public void EditForumThread(ClsTopics topic)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlQuery = null;

            SqlQuery = "Update tblThread Set Message ='" + topic.Thread.Message + "' Where Thread_ID =" + topic.Thread.Thread_ID;

            using (SqlCommand SqlCmd = new SqlCommand(SqlQuery,SqlConn))
            {
                SqlConn.Open();
                int i = SqlCmd.ExecuteNonQuery();
               
               
            }

            SqlQuery = "Update tblTopic Set Subject ='" + topic.Subject + "' Where Topic_ID =" + topic.TopicID;

            using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlConn))
            {
                int i = SqlCmd.ExecuteNonQuery();
                SqlConn.Close();
            }

        }

        private string WriteXML(ClsTopics topic)
        {

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootNode = xmlDoc.CreateElement("Root");
            xmlDoc.AppendChild(rootNode);
            XmlElement NewShowRoom = xmlDoc.CreateElement("TOPIC");
            xmlDoc.DocumentElement.PrependChild(NewShowRoom);

            XML.BuildXml(xmlDoc, NewShowRoom, "Forum_ID", topic.ForumID.ToString());
           // if (!string.IsNullOrEmpty(topic.Subject.ToString()))
            XML.BuildXml(xmlDoc, NewShowRoom, "Subject", topic.Subject.ToString());
            XML.BuildXml(xmlDoc, NewShowRoom, "Author_ID", topic.Thread.Author_ID.ToString());
            //XML.BuildXml(xmlDoc, NewShowRoom, "IP_addr", _OwnerFirstName.ToString());
            XML.BuildXml(xmlDoc, NewShowRoom, "Message", topic.Thread.Message.ToString());
            XML.BuildXml(xmlDoc, NewShowRoom, "Topic_ID", topic.TopicID.ToString());
     
            StringWriter objStringWriter = new StringWriter();
            XmlTextWriter objXMLTextWriter = new XmlTextWriter(objStringWriter);
            xmlDoc.WriteTo(objXMLTextWriter);
            return objStringWriter.ToString();
        }
        public void AddNewTopic(ClsTopics topic)
        {

            string _strxml = WriteXML(topic);
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = GetConnectionString();

            using (SqlCommand SqlCmd = new SqlCommand("AddNewTopic",SqlCon))
            {
                SqlCon.Open();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("@XMLDoument", _strxml);
               
                SqlCmd.ExecuteNonQuery();
            }        
        }

        public void AddNewThread(ClsTopics topic)
        {

            string _strxml = WriteXML(topic);
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = GetConnectionString();

            using (SqlCommand SqlCmd = new SqlCommand("AddNewThread", SqlCon))
            {
                SqlCon.Open();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("@XMLDoument", _strxml);
                SqlCmd.ExecuteNonQuery();
            }
        }
        public void UpdateView(Int32 TopicID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlQuery = null;
                
            SqlQuery = "Update tblTopic Set No_Of_Views = (Select No_Of_Views +1 From tblTopic Where Topic_ID ="+TopicID+") Where Topic_ID ="+TopicID;

            using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                int i = SqlCmd.ExecuteNonQuery();
                SqlConn.Close();
            }

        }

        public void UpdateMarkedAsAnswer(Int32 ThreadID)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlQuery = null;

       

            SqlQuery = "Update tblThread Set Thanks = 1 Where Thread_ID =" + ThreadID;
            using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                int i = SqlCmd.ExecuteNonQuery();
                SqlConn.Close();
            }

            SqlQuery = "Update tblAuthor Set points = points +10 Where Author_ID = (Select Author_ID From tblThread where Thread_ID =" + ThreadID+")"; 

            using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                int i = SqlCmd.ExecuteNonQuery();
                SqlConn.Close();
            }

        }
        public void alertModeraor(clsAlertModerator alertModerator)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlQuery = null;

            SqlQuery = "INSERT INTO tblAlertModerator (Type,Reason,ThreadID,ReportedByID) VALUES('"+ alertModerator.Type.ToString()+"','"+alertModerator.Reason.Trim().ToString()+"',"+alertModerator.ThreadID+","+alertModerator.ReportedByID+")";

            using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlConn))
            {
                SqlConn.Open();
                int i = SqlCmd.ExecuteNonQuery();
                SqlConn.Close();
            }

        }
    }
}
