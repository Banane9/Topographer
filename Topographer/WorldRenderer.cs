using Minecraft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Topographer
{
    public class WorldRenderer
    {
        public World World { get; private set; }

        public Topographer.Config.ColorPalette ColorPalette { get; set; }

        public WorldRenderer(string worldPath, string colorPalettePath = "Config/ColorPalette.xml")
        {
            World = World.LoadWorld(worldPath);
            _loadColorPalette(colorPalettePath);
        }

        public WorldRenderer(World world, string colorPalettePath = "Config/ColorPalette.xml")
        {
            World = world;
            _loadColorPalette(colorPalettePath);
        }

        private void _loadColorPalette(string colorPalettePath)
        {
            XmlReader reader = XmlReader.Create(colorPalettePath);
            XmlSchema schema = new XmlSchema();
            schema.SourceUri = "Config/ColorPalette.xsd";
            reader.Settings.Schemas.Add(schema);
            XmlSerializer serializer = new XmlSerializer(typeof(Topographer.Config.ColorPalette));
            ColorPalette = (Topographer.Config.ColorPalette)serializer.Deserialize(reader);
        }

        public Bitmap Render()
        {
            Bitmap bitmap = new Bitmap(World.Size.Width, World.Size.Height);
            Render(bitmap);
            return bitmap;
        }

        public void Render(string outputPath)
        {
            Bitmap bitmap = new Bitmap(World.Size.Width, World.Size.Height);
            Render(bitmap);
            //Save bitmap in outputPath
        }

        public void Render(Bitmap bitmap)
        {
            List<RegionRenderer> regionRenderers = new List<RegionRenderer>();
            foreach (McRegion region in World)
            {
                regionRenderers.Add(new RegionRenderer(region));
            }

            Parallel.ForEach(regionRenderers, regionRenderer => { regionRenderer.Render(bitmap); });

        }
    }
}
