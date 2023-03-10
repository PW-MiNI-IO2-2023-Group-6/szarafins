using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2023Gr6
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            if(String.IsNullOrEmpty(str)) 
                return 0;

            char? customSeparator = str.StartsWith("//") && str[3] == '\n' 
                ? str[2] 
                : null;

            var split = customSeparator is null 
                ? str.Split(',','|','\n') 
                : str[4..].Split(',','|','\n', customSeparator.Value);

            int sum = 0;
            foreach(string s in split)
            {
                if (int.TryParse(s, out var parsedStr))
                {
                    if (parsedStr < 0)
                        throw new ArgumentException();

                    if (parsedStr <= 1000)
                        sum += parsedStr;
                }
                else return 0;
            }
            return sum;

        }
    }
}
