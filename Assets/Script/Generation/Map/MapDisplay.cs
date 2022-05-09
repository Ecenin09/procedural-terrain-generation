using System;
using UnityEngine;

namespace Script.Generation.Map
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public void DrawNoiseMap(float[,] noiseMap)
        {
            int width = noiseMap.GetLength(0);
            int height = noiseMap.GetLength(1);

            Texture2D texture2D = new Texture2D(width, height);

            Color[] colorMap = new Color[width * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
                }
            }

            texture2D.SetPixels(colorMap);
            texture2D.Apply();

            _renderer.sharedMaterial.mainTexture = texture2D;
            _renderer.transform.localScale = new Vector3(width, 1, height);
        }

        private void OnValidate()
        {
            if (_renderer == null)
            {
                TryGetComponent(out _renderer);
            }
        }
    }
    
}