using System;
using UnityEngine;

namespace Script.Generation.Terrain
{
    public class EndlessTerrain : MonoBehaviour
    {
        public const float MAX_VIEW_DISTANCE = 300f;

        [SerializeField] private Transform viewer;

        private Vector2 _viwerPosition;
        private int _chunkSize;
        private int _chunkVisibleInViewDistance;

        private void Start()
        {
            _chunkSize = GenerationSettings.CHUNK_SIZE - 1;
            _chunkVisibleInViewDistance = Mathf.RoundToInt(MAX_VIEW_DISTANCE / _chunkSize);
        }

        private void UpdateVisibleChunk()
        {
            Vector2Int currentChunkPosition = new Vector2Int(Mathf.RoundToInt(_viwerPosition.x / _chunkSize),
                Mathf.RoundToInt(_viwerPosition.y / _chunkSize));

            for (int yOffset = -_chunkVisibleInViewDistance; yOffset <= _chunkVisibleInViewDistance; yOffset++)
            {
                for (int xOffset = -_chunkVisibleInViewDistance; xOffset <= _chunkVisibleInViewDistance; xOffset++)
                {
                    Vector2 viewedChunkCoord =
                        new Vector2(currentChunkPosition.x + xOffset, currentChunkPosition.y + yOffset);
                }
            }
        }
    }
}