using System;
using Script.Generation.NoiseRealization;
using Script.Generation.Terrain;
using Script.Generation.Terrain.TerrainData;
using Script.Generation.Terrain.TerrainMesh;
using UnityEditor;
using UnityEngine;


namespace Script.Generation.Map
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private GenerationSettings _generationSettings;
        [SerializeField] private TerrainSettings _terrainSettings;
        [SerializeField] private MapDisplay _mapDisplay;

        [SerializeField] 
        private DrawMode _drawMode;
        public GenerationSettings GenerationSettings => _generationSettings;
        public TerrainSettings TerrainSettings => _terrainSettings;

        private void GenerateMap()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(_generationSettings);

            Color[] colorMap = new Color[_generationSettings.MapSize.x * _generationSettings.MapSize.y];

            for (int y = 0; y < _generationSettings.MapSize.y; y++)
            {
                for (int x = 0; x < _generationSettings.MapSize.x; x++)
                {
                    float currentHeight = noiseMap[x, y];
                    for (int i = 0; i < _terrainSettings.TerrainType.Length; i++)
                    {
                        if (currentHeight <= _terrainSettings.TerrainType[i].Height)
                        {
                            colorMap[y * _generationSettings.MapSize.x + x] = _terrainSettings.TerrainType[i].Color;
                            break;
                        }
                    }
                }
            }
            
            DrawMap(noiseMap,colorMap);
        }

        private void DrawMap(float[,] noiseMap, Color[] colorMap)
        {
            Texture2D noiseTexture = TextureGenerator.TexruteFromHeightMap(noiseMap);
            Texture2D colorTexture = TextureGenerator.TextureFromColorMap(colorMap, _generationSettings.MapSize);
            MeshData generatedMeshData = MeshGenerator.GenerateTerrainMesh(noiseMap, _terrainSettings);
            
            switch (_drawMode)
            {
                case DrawMode.NoiseMap:
                    _mapDisplay.DrawTexture(noiseTexture);
                    break;
                case DrawMode.ColorMap:
                    _mapDisplay.DrawTexture(colorTexture);
                    break;
                case DrawMode.Mesh:
                    _mapDisplay.DrawMesh(generatedMeshData, colorTexture);
                    break;
                default:
                    Debug.LogWarning($"[{nameof(MapGenerator)}][{nameof(GenerateMap)}] unknown state for draw map");
                    break;
            }
        } 


        public void OnEditorGenerateMap()
        {
            GenerateMap();
        }
        
        private void OnValidate()
        {
            if (_mapDisplay == null)
            {
                _mapDisplay = FindObjectOfType<MapDisplay>();
            }
        }
        
        public enum DrawMode
        {
            NoiseMap,
            ColorMap,
            Mesh
        }
    }
}