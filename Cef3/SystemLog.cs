using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cef3
{
    using System.Diagnostics;

    public class SystemLog
    {
        [Conditional("DEBUG")]
        public static void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        [Conditional("DEBUG")]
        public static void WriteLine(string message, params object[] paObjects)
        {
            System.Console.WriteLine(message, paObjects);
        }
    }
}
