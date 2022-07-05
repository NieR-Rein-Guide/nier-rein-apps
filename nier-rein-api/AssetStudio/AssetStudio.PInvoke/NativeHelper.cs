using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetStudio.PInvoke
{
    class NativeHelper
    {
        public static GCHandle PinObject(object obj)
        {
            return GCHandle.Alloc(obj, GCHandleType.Pinned);
        }

        public static void FreePinnedObject(GCHandle handle)
        {
            handle.Free();
        }

        public static IntPtr MarshalObject(object obj)
        {
            var objSize = Marshal.SizeOf(obj);
            var ptr = Marshal.AllocHGlobal(objSize);
            Marshal.StructureToPtr(obj, ptr, true);

            return ptr;
        }

        public static void FreeObject(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}
