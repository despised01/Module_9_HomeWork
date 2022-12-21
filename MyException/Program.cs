using System;

namespace Task1
{
    class MyException: Exception
    {
        public MyException(string message) : base(message) { }
    }
}
