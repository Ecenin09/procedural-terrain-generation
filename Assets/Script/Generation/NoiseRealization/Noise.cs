
using UnityEngine;

namespace Script.Generation.NoiseRealization
{
    public static class Noise
    {
        public static float[,] GenerateNoiseMap(GenerationSettings settings)
        {
            float[,] resultNoiseMap = new float[settings.MapSize.x, settings.MapSize.y];
            float scale = settings.Scale;

            for (int y = 0; y < settings.MapSize.y; y++)
            {
                for (int x = 0; x < settings.MapSize.x; x++)
                {
                    float sampleX = x / scale;
                    float sampleY = y / scale;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);

                    resultNoiseMap[x, y] = perlinValue;
                }
            }

            return resultNoiseMap;
        }
    }
}
