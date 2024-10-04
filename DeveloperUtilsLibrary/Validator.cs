using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperUtilsLibrary
{
    public class Validator
    {
        /// <summary>
        /// Проверка на верность написания GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isValidGUID(string str)
        {
            string strRegex = @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(str))
                return (true);
            else
                return (false);
        }
    }
}
