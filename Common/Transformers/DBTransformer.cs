using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Transformers
{
    public static class DBTransformer
    {
        public static int GetOrDefault(object row, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(row);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string GetOrDefault(object row, string defaultValue)
        {
            try
            {
                return Convert.ToString(row);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
