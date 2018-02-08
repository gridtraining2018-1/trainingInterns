using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataLayer
{
  public static class RemoveSpecialCharacters
    {
       public static string Remove(string str)
            {
                return Regex.Replace(str, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);
            }

    }
}
