using Ionic.Zlib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minecraft
{
    public class McRegion : IEnumerable
    {
        public string RegionPath { get; private set; }

        public static Size Size
        {
            get
            {
                return new Size(512, 512); //32*16 x 32*16
            }
        }

        public Point Coordinates { get; private set; }

        public List<McChunk> Chunks { get; private set; }

        private McRegion() { }

        private McRegion(string regionPath)
        {
            RegionPath = regionPath;
            Match coords = Regex.Match(regionPath, @"r\.(-?\d+)\.(-?\d+)\.mca", RegexOptions.IgnoreCase);
            Coordinates = new Point(int.Parse(coords.Groups[1].Value), int.Parse(coords.Groups[2].Value));
            Chunks = new List<McChunk>();
        }

        public static McRegion LoadRegion(string regionPath)
        {
            McRegion region = new McRegion(regionPath);

            using (BinaryReader file = new BinaryReader(File.Open(regionPath, FileMode.Open)))
            {
                byte[] chunkLocations = new byte[4096];
                byte[] chunkTimestamps = new byte[4096];

                file.Read(chunkLocations, 0, 4095);
                file.Read(chunkTimestamps, 4096, 8191);

                for (int headerPosition = 0; headerPosition < 4096; headerPosition += 4) // 32*32 chunks
                {
                    //Get info about the chunk in the file
                    byte[] chunkOffsetInfo = new byte[4];
                    chunkOffsetInfo[0] = 0;
                    Array.Copy(chunkLocations, headerPosition, chunkOffsetInfo, 1, 3);
                    
                    long chunkOffset = BitConverter.ToInt32(BitConverter.IsLittleEndian ? chunkOffsetInfo.Reverse().ToArray() : chunkOffsetInfo, 0) * 4096;
                    byte chunkSectors = chunkLocations[headerPosition + 3];

                    byte[] chunkTimestampInfo = new byte[4];
                    Array.Copy(chunkTimestamps, headerPosition, chunkTimestampInfo, 0, 4);

                    int chunkTimestamp = BitConverter.ToInt32(BitConverter.IsLittleEndian ? chunkTimestampInfo.Reverse().ToArray() : chunkTimestampInfo, 0);

                    if (chunkOffset < 2 || chunkSectors < 1) continue; //Non existing or invalid chunk

                    //Read the chunk info
                    file.BaseStream.Seek(chunkOffset, SeekOrigin.Begin);

                    byte[] chunkLengthInfo = new byte[4];
                    file.Read(chunkLengthInfo, 0, 4);

                    uint chunkLength = BitConverter.ToUInt32(BitConverter.IsLittleEndian ? chunkLengthInfo.Reverse().ToArray() : chunkLengthInfo, 0);

                    ChunkCompressionTypes chunkCompressionType = (ChunkCompressionTypes)file.ReadByte();

                    byte[] compressedChunkData = new byte[chunkLength - 1];
                    file.Read(compressedChunkData, 0, (int)chunkLength - 1);

                    MemoryStream uncompressedChunkData = new MemoryStream();

                    switch (chunkCompressionType)
                    {
                        case ChunkCompressionTypes.GZip:
                            new GZipStream(new MemoryStream(compressedChunkData), CompressionMode.Decompress).CopyTo(uncompressedChunkData);
                            break;

                        case ChunkCompressionTypes.ZLib:
                            new ZlibStream(new MemoryStream(compressedChunkData), CompressionMode.Decompress).CopyTo(uncompressedChunkData);
                            break;

                        default:
                            throw new Exception("Unrecognized compression type");
                            break;
                    }

                    region.Chunks.Add(new McChunk(uncompressedChunkData, chunkTimestamp));
                }

                file.Close();
            }

            return region;
        }

        public IEnumerator GetEnumerator()
        {
            return Chunks.GetEnumerator();
        }
    }
}
