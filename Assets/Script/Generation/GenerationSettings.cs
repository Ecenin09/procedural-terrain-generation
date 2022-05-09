using System;
using UnityEngine;

namespace Script.Generation
{
    [Serializable]
    public class GenerationSettings
    {
        [SerializeField] private Vector2Int _mapSize;
        [SerializeField] private float _scale;

        [Header("Editor Option")] [SerializeField]
        public bool IsAutoUpdate = true;

        public Vector2Int MapSize => _mapSize;

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
    }
}