using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace ASM2
{
    class DataType
    {
        public static bool CheckID(string id,string str)
        {
            if (str == "Student")
            {
                if ((Regex.IsMatch(id, @"^GT\d{5}$")) || (Regex.IsMatch(id, @"^GC\d{5}$"))) //Bieu thuc chinh quy
                {
                    return true;
                }
                return false;
            }
            else
            {
                return Regex.IsMatch(id, @"^\d{8}$");
            }
            
        }
        public static bool Email(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static string InputValue(string oldvalue,string input)
        {
            if (input == "")
            {
                return oldvalue;
            }
            else
            {
                return input;
            }
        }
        public static DateTime InputDate(string input, DateTime oldvalue)
        {
            if (input == "")
            {
                return oldvalue;
            }
            else
            {
                return Convert.ToDateTime(input);
            }
        }
        //public static string InputEmail(string input, string oldvalue)
        //{
        //    if (input == "")
        //    {
        //        return oldvalue;
        //    }
        //    else
        //    {
        //        if (DataType.Email(input))
        //        {
        //            return input;
        //        }
        //        else
        //        {
        //            return oldvalue;
        //        }
        //    }
        //}
        public static bool CheckExists(string id, List<Person> list)
        {
            foreach(var per in list)
            {
                if ((per.id == id)||per.SearchName(id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
