using System;
using System.Collections.Generic;
using System.Text;
using Terrain.Models;

namespace Terrain.Generator
{
    internal class Initialisator : IInitialisator
    {
        public void Initialize(TerrainBase terrain)
        {
            InitBlock(terrain);

        }

        private static void InitBlock(TerrainBase terrain)
        {
            var random = new Random();
            for (int i = 0; i < terrain.X; i++)
            {
                for (int j = 0; j < terrain.Y; j++)
                {
                    for (int k = 0; k < terrain.Z; k++)
                    {
                        if (k < 10)
                        {
                            terrain.Points[i, j, k].Type = TerrainTypeEnum.granite;
                            terrain.Points[i, j, k].Density = 100;
                        }
                        else if (k <= 30)
                        {
                            terrain.Points[i, j, k].Type = TerrainTypeEnum.calcite;
                            terrain.Points[i, j, k].Density = 100;
                            terrain.HeightMap[i, j] = k;
                        }
                        else if (k == 31 && random.Next(100) < 50)
                        {
                            terrain.Points[i, j, k].Type = TerrainTypeEnum.calcite;
                            terrain.Points[i, j, k].Density = 100;
                            terrain.HeightMap[i, j] = k;
                        }
                    }
                }
            }
        }
    }
}
