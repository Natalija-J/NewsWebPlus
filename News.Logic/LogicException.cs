using System;
using System.Collections.Generic;
using System.Text;

namespace News.Logic
{
    public class LogicException : Exception
    {
        public LogicException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
