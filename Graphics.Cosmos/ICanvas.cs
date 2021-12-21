using System;
using System.Drawing;
using System.Collections.Generic;
using Graphics.Cosmos.Image;

namespace Graphics.Cosmos
{
    public interface ICanvas
    {

        /// <summary>
        /// Available graphics modes.
        /// </summary>
        public List<Mode> AvailableModes { get; }

        /// <summary>
        /// Get default graphics mode.
        /// </summary>
        public Mode DefaultGraphicMode { get; }

        /// <summary>
        /// Get and set graphics mode.
        /// </summary>
        public Mode Mode { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void SetMode(Mode mode);

        /// <summary>
        /// Clear all the Canvas with the Black color.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        public void Clear();

        /// <summary>
        /// Clear all the Canvas with the specified color.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        public void Clear(Color color);

        /// <summary>
        /// Display graphic mode
        /// </summary>
        public void Disable();

        /// <summary>
        /// Swap Buffer
        /// </summary>
        public void SwapBuffer();

        /// <summary>
        /// Draw point.
        /// </summary>
        /// <param name="color">Color to use.</param>
        /// <param name="point">Point.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        public void DrawPoint(Color color, Point point);

        /// <summary>
        /// Draw point.
        /// </summary>
        /// <param name="color">Color to use.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        public void DrawPoint(Color color, int x, int y);

        /// <summary>
        /// Name of the backend
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Display screen
        /// </summary>
        public void Display();

        /// <summary>
        /// Get point color.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Color value.</returns>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        public Color GetPointColor(int x, int y);

        /// <summary>
        /// Get point color.
        /// </summary>
        /// <param name="point">Point.</param>
        /// <returns>Color value.</returns>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        public Color GetPointColor(Point point);

        /// <summary>
        /// Draw array of colors.
        /// </summary>
        /// <param name="colors">Colors array.</param>
        /// <param name="point">Starting point.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">unused.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if coordinates are invalid, or width is less than 0.</exception>
        /// <exception cref="NotImplementedException">Thrown if color depth is not supported.</exception>
        public void DrawArray(Color[] colors, Point point, int width, int height);

        /// <summary>
        /// Draw array of colors.
        /// </summary>
        /// <param name="colors">Colors array.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">unused.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if coordinates are invalid, or width is less than 0.</exception>
        /// <exception cref="NotImplementedException">Thrown if color depth is not supported.</exception>
        public void DrawArray(Color[] colors, int x, int y, int width, int height);

        /// <summary>
        /// Draw image.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        public void DrawImage(IImage image, int x, int y);

    }
}
