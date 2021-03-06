//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace Cef3
{
    using System;

    using Cef3.Interop;
    
    // Role: PROXY
    public sealed unsafe partial class CefV8Exception : IDisposable
    {
        internal static CefV8Exception FromNative(cef_v8exception_t* ptr)
        {
            return new CefV8Exception(ptr);
        }
        
        internal static CefV8Exception FromNativeOrNull(cef_v8exception_t* ptr)
        {
            if (ptr == null) return null;
            return new CefV8Exception(ptr);
        }
        
        private cef_v8exception_t* _self;
        
        private CefV8Exception(cef_v8exception_t* ptr)
        {
            if (ptr == null) throw new ArgumentNullException("ptr");
            _self = ptr;
        }
        
        ~CefV8Exception()
        {
            if (_self != null)
            {
                Release();
                _self = null;
            }
        }
        
        public void Dispose()
        {
            if (_self != null)
            {
                Release();
                _self = null;
            }
            GC.SuppressFinalize(this);
        }
        
        internal int AddRef()
        {
            return cef_v8exception_t.add_ref(_self);
        }
        
        internal int Release()
        {
            return cef_v8exception_t.release(_self);
        }
        
        internal int RefCt
        {
            get { return cef_v8exception_t.get_refct(_self); }
        }
        
        internal cef_v8exception_t* ToNative()
        {
            AddRef();
            return _self;
        }
    }
}
