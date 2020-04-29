using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;
using Terrain.Models;

namespace Terrain.Generator
{
    internal class ErosionWorker : ITerrainWorker
    {
        public void Apply(TerrainBase terrain)
        {
            //Add water
            ApplyWater(terrain, 5);
            ApplyFlux(terrain);

        }

        private void ApplyFlux(TerrainBase terrain)
        {
            for (int i = 0; i < terrain.X; i++)
            {
                for (int j = 0; j < terrain.Y; j++)
                {
                    ApplyFlux(terrain, i, j, terrain.HeightMap[i, j]);
                }
            }
        }

        private void ApplyFlux(TerrainBase terrain, int x, int y, int z)
        {
            var bloc = GetLowerGround(terrain, x, y, z);


        }

        private Block GetLowerGround(TerrainBase terrain, int x, int y, int z)
        {
            var blocList = GetNeighborsBlocks(terrain, x, y);
            blocList.OrderBy(b => b.z).ThenBy(l => l.Density);
            return blocList.First();
        }

        private IEnumerable<Block> GetNeighborsBlocks(TerrainBase terrain, int x, int y)
        {
            List<Block> result = new List<Block>();
            for (int i = x - 1; i < x + 1; i++)
            {
                for (int j = y - 1; j < y + 1 j++)
                {
                    if (x - 1 >= 0 && y - 1 >= 0 && x + 1 < terrain.X && y + 1 < terrain.Y)
                        result.Add(terrain.GetSurfaceBlock(x, y));
                }
            }




            return result;
        }

        private static void ApplyWater(TerrainBase terrain, int density)
        {
            for (int i = 0; i < terrain.X; i++)
            {
                for (int j = 0; j < terrain.Y; j++)
                {
                    if (terrain.HeightMap[i, j] == terrain.Z - 1)
                        continue;

                    var bloc = terrain.Points[i, j, terrain.HeightMap[i, j] + 1];
                    if (bloc.Type == TerrainTypeEnum.water)
                    {
                        if (bloc.Density + density > 100)
                        {
                            terrain.Points[i, j, terrain.HeightMap[i, j] + 2].Density = (bloc.Density + density) % 100;
                            terrain.Points[i, j, terrain.HeightMap[i, j] + 2].Type = TerrainTypeEnum.water;
                            bloc.Density = 100;
                        }
                    }
                    else //bloc is empty
                    {
                        bloc.Type = TerrainTypeEnum.water;
                        bloc.Density = density;
                    }
                }
            }
        }
    }
}
