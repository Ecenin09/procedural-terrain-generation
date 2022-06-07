using System;
using System.Collections.Generic;
using Script.Generation.Terrain.TerrainData;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Generation.Terrain
{
    public class EndlessTerrain : MonoBehaviour
    {
        public const float MAX_VIEW_DISTANCE = 250f;

        [SerializeField] private Transform _viewer;
        [SerializeField] private Transform _chunkParent;

        private Vector2 _viwerPosition;
        private int _chunkSize;
        private int _chunkVisibleInViewDistance;

        private Dictionary<Vector2, TerrainChunk> _terrainChunks = new Dictionary<Vector2, TerrainChunk>();
        private List<TerrainChunk> _terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

        private void Start()
        {
            _chunkSize = GenerationSettings.CHUNK_SIZE - 1;
            _chunkVisibleInViewDistance = Mathf.RoundToInt(MAX_VIEW_DISTANCE / _chunkSize);
        }

        private void Update()
        {
            _viwerPosition = new Vector2(_viewer.position.x, _viewer.position.z);
            UpdateVisibleChunk();
        }

        private void UpdateVisibleChunk()
        {
            DisableLastVisibleChunks();

            Vector2Int currentChunkPosition = new Vector2Int(Mathf.RoundToInt(_viwerPosition.x / _chunkSize),
                Mathf.RoundToInt(_viwerPosition.y / _chunkSize));

            for (int yOffset = -_chunkVisibleInViewDistance; yOffset <= _chunkVisibleInViewDistance; yOffset++)
            {
                for (int xOffset = -_chunkVisibleInViewDistance; xOffset <= _chunkVisibleInViewDistance; xOffset++)
                {
                    Vector2 viewedChunkCoord =
                        new Vector2(currentChunkPosition.x + xOffset, currentChunkPosition.y + yOffset);
                    ShowTerrainChunk(viewedChunkCoord, ref _terrainChunks);
                }
            }
        }

        private void ShowTerrainChunk(Vector2 viewedChunkCoord, ref Dictionary<Vector2, TerrainChunk> terrainChunks)
        {
            if (terrainChunks.ContainsKey(viewedChunkCoord))
            {
                var chunk = terrainChunks[viewedChunkCoord].UpdateTerrainChunk(_viwerPosition, MAX_VIEW_DISTANCE);

                if (chunk.IsVisible)
                {
                    _terrainChunksVisibleLastUpdate.Add(chunk);
                }
            }
            else
            {
                terrainChunks.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, _chunkSize, _chunkParent));
            }
        }

        private void DisableLastVisibleChunks()
        {
            if (_terrainChunksVisibleLastUpdate != null)
            {
                foreach (var chunk in _terrainChunksVisibleLastUpdate)
                {
                    chunk.SetVisible(false);
                }

                _terrainChunksVisibleLastUpdate.Clear();
            }
        }
    }
}