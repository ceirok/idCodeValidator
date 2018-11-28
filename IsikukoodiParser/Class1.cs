using System;
using System.Text.RegularExpressions;

namespace IsikukoodiParser
{
    public class IsikukoodiParser
    {
        private string isikukood { get; set; }
        public IsikukoodiParser(string isikukood)
        {
            this.isikukood = isikukood;
        }

        public bool evaluateIk()
        {
            Regex regex = new Regex("^([1-8]{1})([0-9]{10})$");
            if(validLength(this.isikukood))
            {
                if (regex.IsMatch(this.isikukood))
                {
                    return true;
                }
            }
            return false;
        }

        public string evaluateGender()
        {
            int ikFirstIndex = this.isikukood.ToCharArray()[0];

            if(evaluateIk())
            {
                if (ikFirstIndex % 2 == 0 && ikFirstIndex != 0)
                {
                    return "Female";
                }
                else
                {
                    if (ikFirstIndex != 9 || ikFirstIndex != 0)
                    {
                        return "Male";
                    }
                }
            }
            return null;
        }

        public string evaluateBirthday()
        {
            if(evaluateIk())
            {              
                string year = this.isikukood.Substring(1, 2);
                string month = this.isikukood.Substring(3, 2);
                string day = this.isikukood.Substring(5, 2);

                Regex monthRegex = new Regex("^[0-1][1-9]$");
                Regex dayRegex = new Regex("^[0-3][1-9]$");

                if(monthRegex.IsMatch(month) && dayRegex.IsMatch(day))
                {
                    if(Int32.Parse(month) <= 12 && Int32.Parse(day) <= 31)
                    {
                        return (day + "." + month + "." + year);
                    } else
                    {
                        return null;
                    }
                }                
            }
            return null;
        }

        public bool validLength(string isikukood)
        {
            if(isikukood.Length == 11)
            {
                return true;
            }
            return false;
        }

        public bool checkControlNumber()
        {
            if(evaluateIk())
            {
                char[] charList = this.isikukood.ToCharArray();
                int sum = 0;
                int correctChecksum = 0;

                for(int i = 0; i < charList.Length; i++)
                {
                    if(i < 10)
                    {
                        sum += charList[i] * (i + 1);
                    } else
                    {
                        sum += charList[i] * 1;
                    }
                }

                if(sum % 11 < 10)
                {
                    correctChecksum = sum / 11;
                } else if(sum % 11 == 10)
                {
                   //TODO
                }
            }
            return false;
        }
    }
}
