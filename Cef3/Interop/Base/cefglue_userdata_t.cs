namespace Cef3.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = libcef.ALIGN)]
    internal unsafe partial struct cefglue_userdata_t
    {
        internal cef_base_t _base;
    }
}
