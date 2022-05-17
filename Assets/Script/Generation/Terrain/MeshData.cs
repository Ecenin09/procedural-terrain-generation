using UnityEngine;

namespace Script.Generation.Terrain
{
    public class MeshData
    {
        private Vector3[] _vertices;
        private int[] _triangles;
        private Vector2[] _uvs;

        private int trianglesIndex;

        public Vector3[] Vertices => _vertices;
        public int[] Triangles => _triangles;
        public Vector2[] UVs => _uvs;
        
        public MeshData(int meshWidth, int meshHeight)
        {
            _vertices = new Vector3[meshWidth * meshHeight];
            _uvs = new Vector2[meshWidth * meshHeight];
            _triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
        }

        public void AddTriangle(int a, int b, int c)
        {
            _triangles[trianglesIndex] = a;
            _triangles[trianglesIndex+1] = b;
            _triangles[trianglesIndex+2] = c;

            trianglesIndex += 3;
        }

        public Mesh CreatMesh()
        {
            Mesh mesh = new Mesh();
            
            mesh.vertices = _vertices;
            mesh.triangles = _triangles;
            mesh.uv = _uvs;
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}