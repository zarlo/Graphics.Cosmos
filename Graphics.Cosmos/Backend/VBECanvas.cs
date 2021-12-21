using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Cosmos.Backend
{
    public class VBECanvas : BaseCanvas
    {
        public override List<Mode> AvailableModes => throw new NotImplementedException();

        public override Mode DefaultGraphicMode => new(1280, 768, ColorDepth.ColorDepth32);

        public override Mode Mode { get => throw new NotImplementedException(); set => SetMode(value); }

        public override string Name => "VBE";

        public VBECanvas(Mode mode = default)
        {
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
            throw new NotImplementedException();
        }

        public override void Clear(Color color)
        {
            throw new NotImplementedException();
        }

        public override void Disable()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void DrawPoint(Color color, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Color GetPointColor(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void SwapBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
