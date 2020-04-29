using Terrain.Models;

namespace Terrain.Generator
{
    internal interface IInitialisator
    {
        void Initialize(TerrainBase terrain);
    }
}