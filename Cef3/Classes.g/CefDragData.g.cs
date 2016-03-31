//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace Cef3
{
    using System;

    using Cef3.Interop;
    
    // Role: PROXY
    public sealed unsafe partial class CefDragData : IDisposable
    {
        internal static CefDragData FromNative(cef_drag_data_t* ptr)
        {
            return new CefDragData(ptr);
        }
        
        internal static CefDragData FromNativeOrNull(cef_drag_data_t* ptr)
        {
            if (ptr == null) return null;
            return new CefDragData(ptr);
        }
        
        private cef_drag_data_t* _self;
        
        private CefDragData(cef_drag_data_t* ptr)
        {
            if (ptr == null) throw new ArgumentNullException("ptr");
            _self = ptr;
        }
        
        ~CefDragData()
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
            return cef_drag_data_t.add_ref(_self);
        }
        
        internal int Release()
        {
            return cef_drag_data_t.release(_self);
        }
        
        internal int RefCt
        {
            get { return cef_drag_data_t.get_refct(_self); }
        }
        
        internal cef_drag_data_t* ToNative()
        {
            AddRef();
            return _self;
        }
    }
}