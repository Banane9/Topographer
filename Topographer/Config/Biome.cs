using System.Drawing;

namespace Topographer.Config
{
    /// <summary>
    /// Class to store information (except id) about a Biome.
    /// </summary>
    public class Biome
    {
        /// <summary>
        /// Gets or set the Biome's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Biome's <see cref="Color"/> for a Biome Map.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the Biome's of the vegetation <see cref="Color"/>.
        /// </summary>
        public Color FoliageColor { get; set; }

        /// <summary>
        /// Gets or sets the Biome's water <see cref="Color"/>.
        /// </summary>
        public Color WaterColor { get; set; }
    }
}
