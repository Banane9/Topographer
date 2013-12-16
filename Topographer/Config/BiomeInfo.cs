using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Topographer.Config
{
    /// <summary>
    /// Class to store information (including id) about a Biome.
    /// </summary>
    [XmlRoot("Biome")]
    public class BiomeInfo
    {
        /// <summary>
        /// Gets or sets the Biome's Id.
        /// </summary>
        [XmlAttribute("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or set the Biome's Name.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or set the Biome's <see cref="Color"/> for a Biome Map.
        /// </summary>
        [XmlIgnore()]
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the Biome's Biome Map <see cref="Color"/> with a string in Hex format.
        /// </summary>
        [XmlAttribute("Color")]
        public string ColorString
        {
            get
            {
                return Convert.ToString(Color.ToArgb(), 16).PadLeft(8, '0');
            }
            set
            {
                Color = Color.FromArgb(Convert.ToInt32(value, 16));
            }
        }

        /// <summary>
        /// Gets or sets the Biome's vegetation <see cref="Color"/>.
        /// </summary>
        [XmlIgnore()]
        public Color FoliageColor { get; set; }

        /// <summary>
        /// Gets or sets the Biome's vegetation <see cref="Color"/> with a string in Hex format.
        /// </summary>
        [XmlAttribute("FoliageColor")]
        public string FoliageColorString
        {
            get
            {
                return Convert.ToString(FoliageColor.ToArgb(), 16).PadLeft(8, '0');
            }
            set
            {
                FoliageColor = Color.FromArgb(Convert.ToInt32(value, 16));
            }
        }

        /// <summary>
        /// Gets or sets the Biome's water <see cref="Color"/>.
        /// </summary>
        [XmlIgnore()]
        public Color WaterColor { get; set; }

        /// <summary>
        /// Gets or sets the Biome's water <see cref="Color"/> with a string in Hex format.
        /// </summary>
        [XmlAttribute("WaterColor")]
        public string WaterColorString
        {
            get
            {
                return Convert.ToString(WaterColor.ToArgb(), 16).PadLeft(8, '0');
            }
            set
            {
                WaterColor = Color.FromArgb(Convert.ToInt32(value, 16));
            }
        }
    }
}
