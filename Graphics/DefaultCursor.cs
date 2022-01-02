using System;
using System.Reflection.Metadata;
using Cosmos.System.Graphics;
using Graphics.Enum;
using Graphics.Image;

namespace Graphics
{
    public class DefaultCursor : ICursor
    {
        
        public static IImage DefaultImage { get {
            return BMPImage.Load(new int[5 * 5] {
                0xFF, 0x00, 0x00, 0x00, 0xFF,
                0x00, 0xFF, 0x00, 0xFF, 0x00,
                0x00, 0x00, 0xFF, 0x00, 0x00,
                0x00, 0xFF, 0x00, 0xFF, 0x00,
                0xFF, 0x00, 0x00, 0x00, 0xFF,
            }, 5, 5, ColorDepth.ColorDepth32);
        } }

        private Point pos;
        public DefaultCursor()
        {
            pos = new Point(0, 0);
            Image();
        }

        public CursorType CursorType => CursorType.Software;

        IImage _Image;

        bool _Visable; 

        public IImage GetImage()
        {
            return _Image;
        }

        public void Image(IImage image = null)
        {
            _Visable = false;
            if(image == null)
            {
                _Image = DefaultImage;
            }
            else
            {
                _Image = image;
            }
        }

        public bool IsVisable { get { return _Visable; } }

        public Point Pos()
        {
            return pos;
        }

        public void Pos(int x, int y)
        {
            pos.X = x;
            pos.Y = y;
        }

        public void Visable(bool status)
        {
            _Visable = status;
        }
        protected bool AutoUpdate = false;
        public void AutoPos(bool value) {
            AutoUpdate = value;
        }

        public void Render() {
            if(AutoUpdate)
            {
                Pos((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y);
            }
            Canvas.GetCanvas().DrawImage(_Image, pos);
        }
        

    }
}
