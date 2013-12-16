using System.Xml.Serialization;
using System.Collections.Generic;

namespace Topographer.Config
{
    /// <summary>
    /// Class to store the information about the <see cref="Color"/> Palette for the Blocks and Biomes.
    /// </summary>
    [XmlRoot("ColorPalette")]
    public class ColorPalette
    {
        /// <summary>
        /// Gets or sets the <see cref="Dictionary"/> of Biomes with the <see cref="Biome"/> matched to the id.
        /// </summary>
        [XmlIgnore()]
        public Dictionary<string, Biome> Biomes { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="List"/> of <see cref="BiomeInfo"/>.
        /// </summary>
        [XmlArray("Biomes")]
        [XmlArrayItem("Biome")]
        public List<BiomeInfo> BiomeList
        {
            get
            {
                List<BiomeInfo> biomes = new List<BiomeInfo>();
                foreach (KeyValuePair<string, Biome> biome in Biomes)
                {
                    biomes.Add(new BiomeInfo { Id = biome.Key, Name = biome.Value.Name, Color = biome.Value.Color, FoliageColor = biome.Value.FoliageColor, WaterColor = biome.Value.WaterColor });
                }
                return biomes;
            }
            set
            {
                Biomes.Clear();
                foreach (BiomeInfo biome in value)
                {
                    Biomes.Add(biome.Id, new Biome { Name = biome.Name, Color = biome.Color, FoliageColor = biome.FoliageColor, WaterColor = biome.WaterColor });
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Dictionary"/> of Blocks with the <see cref="Block"/> matched to the id:meta.
        /// </summary>
        [XmlIgnore()]
        public Dictionary<string, Block> Blocks { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="List"/> of <see cref="BlockInfo"/>.
        /// </summary>
        [XmlArray("Blocks")]
        [XmlArrayItem("Block")]
        public List<BlockInfo> BlockList
        {
            get
            {
                List<BlockInfo> blocks = new List<BlockInfo>();
                foreach (KeyValuePair<string, Block> block in Blocks)
                {
                    blocks.Add(new BlockInfo { Id = block.Key, Name = block.Value.Name, Color = block.Value.Color, AddFoliageColor = block.Value.AddFoliageColor });
                }
                return blocks;
            }
            set
            {
                Blocks.Clear();
                foreach (BlockInfo block in value)
                {
                    Blocks.Add(block.Id, new Block { Name = block.Name, Color = block.Color, AddFoliageColor = block.AddFoliageColor });
                }
            }
        }
    }
}
