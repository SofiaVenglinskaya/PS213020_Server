using System;
using System.Collections.Generic;
using System.Text;

namespace PS213020_Server.Shared.Exception
{
    public class NotFoundExceptions : System.Exception
    {
        public NotFoundExceptions(string message): base(message)
        {

        }
    }
}
