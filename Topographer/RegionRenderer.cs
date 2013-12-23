using Minecraft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topographer
{
    class RegionRenderer
    {
        public McRegion Region { get; private set; }

        public RegionRenderer(McRegion region)
        {
            // TODO: Complete member initialization
            Region = region;
        }

        public Bitmap Render(string outputPath)
        {
            Bitmap bitmap = new Bitmap(McRegion.Size.Width, McRegion.Size.Height);
            Render(bitmap);
            return bitmap;
        }

        public void Render(Bitmap bitmap)
        {
            List<ChunkRenderer> chunkRenderers = new List<ChunkRenderer>();
            foreach (McChunk chunk in Region)
            {
                chunkRenderers.Add(new ChunkRenderer(chunk));
            }

            Parallel.ForEach(chunkRenderers, chunkRenderer => chunkRenderer.Render(bitmap));
        }
    }
}
