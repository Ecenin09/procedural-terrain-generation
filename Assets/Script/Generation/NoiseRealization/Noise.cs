using System;
using UnityEngine;

namespace Script.Generation.NoiseRealization
{
    public static class Noise
    {
        public static float[,] GenerateNoiseMap(GenerationSettings settings)
        {
            float[,] resultNoiseMap = new float[settings.MapSize.x, settings.MapSize.y];

            Vector2[] octaveOffsets = new Vector2[settings.Octaves];
            for (int i = 0; i < settings.Octaves; i++)
            {
                float offsetX = GetOffset(settings.Seed) + settings.Offset.x;
                float offsetY = GetOffset(settings.Seed) + settings.Offset.y;

                octaveOffsets[i] = new Vector2(offsetX, offsetY);
            }

            float maxNoiseHeight = float.MinValue;
            float minNoiseHeight = float.MaxValue;

            for (int y = 0; y < settings.MapSize.y; y++)
            {
                for (int x = 0; x < settings.MapSize.x; x++)
                {
                    float amplitude = 1;
                    float frequency = 1;
                    float noiseHeigth = 0;

                    for (int i = 0; i < settings.Octaves; i++)
                    {
                        float sampleX = (x - settings.HalfMapSize.x) / settings.Scale * frequency + octaveOffsets[i].x;
                        float sampleY = (y - settings.HalfMapSize.y) / settings.Scale * frequency + octaveOffsets[i].y;

                        float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                        noiseHeigth += perlinValue * amplitude;

                        amplitude *= settings.Persistance;
                        frequency *= settings.Lacunarity;

                        resultNoiseMap[x, y] = perlinValue;
                    }

                    if (noiseHeigth > maxNoiseHeight)
                    {
                        maxNoiseHeight = noiseHeigth;
                    }
                    else if (noiseHeigth < minNoiseHeight)
                    {
                        minNoiseHeight = noiseHeigth;
                    }

                    resultNoiseMap[x, y] = noiseHeigth;
                }
            }

            for (int y = 0; y < settings.MapSize.y; y++)
            {
                for (int x = 0; x < settings.MapSize.x; x++)
                {
                    resultNoiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, resultNoiseMap[x, y]);
                }
            }

            return resultNoiseMap;
        }


        private static float GetOffset(int seed)
        {
            System.Random random = new System.Random(seed);

            return random.Next(-10000, 10000);
        }
    }
}