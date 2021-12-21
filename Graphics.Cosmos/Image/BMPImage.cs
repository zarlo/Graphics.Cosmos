using Graphics.Cosmos.Enum;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.Cosmos.Image
{
    public class BMPImage : IImage
    {

        /// <summary>
        /// Get and set image width.
        /// </summary>
        public uint Width { get; protected set; }

        /// <summary>
        /// Get and set image height.
        /// </summary>
        public uint Height { get; protected set; }

        /// <summary>
        /// Get and set image color depth.
        /// </summary>
        public ColorDepth Depth { get; protected set; }

        public ImageFormat Format => ImageFormat.bmp;

        public int[] RawData { get; protected set; }

        /// <summary>
        /// Create new instance of <see cref="Image"/> class.
        /// </summary>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="color">Color depth.</param>
        protected BMPImage(uint width, uint height, ColorDepth colorDepth)
        {
            Width = width;
            Height = height;
            Depth = colorDepth;
            RawData = new int[Width * Height];
        }

        public void Save(Stream stream)
        {
            Save(stream, ImageFormat.bmp);
        }

        public void Save(Stream stream, ImageFormat format)
        {
            if (format != ImageFormat.bmp) throw new NotImplementedException();
            foreach (var i in RawData)
            {
                var data = BitConverter.GetBytes(i);
                stream.Write(data, 0, data.Length);
            }
        }

        public int[] GetBitMap()
        {
            return RawData;
        }
    }
}
