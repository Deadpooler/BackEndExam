using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Exceptions
{
    public class CustomException:Exception
    {
        public CustomException()
        {

        }
        public CustomException(String message):base(String.Format("Exception Found: {0}", message))
        {
           
        }
        public CustomException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}