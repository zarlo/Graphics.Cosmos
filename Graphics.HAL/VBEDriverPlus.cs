using System;
using Cosmos.Core;
using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers;

namespace Graphics.HAL
{
    public class VBEDriverPlus: VBEDriver
    {
        public static bool IsAvailable() {
            return VBE.IsAvailable();
        }
        private static readonly VBEIOGroup IO = Cosmos.Core.Global.BaseIOGroups.VBE;
        public VBEDriverPlus(ushort xres, ushort yres, ushort bpp) : base(xres, yres, bpp) {
            
        }

        public void BufferLessCopyVRAM(int aStart, byte[] aData, int aIndex, int aCount) 
        {
            IO.LinearFrameBuffer.Copy(aStart, aData, aIndex, aCount);
        }

        public void BufferLessCopyVRAM(int aStart, int[] aData, int aIndex, int aCount) 
        {
            IO.LinearFrameBuffer.Copy(aStart, aData, aIndex, aCount);
        }

    }
}
