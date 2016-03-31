using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cef3;

namespace Sashulin.common
{
    class CwbJsExtendHandler : CefV8Handler
    {
        CefBrowser activeBrowser;

        private log4net.ILog log;
        public CwbJsExtendHandler(CefBrowser browser)
        {
            activeBrowser = browser;
            log = log4net.LogManager.GetLogger(this.GetType());
        }
        protected override bool Execute(string name, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            log.Debug(string.Format("调用{0}方法",name));
            exception = null;
            if (name == "CallCSharpMethod")
            {
                if (arguments == null || arguments.Length == 0)
                {
                    returnValue = null;
                    return false;
                }
                string methodName = arguments[0].GetStringValue();

                List<object> list = new List<object>();
                if (arguments.Length > 1)
                {
                    for (int i = 1; i < arguments.Length; i++)
                    {
                        var value = arguments[i];
                        if (value.IsInt)
                        {
                            list.Add(value.GetIntValue());
                        }
                        else if (value.IsDouble)
                        {
                            list.Add(value.GetDoubleValue());
                        }
                        else if (value.IsString)
                        {
                            list.Add(value.GetStringValue());
                        }
                        else if (value.IsBool)
                        {
                            list.Add(value.GetBoolValue());
                        }
                        else if (value.IsUndefined)
                        {
                            list.Add(0);
                        }else if (value.IsArray)
                        {
                            
                        }
                    }
                }
                string res = Global.CallMethod(activeBrowser, methodName, list.ToArray());
                returnValue = CefV8Value.CreateString(res);
                return true;
            }
            else
            {
                List<object> list = new List<object>();
                if (arguments.Length > 0)
                {
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        var value = arguments[i];
                        if (value.IsInt)
                        {
                            list.Add(value.GetIntValue());
                        }
                        else if (value.IsDouble)
                        {
                            list.Add(value.GetDoubleValue());
                        }
                        else if (value.IsString)
                        {
                            list.Add(value.GetStringValue());
                        }
                        else if (value.IsBool)
                        {
                            list.Add(value.GetBoolValue());
                        }
                        else if (value.IsNull)
                        {
                            list.Add(null);
                        }
                        else if (value.IsUndefined)
                        {
                            list.Add(0);
                        }
                    }
                }
                string res = Global.CallMethod(activeBrowser, name, list.ToArray());
                returnValue = CefV8Value.CreateString(res);
                return true;
            } 
        }
    }
}
