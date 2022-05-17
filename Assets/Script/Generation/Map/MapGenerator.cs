using System;
using Script.Generation.NoiseRealization;
using Script.Generation.Terrain;
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

            Texture2D noiseTexture = TextureGenerator.TexruteFromHeightMap(noiseMap);
            Texture2D colorTexture = TextureGenerator.TextureFromColorMap(colorMap, _generationSettings.MapSize);
            
            if (_drawMode == DrawMode.NoiseMap)
            {
                _mapDisplay.DrawTexture(noiseTexture);
            }
            else if(_drawMode == DrawMode.ColorMap)
            {
                _mapDisplay.DrawTexture(colorTexture);
            }
            else if (_drawMode == DrawMode.Mesh)
            {
                _mapDisplay.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, _terrainSettings), colorTexture);
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