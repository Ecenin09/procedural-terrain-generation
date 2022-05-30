using System;
using Script.Generation.Terrain;
using Script.Generation.Terrain.TerrainMesh;
using UnityEngine;

namespace Script.Generation.Map
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private MeshRenderer _meshRenderer;

        public void DrawTexture(Texture2D texture2D)
        {
            _renderer.sharedMaterial.mainTexture = texture2D;
            _renderer.transform.localScale = new Vector3(texture2D.width, 1, texture2D.height);
        }

        public void DrawMesh(MeshData meshData, Texture2D texture2D)
        {
            _meshFilter.sharedMesh = meshData.CreatMesh();
            _meshRenderer.sharedMaterial.mainTexture = texture2D;
        }

        private void OnValidate()
        {
            if (_renderer == null)
            {
                TryGetComponent(out _renderer);
            }

            if (_meshFilter == null)
            {
                TryGetComponent(out _meshFilter);
            }

            if (_meshRenderer == null)
            {
                TryGetComponent(out _meshRenderer);
            }
        }
    }
    
}