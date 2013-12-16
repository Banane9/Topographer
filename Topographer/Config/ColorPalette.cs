using System.Xml.Serialization;
using System.Collections.Generic;

namespace Topographer.Config
{
    [XmlRoot("ColorPalette")]
    public class ColorPalette
    {
        [XmlIgnore()]
        public Dictionary<string, Biome> Biomes { get; set; }

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

        [XmlIgnore()]
        public Dictionary<string, Block> Blocks { get; set; }

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
