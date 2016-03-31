namespace Cef3
{
    public sealed class CefVersionMismatchException : CefRuntimeException
    {
        public CefVersionMismatchException(string message)
            : base(message)
        {
        }
    }
}
