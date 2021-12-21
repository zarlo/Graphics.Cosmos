using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Cosmos
{
    public class Canvas
    {

        public static List<Mode> CommonModes = new() {
            new Mode(320, 240, ColorDepth.ColorDepth32),
            new Mode(640, 480, ColorDepth.ColorDepth32),
            new Mode(800, 600, ColorDepth.ColorDepth32),
            new Mode(1024, 768, ColorDepth.ColorDepth32),
            /* The so called HD-Ready resolution */
            new Mode(1280, 720, ColorDepth.ColorDepth32),
            new Mode(1280, 768, ColorDepth.ColorDepth32),
            new Mode(1280, 1024, ColorDepth.ColorDepth32),
            /* A lot of HD-Ready screen uses this instead of 1280x720 */
            new Mode(1366, 768, ColorDepth.ColorDepth32),
            new Mode(1680, 1050, ColorDepth.ColorDepth32),
            /* HDTV resolution */
            new Mode(1920, 1080, ColorDepth.ColorDepth32),
            /* HDTV resolution (16:10 AR) */
            new Mode(1920, 1200, ColorDepth.ColorDepth32),
        };

        private static ICanvas CurrentCanvas;
        public static ICanvas GetCanvas(Mode mode = default) {
            if (CurrentCanvas == null)
            {
                SetCanvas(new Backend.VBECanvas(mode));
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
            canvas.Display();
            CurrentCanvas = canvas;
        }

    }
}
