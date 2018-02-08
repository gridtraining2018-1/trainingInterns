using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using Entity;


namespace MessageTemplate
{
  public class TokenMessageTemplate
    {
       
       
       private string GetConnectionString()
       {
           return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


       }
    
       string ReplaceTokens(string template, Dictionary<string, string> replacements)
       {
           var rex = new Regex(@"\${([^}]+)}");
           return (rex.Replace(template, delegate(Match m)
           {
               string key = m.Groups[1].Value;
               string rep = replacements.ContainsKey(key) ? replacements[key] : m.Value;
               return (rep);
           }));
       }

     public void SendEmail(ClsMessageTemplate valemail)
       {
           string token;
           Dictionary<string, string> dict = new Dictionary<string, string>();
          switch (valemail.Name)
            {
                case "Registration" :
                    MessageTemplate(ref valemail);
                    int i = 0;
                    foreach (string address in valemail.To)
                    {                     
                        dict.Add("FORUMNAME", "LetsConfirmIT");
                        dict.Add("NAME", valemail.ToUserName[i].ToString());
                        dict.Add("EMAIL", address);
                        dict.Add("UID", valemail.UID);
                        token = ReplaceTokens(valemail.Body, dict);
                        valemail.Body = token;
                        send(ConfigurationManager.AppSettings["FromEmail"].ToString(), address, valemail.Subject, token);
                    }
                    break;
              case "ForgetPassword" :
                        MessageTemplate(ref valemail);
                        dict.Add("FORUMNAME", "LetsConfirmIT");
                        dict.Add("NAME", valemail.ToUserName[0].ToString());
                        dict.Add("EMAIL", valemail.Name);
                        dict.Add("UID", valemail.UID);
                        token = ReplaceTokens(valemail.Body, dict);
                        valemail.Body = token;
                       
                        send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

            }

       }

     private void  MessageTemplate(ref ClsMessageTemplate valemail)
       {

           SqlConnection SqlConn = new SqlConnection();
           SqlConn.ConnectionString = GetConnectionString();
           string SqlString = "SELECT Id, Name, BccEmailAddresses, Subject, Body, IsActive, EmailAccountId, LimitedToStores FROM  MessageTemplate Where Name = '" + valemail.Name + "'";
          
           using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
           {
               SqlConn.Open();
               SqlDataReader reader = SqlCom.ExecuteReader();
               while (reader.Read())
               {
                   try
                   {
                       valemail.Subject = Convert.ToString(reader["Subject"]);
                       valemail.Body = Convert.ToString(reader["Body"]);
                      
                   }
                   catch
                   {
                   }
               }

           }

          
       }

       private void send(string fromAddress, string toAddress, string subject, string body)
        {
           const string fromPassword = "13072005@S";
           
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;   
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
                
            }
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(fromAddress,"ForumTesting");
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = body;
            // Passing values to smtp object
            smtp.Send(mail);
         
        }
    }
}
