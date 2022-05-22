using System;
using UnityEngine;

namespace Script.Generation
{
    [Serializable]
    public class GenerationSettings
    {
        // _mapSize must be less then 255x255 by the engine restriction
        // for one mesh allow max 65025 vertices
        public const int CHUNK_SIZE = 241;
        [SerializeField] private bool _isUsedConstSize = true;
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
                if (_isUsedConstSize)
                {
                    _mapSize.x = CHUNK_SIZE;
                    _mapSize.y = CHUNK_SIZE;
                }
                else
                {
                    _mapSize.x = _mapSize.x < 1 ? 1 : _mapSize.x;
                    _mapSize.y = _mapSize.y < 1 ? 1 : _mapSize.y;
                }
                
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
                return new Vector2(MapSize.x/2f,MapSize.y/2f);
            }
        }
    }
}