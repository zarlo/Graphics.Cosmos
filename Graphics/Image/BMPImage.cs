using Graphics.Enum;

using System;
using System.IO;
using Cosmos.System.Graphics;
using Cosmos.Core;

namespace Graphics.Image
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

        public Enum.ImageFormat Format => Enum.ImageFormat.bmp;

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
            Save(stream, Enum.ImageFormat.bmp);
        }

        public void Save(Stream stream, Enum.ImageFormat format)
        {
            if (format != Enum.ImageFormat.bmp) throw new NotImplementedException();
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
        public static BMPImage Load(byte[] data, uint width, uint height, ColorDepth colorDepth) 
        {
            var _data = Array.ConvertAll(data, Convert.ToInt32);
            return Load(_data, width, height, colorDepth);
        }
        public static BMPImage Load(int[] data,  uint width, uint height, ColorDepth colorDepth) 
        {

            var output = new BMPImage(width, height, colorDepth)
            {
                RawData = data
            };

            return output;
        }


    }
}
