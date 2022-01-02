using System;
using System.Reflection.Metadata;
using Cosmos.System.Graphics;
using Graphics.Enum;
using Graphics.Image;
using Graphics;

namespace Graphics.Backend
{
    public class VBECursor : ICursor
    {
        
        private Point pos;
        private VBECanvas _canvas;
        public VBECursor(VBECanvas canvas)
        {
            _canvas = canvas;
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
                _Image = DefaultCursor.DefaultImage;
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

        public void Render()
        {
            if(AutoUpdate)
            {
                Pos((int)Cosmos.System.MouseManager.X, (int)Cosmos.System.MouseManager.Y);
            }
            var xBitmap = _Image.GetBitMap();
            var xWidht = (int)_Image.Width;
            var xHeight = (int)_Image.Height;
            _canvas.BufferLessDrawArray(xBitmap, pos.X, pos.Y, xWidht, xHeight);            
        }

        protected bool AutoUpdate = false;
        public void AutoPos(bool value) {
            AutoUpdate = value;
        }

    }
}
