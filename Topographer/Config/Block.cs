using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Topographer.Config
{
    /// <summary>
    /// Class to store information (not including id:meta) about a Block.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Gets or sets the Block's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Block's <see cref="Color"/>.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets whether the Block's <see cref="Color"/> is blended with the Biome's vegetation <see cref="Color"/>.
        /// </summary>
        public bool AddFoliageColor { get; set; }
    }
}
