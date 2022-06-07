using UnityEngine;

namespace Script.Generation.Terrain.TerrainData
{
    public class TerrainChunk
    {
        private Vector2 _position;
        private GameObject _meshObject;
        private Bounds _bounds;

        public bool IsVisible => _meshObject.activeSelf;
        public TerrainChunk(Vector2 coord, int size, Transform parent)
        {
            _position = coord * size;
            _bounds = new Bounds(_position, Vector3.one * size);
            var localMeshScale = Vector3.one * size;
            
            Vector3 positionInSpace = new Vector3(_position.x, 0, _position.y);
            
            _bounds = new Bounds(_position, localMeshScale);
            _meshObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
            _meshObject.transform.SetParent(parent);
            _meshObject.transform.position = positionInSpace;
            _meshObject.transform.localScale = localMeshScale / 10f;
        }

        public TerrainChunk UpdateTerrainChunk(Vector2 viewerPosition, float maxViewDistance)
        {
            float viewerDistanceNearestEdge = _bounds.SqrDistance(viewerPosition);

            bool isVisible = viewerDistanceNearestEdge <= Mathf.Pow(maxViewDistance ,2f);

            SetVisible(isVisible);

            return this;
        }

        public void SetVisible(bool state)
        {
            _meshObject.SetActive(state);
        }
    }
}