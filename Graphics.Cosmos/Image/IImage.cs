using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graphics.Cosmos.Enum;

namespace Graphics.Cosmos.Image
{
    public interface IImage
    {
        /// <summary>
        /// Get and set raw data (pixels array).
        /// </summary>
        public int[] RawData { get; }

        /// <summary>
        /// Get and set raw data (pixels array).
        /// </summary>
        public int[] GetBitMap();

        /// <summary>
        /// Get and set image width.
        /// </summary>
        public uint Width { get; }

        /// <summary>
        /// Get and set image height.
        /// </summary>
        public uint Height { get; }

        /// <summary>
        /// Get and set image color depth.
        /// </summary>
        public ColorDepth Depth { get; }

        /// <summary>
        /// Get the image Format.
        /// </summary>
        public ImageFormat Format { get; }

        public void Save(Stream stream);
        public void Save(Stream stream, ImageFormat format);

    }

}
