using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    public class World : IEnumerable
    {
        public string WorldPath { get; private set; }

        public Size Size { get; private set; }

        public List<McRegion> Regions { get; set; }

        private World() { }

        private World(string worldPath)
        {
            WorldPath = worldPath;
            Regions = new List<McRegion>();
        }

        public static World LoadWorld(string worldPath)
        {
            World world = new World(worldPath);
            Parallel.ForEach(Directory.GetFiles(worldPath + "\\region", "*.mca"), regionFilePath => world.Regions.Add(McRegion.LoadRegion(regionFilePath)));
            return world;
        }

        public IEnumerator GetEnumerator()
        {
            return Regions.GetEnumerator();
        }
    }
}
