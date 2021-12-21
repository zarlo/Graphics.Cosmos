using Graphics.Cosmos.Image;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Cosmos
{
    public abstract class BaseCanvas : ICanvas
    {
        public abstract List<Mode> AvailableModes { get; }

        public abstract Mode DefaultGraphicMode { get; }

        public abstract Mode Mode { get; set; }

        public abstract string Name { get; }

        public abstract void SetMode(Mode mode);

        public void Clear()
        {
            Clear(Color.Black);
        }

        public abstract void Clear(Color color);

        public abstract void Disable();

        public abstract void Display();
        
        public abstract void SwapBuffer();
        
        public void DrawArray(Color[] colors, Point point, int width, int height)
        {
            DrawArray(colors, point.X, point.Y, width, height);
        }

        public void DrawArray(Color[] colors, int x, int y, int width, int height)
        {
            for (int _x = 0; _x < width; _x++)
            {
                for (int _y = 0; _y < height; _y++)
                {
                    DrawPoint(colors[_x + _y * width], x + _x, y + _y);

                }
            }
        }

        public virtual void DrawImage(IImage image, int x, int y)
        {
            var bitmap = image.GetBitMap();
            for (int _x = 0; _x < image.Width; _x++)
            {
                for (int _y = 0; _y < image.Height; _y++)
                {
                    DrawPoint(Color.FromArgb(bitmap[_x + _y * image.Width]), x + _x, y + _y);
                }
            }
        }

        public virtual void DrawPoint(Color color, Point point)
        {
            DrawPoint(color, point.X, point.Y);
        }

        public abstract void DrawPoint(Color color, int x, int y);

        public abstract Color GetPointColor(int x, int y);

        public virtual Color GetPointColor(Point point) {
            return GetPointColor(point.X, point.Y);
        }

        /// <summary>
        /// Calculate new Color from back Color with alpha
        /// </summary>
        /// <param name="to">Color to calculate.</param>
        /// <param name="from">Color used to calculate.</param>
        /// <param name="alpha">Alpha amount.</param>
        internal static Color AlphaBlend(Color to, Color from, byte alpha) {
            byte R = (byte)((to.R * alpha + from.R * (255 - alpha)) >> 8);
            byte G = (byte)((to.G * alpha + from.G * (255 - alpha)) >> 8);
            byte B = (byte)((to.B * alpha + from.B * (255 - alpha)) >> 8);
            return Color.FromArgb(R, G, B);
        }
    }
}
