using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Topographer.Config
{
    /// <summary>
    /// Class to store information (including id:meta) about a Block.
    /// </summary>
    [XmlRoot("Block")]
    public class BlockInfo
    {
        /// <summary>
        /// Gets or sets the Block's id:meta.
        /// </summary>
        [XmlAttribute("Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Block's name.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Block's <see cref="Color"/>.
        /// </summary>
        [XmlIgnore()]
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the Block's <see cref="Color"/> as a string in Hex format.
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
        /// Gets or sets whether the Block's <see cref="Color"/> is blended with the Biome's vegetation <see cref="Color"/>.
        /// </summary>
        [XmlAttribute("AddFoliageColor")]
        public bool AddFoliageColor { get; set; }
    }
}
