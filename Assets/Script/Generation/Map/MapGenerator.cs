using System;
using Script.Generation.NoiseRealization;
using UnityEditor;
using UnityEngine;


namespace Script.Generation.Map
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private GenerationSettings _settings;
        [SerializeField] private MapDisplay _mapDisplay;

        public GenerationSettings Settings => _settings;

        private void GenerateMap()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(_settings);
            _mapDisplay.DrawNoiseMap(noiseMap);
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
    }
}