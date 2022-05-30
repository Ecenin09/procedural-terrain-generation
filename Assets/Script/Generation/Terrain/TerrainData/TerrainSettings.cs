using System;
using UnityEngine;

namespace Script.Generation.Terrain.TerrainData
{
    [Serializable]
    public class TerrainSettings
    {
        [Range(0,6)]
        [SerializeField] private int _levelOfDetail;
        [Space]
        [SerializeField] private float _meshHeightMultiplier;
        [SerializeField] private AnimationCurve _meshHeightCurve;
        [Space]
        [SerializeField] private TerrainType[] _terrainTypes;

        public TerrainType[] TerrainType => _terrainTypes;
        public float MeshHeightMultiplier => _meshHeightMultiplier;
        public AnimationCurve MeshHeightCurve => _meshHeightCurve;
        public int LevelOfDetail => _levelOfDetail;
    }
}