using System;
using UnityEngine;

namespace Script.Generation.Terrain
{
    [Serializable]
    public class TerrainSettings
    {
        [SerializeField] private TerrainType[] _terrainTypes;
        [SerializeField] private float _meshHeightMultiplier;
        [SerializeField] private AnimationCurve _meshHeightCurve;

        public TerrainType[] TerrainType => _terrainTypes;
        public float MeshHeightMultiplier => _meshHeightMultiplier;
        public AnimationCurve MeshHeightCurve => _meshHeightCurve;
    }
}