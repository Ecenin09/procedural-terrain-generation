using System;
using UnityEngine;

namespace Script.Generation
{
    [Serializable]
    public class GenerationSettings
    {
        [SerializeField] private Vector2Int _mapSize;
        [SerializeField] private float _scale;
        [SerializeField] private int _octaves;
        [Range(0,1)]
        [SerializeField] private float _persistance;
        [SerializeField] private float _lacunarity;
        [SerializeField] private int _seed;
        [SerializeField] private Vector2 _offset;

        [Header("Editor Option")] [SerializeField]
        public bool IsAutoUpdate = true;

        public Vector2Int MapSize
        {
            get
            {
                _mapSize.x = _mapSize.x < 1 ? 1 : _mapSize.x;
                _mapSize.y = _mapSize.y < 1 ? 1 : _mapSize.y;
                return _mapSize;
            }
        }

        public float Scale
        {
            get
            {
                if (_scale <= 0)
                {
                    _scale = 0.0001f;
                }

                return _scale;
            }
        }

        public int Octaves
        {
            get
            {
                return _octaves < 0 ? 0 : _octaves;
            }
        }

        public float Persistance => _persistance;
        public float Lacunarity => _lacunarity;
        public int Seed => _seed;
        public Vector2 Offset => _offset;
        public Vector2 HalfMapSize
        {
            get
            {
                return new Vector2(_mapSize.x/2f,_mapSize.y/2f);
            }
        }
    }
}