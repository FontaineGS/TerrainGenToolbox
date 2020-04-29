using System;
using System.Collections.Generic;
using Terrain.Models;

namespace Terrain.Generator
{
    public class Generator
    {
        // Default Size();
        public const int X = 100;
        public const int Y = 100;
        public const int Z = 60;

        public Generator()
        {
            Initialisator = new Initialisator();
            ProcessList = new List<ITerrainWorker>();
            ProcessList.Add(new ErosionWorker());

            _terrain = new TerrainBase(X,Y,Z);
        }

        private TerrainBase _terrain;

        public TerrainBase Terrain => _terrain;

        internal IList<ITerrainWorker> ProcessList { get; }

       internal IInitialisator Initialisator { get; }

        public void Initialize()
        {
            Initialisator.Initialize(_terrain);
        }

        public void Step(int turns = 0)
        {
            foreach(ITerrainWorker worker in ProcessList)
            {
                worker.Apply(_terrain);
            }
        }



    }
}
