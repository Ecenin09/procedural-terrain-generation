using System;
using UnityEngine;

namespace Script.Generation.Terrain.TerrainData
{
    [Serializable]
    public struct TerrainType
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private float _height;
        [SerializeField]
        private Color _color;

        public string Name => _name;
        public float Height => _height;
        public Color Color => _color;
    }
}