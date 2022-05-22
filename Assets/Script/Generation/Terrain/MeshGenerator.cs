using UnityEngine;

namespace Script.Generation.Terrain
{
    public class MeshGenerator
    {
        public static MeshData GenerateTerrainMesh(float[,] heightMap, TerrainSettings terrainSettings)
        {
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);
            
            int meshSimplificationIncrement = terrainSettings.LevelOfDetail <= 0 ? 1 : terrainSettings.LevelOfDetail;
            int verticesPerLine = (width - 1) / meshSimplificationIncrement + 1;
            
            var heightCurve = terrainSettings.MeshHeightCurve;
            var heightMultiplier = terrainSettings.MeshHeightMultiplier;

            float topLeftX = (width - 1) / -2f;
            float topLeftZ = (height - 1) / 2f;

            MeshData meshData = new MeshData(verticesPerLine, verticesPerLine);
            int vertexIndex = 0;

            for (int y = 0; y < height; y += meshSimplificationIncrement)
            {
                for (int x = 0; x < width; x += meshSimplificationIncrement)
                {
                    meshData.Vertices[vertexIndex] = new Vector3(topLeftX+x, heightCurve.Evaluate(heightMap[x, y]) * heightMultiplier, topLeftZ - y);
                    meshData.UVs[vertexIndex] = new Vector2(x / (float) width, y / (float) height);

                    if (x < width - 1 && y < height - 1)
                    {
                        meshData.AddTriangle(vertexIndex, vertexIndex+verticesPerLine+1, vertexIndex+verticesPerLine);
                        meshData.AddTriangle(vertexIndex+verticesPerLine+1, vertexIndex, vertexIndex+1);
                    }
                    
                    vertexIndex++;
                }
            }

            return meshData;
        }
    }
}