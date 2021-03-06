//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace Cef3
{
    using System;

    using Cef3.Interop;
    
    // Role: PROXY
    public sealed unsafe partial class CefDomNode : IDisposable
    {
        internal static CefDomNode FromNative(cef_domnode_t* ptr)
        {
            return new CefDomNode(ptr);
        }
        
        internal static CefDomNode FromNativeOrNull(cef_domnode_t* ptr)
        {
            if (ptr == null) return null;
            return new CefDomNode(ptr);
        }
        
        private cef_domnode_t* _self;
        
        private CefDomNode(cef_domnode_t* ptr)
        {
            if (ptr == null) throw new ArgumentNullException("ptr");
            _self = ptr;
        }
        
        ~CefDomNode()
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
            return cef_domnode_t.add_ref(_self);
        }
        
        internal int Release()
        {
            try
            {
                return cef_domnode_t.release(_self);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        
        internal int RefCt
        {
            get { return cef_domnode_t.get_refct(_self); }
        }
        
        internal cef_domnode_t* ToNative()
        {
            AddRef();
            return _self;
        }
    }
}
