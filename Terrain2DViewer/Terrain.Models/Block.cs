using System;
using System.Collections.Generic;
using System.Text;

namespace Terrain.Models
{
    public class Block
    {
        public int x;
        public int y;
        public int z;
        public float Density = 0.0;
        public TerrainTypeEnum Type = TerrainTypeEnum.empty;
    }
}
