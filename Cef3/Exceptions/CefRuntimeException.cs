namespace Cef3
{
    using System;

    public class CefRuntimeException : Exception
    {
        public CefRuntimeException(string message)
            : base(message)
        {
        }
    }
}
