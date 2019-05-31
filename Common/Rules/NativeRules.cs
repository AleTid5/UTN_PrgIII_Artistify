using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Rules
{
    public static class NativeRules
    {
        public static String CheckString(String stringToCheck, String message, int minLength = int.MinValue, int maxLength = int.MaxValue)
        {
            try
            {
                if (stringToCheck.Length < minLength ||
                    stringToCheck.Length > maxLength)
                {
                    throw new Exception(message);
                }

                return stringToCheck;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
