using System;

namespace Repository.Exceptions
{
    public class CustomException: Exception
    {
        public CustomException(string msg) : base(msg) { }
    }
}
