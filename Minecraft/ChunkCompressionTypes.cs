using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minecraft
{
    /// <summary>
    /// Enumerator for the chunk compression types and their representation in the region file.
    /// </summary>
    public enum ChunkCompressionTypes
    {
        /// <summary>
        /// Unused in paractice. RFC 1952
        /// </summary>
        GZip = 1,

        /// <summary>
        /// RFC 1950
        /// </summary>
        ZLib = 2
    }
}
