using System;
using System.Linq;

namespace Terrain.Models
{
    public class TerrainBase
    {
        private Block[,,] _points;

        public Block[,,] Points  => _points;

        private int[,] _heightMap;
        public int[,] HeightMap => _heightMap;

        public int X { get; }

        public int Y { get; }

        public int Z { get; }


        public TerrainBase(int x, int y , int z)
        {
            X = x;
            Y = y;
            Z = z;
            _points = new Block[x,y,z];
            _heightMap = new int[x, y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    for (int k = 0; k < Z; k++)
                    {
                        _points[i, j, k] = new Block() { x = i, y = j, z = z };
                        
                    }
                }
            }
        }

        public void RefreshHeightMap()
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    for (int k = Z-1; k <= 0; k--)
                    {
                        if (_points[i, j, k].Type != TerrainTypeEnum.empty || _points[i, j, k].Type != TerrainTypeEnum.water)
                        {
                            HeightMap[i, j] = k;
                            break;
                        }
                    }
                }
            }
        }

        public Block GetSurfaceBlock(int x, int y)
        {
            return _points[x, y, HeightMap[x, y]];
        }


    }
}
