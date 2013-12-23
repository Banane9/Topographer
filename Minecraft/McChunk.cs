using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Minecraft
{
    public class McChunk
    {
        public static Size Size
        {
            get
            {
                return new Size(16, 16);
            }
        }

        public Point Coordinates { get; private set; }
    }
}
