using Minecraft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Topographer
{
    public class ChunkRenderer
    {
        public McChunk Chunk { get; private set; }

        public ChunkRenderer(McChunk chunk)
        {
            Chunk = chunk;
        }

        public Bitmap Render()
        {
            Bitmap bitmap = new Bitmap(McChunk.Size.Width, McChunk.Size.Height);
            Render(bitmap);
            return bitmap;
        }

        public void Render(Bitmap bitmap)
        {
            
        }
    }
}
