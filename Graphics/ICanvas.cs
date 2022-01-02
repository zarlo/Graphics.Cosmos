using Graphics.Image;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using system = System.Drawing;

namespace Graphics
{
    public interface ICanvas
    {

        /// <summary>
        /// Available graphics modes.
        /// </summary>
        List<Mode> AvailableModes { get; }

        /// <summary>
        /// Get default graphics mode.
        /// </summary>
        Mode DefaultGraphicMode { get; }

        /// <summary>
        /// Get and set graphics mode.
        /// </summary>
        Mode Mode { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        void SetMode(Mode mode);

        /// <summary>
        /// Clear all the Canvas with the Black color.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        void Clear();

        /// <summary>
        /// Clear all the Canvas with the specified color.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        void Clear(system.Color color);

        /// <summary>
        /// Display graphic mode
        /// </summary>
        void Disable();

        /// <summary>
        /// Display graphic mode
        /// </summary>
        void Enable();

        /// <summary>
        /// Swap Buffer
        /// </summary>
        void SwapBuffer();

        /// <summary>
        /// Draw point.
        /// </summary>
        /// <param name="color">Color to use.</param>
        /// <param name="point">Point.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        void DrawPoint(system.Color color, Point point);

        /// <summary>
        /// Draw point.
        /// </summary>
        /// <param name="color">Color to use.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        void DrawPoint(system.Color color, int x, int y);

        /// <summary>
        /// Name of the backend
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Display screen
        /// </summary>
        void Update();

        /// <summary>
        /// Get point color.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Color value.</returns>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        system.Color GetPointColor(int x, int y);

        /// <summary>
        /// Get point color.
        /// </summary>
        /// <param name="point">Point.</param>
        /// <returns>Color value.</returns>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        system.Color GetPointColor(Point point);

        /// <summary>
        /// Draw array of colors.
        /// </summary>
        /// <param name="colors">Colors array.</param>
        /// <param name="point">Starting point.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">unused.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if coordinates are invalid, or width is less than 0.</exception>
        /// <exception cref="NotImplementedException">Thrown if color depth is not supported.</exception>
        void DrawArray(system.Color[] colors, Point point, int width, int height);

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
        void DrawArray(system.Color[] colors, int x, int y, int width, int height);

        /// <summary>
        /// Draw array of colors.
        /// </summary>
        /// <param name="colors">Colors array.</param>
        /// <param name="point">Starting point.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">unused.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if coordinates are invalid, or width is less than 0.</exception>
        /// <exception cref="NotImplementedException">Thrown if color depth is not supported.</exception>
        void DrawArray(int[] colors, Point point, int width, int height);

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
        void DrawArray(int[] colors, int x, int y, int width, int height);

        /// <summary>
        /// Draw image.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        void DrawImage(IImage image, int x, int y);

        /// <summary>
        /// Draw image.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="pos">pos.</param>
        /// <exception cref="Exception">Thrown on memory access violation.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown on fatal error.</exception>
        void DrawImage(IImage image, Point pos);        
        ICursor Cursor { get; }

        void SetSoftwareCursor(ICursor cursor);
        void UseSoftwareCursor();
        void UseHardwareCursor();

        void DrawFilledRectangle(system.Color color, Point point, int width, int height);
        void DrawFilledRectangle(system.Color color, int x_start, int y_start, int width, int height);

    }
}
