using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Cef3;
using Sashulin.common;
using Sashulin.Core;
namespace Sashulin
{
    internal class Global
    {
        internal static List<ChromeWebBrowser> BrowserList = new List<ChromeWebBrowser>();
        internal static Dictionary<int, CwbElement> RootList = new Dictionary<int,CwbElement>();
        internal static ClientApp app;
        internal static ChromeWebBrowser instance;
        internal static string Result;
        internal static bool flag;
        internal static object JsEvaResult;

        private static log4net.ILog _log;
        static Global()
        {
            _log = log4net.LogManager.GetLogger(typeof(Global));
        }

        const string ERROR_CALL_NOTFOUND = "error: this method can not be found.";
        const string ERROR_CALL_PARAMETER = "error: parameter is incorrect";

        internal static string CallMethod(CefBrowser browser, string methodName, object[] paramValues)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                return null;
            }
            Type t = null;
            object form = null;
            ChromeWebBrowser webBrowser = null;
            foreach (ChromeWebBrowser c in BrowserList)
            {
                if (c == null) continue;
                if (c.browser.Identifier == browser.Identifier)
                {
                    if (c.FindForm() != null)
                    {
                        t = c.FindForm().GetType();
                        form = c.FindForm();
                    }
                    else if (c.Parent != null)
                    {
                        t = c.Parent.GetType();
                        form = c.Parent;
                    }
                    webBrowser = c;
                    break;
                }
            }

            if (t == null)
            {
                SystemLog.WriteLine(methodName + ":" + ERROR_CALL_NOTFOUND);
                _log.Warn(methodName + ":" + ERROR_CALL_NOTFOUND);
                return ERROR_CALL_NOTFOUND;
            }

            MethodInfo m = t.GetMethod(methodName);
            if (m == null)
            {
                if (webBrowser.RegistObject != null)
                {
                    m = webBrowser.RegistObject.GetType().GetMethod(methodName);
                    form = webBrowser.RegistObject;
                }
                if (m == null)
                {
                    SystemLog.WriteLine(methodName + ":" + ERROR_CALL_NOTFOUND);
                    _log.Warn(methodName + ":" + ERROR_CALL_NOTFOUND);
                    return ERROR_CALL_NOTFOUND;
                }
            }
            object[] objArray = paramValues;// null;
            //string[] values = new string[0];
            //if (paramValues != null)
            //    values = paramValues.Split(new char[] { ',' });
            //objArray = new object[values.Length];
            ParameterInfo[] pa = m.GetParameters();

            if (objArray.Length != pa.Length)
            {
                SystemLog.WriteLine(methodName + ":" + ERROR_CALL_PARAMETER);
                _log.Warn(methodName + ":" + ERROR_CALL_PARAMETER);
                return ERROR_CALL_PARAMETER;
            }

            int i = 0;
            foreach (ParameterInfo p in pa)
            {
                switch (p.ParameterType.Name)
                {
                    case "String":
                        objArray[i] =paramValues[i] == null ?  null : paramValues[i].ToString();
                        break;
                    case "Int32":
                        objArray[i] = Int32.Parse(paramValues[i].ToString());
                        break;
                    case "Boolean":
                        objArray[i] = Boolean.Parse(paramValues[i].ToString());
                        break;
                    case "Double":
                        objArray[i] = Double.Parse(paramValues[i].ToString());
                        break;
                }
                i++;
            }
            object o = null;
            try
            {
               o = m.Invoke(form, objArray);
            }
            catch (Exception e)
            {
                _log.Error(e);
            }
            string retVal = string.Empty;
            if (o != null)
                retVal = o.ToString();
            return retVal;
        }
    }

    enum CwbBusinStyle
    {
        bsGetElementValue = 0,
        bsSetElementValue = 1,
        bsAddElementEvent = 2,
        bsVisitDocument = 3,
        bsFocusElement = 4,
        bsAttachElementEvent = 5,
        bsNone = -1
    }

    enum CwbCookieStyle
    {
        csDeleteAllCookie = 0,
        csVisitUrlCookie = 1
    }


}
