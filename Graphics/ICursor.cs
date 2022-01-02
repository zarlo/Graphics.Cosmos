using Graphics.Enum;
using Graphics.Image;
using Cosmos.System.Graphics;
namespace Graphics
{
    public interface ICursor
    {

        CursorType CursorType { get; }
        IImage GetImage();
        void Image(IImage image = null);

        bool IsVisable { get; }

        Point Pos();
        void Pos(int x, int y);
        void Visable(bool status);
        void Render();
    }
}