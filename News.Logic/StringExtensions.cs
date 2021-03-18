using System;
using System.Collections.Generic;
using System.Text;

namespace News.Logic
{
    public static class StringExtensions
    {
        public static bool IsPasswordOk(this string text)
        {
            return !String.IsNullOrEmpty(text) && text.Length >= 6;
        }
    }
}
