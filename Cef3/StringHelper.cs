namespace Cef3
{
    using System.Linq;

    internal static class StringHelper
    {
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value == null)
            {
                return true;
            }
            return value.All(t => char.IsWhiteSpace(t));
        }
    }
}
