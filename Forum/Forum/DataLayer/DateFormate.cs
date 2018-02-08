using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
 public  class  DateFormate
    {
    
       public static string PostDate(DateTime now)
       {
             int intDay = 0;		//Holds the integer number for the day
	        int intMonth = 0;		//'Holds a integer number from 1 to 12 for the month
	        int intYear = 0;		//'Holds the year
	        DateTime dtmNow;		//'Holds the present date
	         int intHour = 0;	//	'Holds the integer number for the hours
	        int intMinute = 0;//		'Holds a integer number for the mintes
            string finishedDate = "0";
	
	
	        //'If the array is empty set the date as server default
            if (now == default(DateTime))
            {
                finishedDate = "No Post Yet";
            }
            else
            {

                //'Get the date now from the server
                dtmNow = DateTime.Now;
             
                intDay = now.Day;
                intMonth = now.Month;

                intYear = now.Year;
                intHour = now.Hour;
                intMinute = now.Minute;
                if (dtmNow.Subtract(now).TotalHours < 24)
                {
                    if (dtmNow.Subtract(now).TotalMinutes < 60)
                    {
                        if (dtmNow.Subtract(now).TotalSeconds < 60)
                        {
                            finishedDate = "<Strong>Just Now</strong>";

                        }
                        else
                        {

                            finishedDate = "<strong>" + Convert.ToInt32(dtmNow.Subtract(now).TotalMinutes).ToString() + " minutes </strong> ago at " + now.ToShortTimeString();
                        }
                    }
                    else
                    {
                        finishedDate = "<strong>" + Convert.ToInt32(dtmNow.Subtract(now).TotalHours).ToString() + " hour " + Convert.ToInt32(dtmNow.Subtract(now).TotalMinutes % 60).ToString() + " minutes</strong>  ago at " + now.ToShortTimeString();

                    }

                }
                else
                {
                    finishedDate = now.ToString("MMM d, yyyy") + " at " + now.ToShortTimeString();
                }

                   


                    


            }


            return finishedDate;

       }
  }
}
