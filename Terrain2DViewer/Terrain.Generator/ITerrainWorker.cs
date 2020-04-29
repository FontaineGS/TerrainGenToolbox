using Terrain.Models;

namespace Terrain.Generator
{
    public interface ITerrainWorker
    {
        void Apply(TerrainBase terrain);
    }
}