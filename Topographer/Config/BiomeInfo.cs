using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Topographer.Config
{
    [XmlRoot("Biome")]
    public class BiomeInfo
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlIgnore()]
        public Color Color { get; set; }

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

        [XmlIgnore()]
        public Color FoliageColor { get; set; }

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

        [XmlIgnore()]
        public Color WaterColor { get; set; }

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
