using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Generator
{
    public static class PasswordGenerator
    {
        public static string Generate()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            return GuidString.ToString();
        }
    }
}
