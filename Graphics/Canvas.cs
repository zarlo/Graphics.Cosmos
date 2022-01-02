using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using Cosmos.HAL;
using Cosmos.HAL.Drivers;
using Graphics.Backend;
using Backend = Graphics.Backend;
using Graphics.HAL;
namespace Graphics
{
    public class Canvas
    {

        /// <summary>
        /// SVGA 2 device.
        /// </summary>
        private static PCIDevice _SVGAIIDevice = PCI.GetDevice(VendorID.VMWare, DeviceID.SVGAIIAdapter);

        /// <summary>
        /// Checks whether the Bochs Graphics Adapter exists (not limited to Bochs)
        /// </summary>
        /// <returns></returns>
        public static bool BGAExists()
        {
            return VBEDriver.Available();
        }

        /// <summary>
        /// Video driver.
        /// </summary>
        private static ICanvas _VideoDriver = null;

        /// <summary>
        /// Get video driver.
        /// </summary>
        /// <returns>Canvas value.</returns>
        /// <exception cref="sys.ArgumentOutOfRangeException">Thrown if default graphics mode is not suppoted.</exception>
        private static ICanvas GetVideoDriver(Mode mode)
        {
            if (VBEAvailable())
            {
                return new Backend.VBECanvas(mode);
            }
            if (_SVGAIIDevice != null && PCI.Exists(_SVGAIIDevice))
            {
                return null;
            }
            else
            {
                // vga
                return null;
            }
        }

        /// <summary>
        /// Checks is VBE is supported exists
        /// </summary>
        /// <returns></returns>
        private static bool VBEAvailable()
        {
            if (BGAExists())
            {
                return true;
            }
            else if (PCI.Exists(VendorID.VirtualBox, DeviceID.VBVGA))
            {
                return true;
            }
            else if (PCI.Exists(VendorID.Bochs, DeviceID.BGA))
            {
                return true;
            }
            else if (VBEDriverPlus.IsAvailable())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static ICanvas CurrentCanvas;
        public static ICanvas GetCanvas(Mode mode = default) {
            if (CurrentCanvas == null)
            {
                SetCanvas(GetVideoDriver(mode));
            }
            return CurrentCanvas;
        }

        public static bool TryGetCanvas(out ICanvas canvas, Mode mode)
        {
            try
            {
                canvas = GetCanvas(mode);
                return true;
            }
            catch (NotSupportedException)
            {
                canvas = GetCanvas();
                return false;
            }
            catch 
            {
                throw;
            }
        }

        public static void SetCanvas(ICanvas canvas)
        {
            if (CurrentCanvas != null)
            {
                CurrentCanvas.Disable();
            }
            canvas.Enable();
            CurrentCanvas = canvas;
            
        }

    }
}
