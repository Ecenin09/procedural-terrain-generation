using System;
using UnityEngine;

namespace Script.Generation.Terrain
{
    [Serializable]
    public class TerrainSettings
    {
        [SerializeField] private TerrainType[] _terrainTypes;

        public TerrainType[] TerrainType => _terrainTypes;
    }
}