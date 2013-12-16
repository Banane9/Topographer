using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Topographer.Config
{
    [XmlRoot("Block")]
    public class BlockInfo
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

        [XmlAttribute("AddFoliageColor")]
        public bool AddFoliageColor { get; set; }
    }
}
