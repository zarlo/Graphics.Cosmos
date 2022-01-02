using system = System.Drawing;

namespace Graphics
{
    public class Utils
    {

        /// <summary>
        /// Calculate new Color from back Color with alpha
        /// </summary>
        /// <param name="to">Color to calculate.</param>
        /// <param name="from">Color used to calculate.</param>
        /// <param name="alpha">Alpha amount.</param>
        public static system.Color AlphaBlend(system.Color to, system.Color from, byte alpha) {
            byte R = (byte)((to.R * alpha + from.R * (255 - alpha)) >> 8);
            byte G = (byte)((to.G * alpha + from.G * (255 - alpha)) >> 8);
            byte B = (byte)((to.B * alpha + from.B * (255 - alpha)) >> 8);
            return system.Color.FromArgb(R, G, B);
        }

    }
}
