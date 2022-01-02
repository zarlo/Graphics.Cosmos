using System;
using System.Collections.Generic;
using Cosmos.System.Graphics;
using system = System.Drawing;

using Graphics.Image;

using Graphics.HAL;
using System.Drawing;

namespace Graphics.Backend
{


    public class VBECanvas : BaseCanvas
    {

        private readonly VBEDriverPlus _VBEDriver; 

        public override List<Mode> AvailableModes => new() { 

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

        public override Mode DefaultGraphicMode => new(1280, 768, ColorDepth.ColorDepth32);

        Mode _Mode;

        public override Mode Mode { get => _Mode; set => SetMode(value); }

        public override string Name => "VBE";

        public VBECanvas(Mode mode = default)
        {
            _VBEDriver = new VBEDriverPlus(
                (ushort)DefaultGraphicMode.Columns, 
                (ushort)DefaultGraphicMode.Rows, 
                (ushort)DefaultGraphicMode.ColorDepth
                );
            if (mode == default)
            {
                SetMode(DefaultGraphicMode);
            }
            else
            {
                if (!AvailableModes.Contains(mode)) throw new NotSupportedException("Mode is not supported");
                SetMode(mode);
            }
        }

        public override void SetMode(Mode mode) 
        {
            _Mode = mode;
            _VBEDriver.VBESet(
                (ushort)mode.Columns, 
                (ushort)mode.Rows, 
                (ushort)mode.ColorDepth
            );
        }

        public override void Clear(system.Color color)
        {
            _VBEDriver.ClearVRAM((uint)color.ToArgb());
        }

        public override void Disable()
        {
            _VBEDriver.DisableDisplay();
        }

        public override void Enable()
        {
        }

        public override void Update()
        {
            SwapBuffer();
            if (Cursor.CursorType == Enum.CursorType.Software)
            {
                DrawImage(Cursor.GetImage(), Cursor.Pos());
            }
            else
            {
                Cursor.Render();
            }
            Clear();
        }

        public override void DrawArray(system.Color[] colors, int x, int y, int width, int height) 
        {
            var data = new int[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                data[i] = colors[i].ToArgb();
            }
        }
        public override void DrawArray(int[] colors, int x, int y, int width, int height) 
        {
            
            var xWidht = width;
            var xHeight = height;

            int xOffset = GetPointOffset(x, y);
            int xScreenWidthInPixel = Mode.Columns * ((int)Mode.ColorDepth / 8);

            for (int i = 0; i < xHeight; i++)
            {
                _VBEDriver.CopyVRAM((i * xScreenWidthInPixel) + xOffset, colors, (i * xWidht), xWidht);
            }
        }

        public override void DrawImage(IImage image, int x, int y)
        {

            var xBitmap = image.GetBitMap();
            var xWidht = (int)image.Width;
            var xHeight = (int)image.Height;
            DrawArray(xBitmap, x, y, xWidht, xHeight);
        }

        public override system.Color GetPointColor(int x, int y)
        {
            int offset = GetPointOffset(x, y);
           return system.Color.FromArgb((int)_VBEDriver.GetVRAM((uint)offset));
        }

        public override void SwapBuffer()
        {
            _VBEDriver.Swap();
        }

        public override void DrawPoint(system.Color color, int aX, int aY)
        {
            uint offset = (uint)GetPointOffset(aX, aY);

            switch (Mode.ColorDepth)
            {
                case ColorDepth.ColorDepth32:

                    if (color.A == 0)
                    {
                        return;
                    }
                    else if (color.A < 255)
                    {
                        color = Utils.AlphaBlend(color, GetPointColor(aX, aY), color.A);
                    }

                    _VBEDriver.SetVRAM(offset, color.B);
                    _VBEDriver.SetVRAM(offset + 1, color.G);
                    _VBEDriver.SetVRAM(offset + 2, color.R);
                    _VBEDriver.SetVRAM(offset + 3, color.A);

                    break;
                case ColorDepth.ColorDepth24:

                    _VBEDriver.SetVRAM(offset, color.B);
                    _VBEDriver.SetVRAM(offset + 1, color.G);
                    _VBEDriver.SetVRAM(offset + 2, color.R);

                    break;
                default:
                    string errorMsg = "DrawPoint() with ColorDepth " + (int)Mode.ColorDepth + " not yet supported";
                    throw new NotImplementedException(errorMsg);
            }
        }

        public override void UseHardwareCursor()
        {
            _Cursor = new VBECursor(this);
        }

        /// <summary>
        /// Get point offset.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>int value.</returns>
        private int GetPointOffset(int aX, int aY)
        {
            int xBytePerPixel = (int)Mode.ColorDepth / 8;
            int stride = (int)Mode.ColorDepth / 8;
            int pitch = Mode.Columns * xBytePerPixel;

            return (aX * stride) + (aY * pitch);
        }

        public void BufferLessDrawArray(int[] colors, int x, int y, int width, int height) 
        {
            
            var xWidht = width;
            var xHeight = height;

            int xOffset = GetPointOffset(x, y);
            int xScreenWidthInPixel = Mode.Columns * ((int)Mode.ColorDepth / 8);

            for (int i = 0; i < xHeight; i++)
            {
                BufferLessCopyVRAM((i * xScreenWidthInPixel) + xOffset, colors, (i * xWidht), xWidht);
            }
        }

        public void BufferLessCopyVRAM(int aStart, int[] aData, int aIndex, int aCount) 
        {
            _VBEDriver.BufferLessCopyVRAM(aStart, aData, aIndex, aCount);
        }


    }
}
