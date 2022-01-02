using Graphics.Image;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using system = System.Drawing;
using System.Linq;
using System.Text;

namespace Graphics
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
            Clear(system.Color.Black);
        }

        public abstract void Clear(system.Color color);

        public abstract void Disable();

        public abstract void Enable();

        public abstract void Update();
        
        public abstract void SwapBuffer();
        
        public void DrawArray(system.Color[] colors, Point point, int width, int height)
        {
            DrawArray(colors, point.X, point.Y, width, height);
        }

        public virtual void DrawArray(system.Color[] colors, int x, int y, int width, int height)
        {
            for (int _x = 0; _x < width; _x++)
            {
                for (int _y = 0; _y < height; _y++)
                {
                    DrawPoint(colors[_x + _y * width], x + _x, y + _y);

                }
            }
        }

        public void DrawArray(int[] colors, Point point, int width, int height)
        {
            DrawArray(colors, point.X, point.Y, width, height);
        }

        public virtual void DrawArray(int[] colors, int x, int y, int width, int height)
        {
            for (int _x = 0; _x < width; _x++)
            {
                for (int _y = 0; _y < height; _y++)
                {
                    DrawPoint(system.Color.FromArgb(colors[_x + _y * width]), x + _x, y + _y);
                }
            }
        }
        public void DrawImage(IImage image, Point point)
        {
            DrawImage(image, point.X, point.Y);
        }
        
        public virtual void DrawImage(IImage image, int x, int y)
        {
            var bitmap = image.GetBitMap();
            for (int _x = 0; _x < image.Width; _x++)
            {
                for (int _y = 0; _y < image.Height; _y++)
                {
                    DrawPoint(system.Color.FromArgb(bitmap[_x + _y * image.Width]), x + _x, y + _y);
                }
            }
        }

        public virtual void DrawPoint(system.Color color, Point point)
        {
            DrawPoint(color, point.X, point.Y);
        }

        public abstract void DrawPoint(system.Color color, int x, int y);

        public abstract system.Color GetPointColor(int x, int y);

        public virtual system.Color GetPointColor(Point point) 
        {
            return GetPointColor(point.X, point.Y);
        }

        protected ICursor _Cursor;

        public ICursor Cursor { get { return _Cursor;} }

        public virtual void SetSoftwareCursor(ICursor cursor) {
            _Cursor = cursor;
        }
        public virtual void UseSoftwareCursor() {
            SetSoftwareCursor(new DefaultCursor());
        }
        public abstract void UseHardwareCursor();

        public virtual void DrawFilledRectangle(system.Color color, Point point, int width, int height)
        {
            throw new NotImplementedException();
        }

        public virtual void DrawFilledRectangle(system.Color color, int x_start, int y_start, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
