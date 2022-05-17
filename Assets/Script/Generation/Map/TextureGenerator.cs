using UnityEngine;

namespace Script.Generation.Map
{
    public static class TextureGenerator
    {
        public static Texture2D TextureFromColorMap(Color[] colorMap, Vector2Int mapSize)
        {
            Texture2D texture2D = new Texture2D(mapSize.x, mapSize.y);
            texture2D.filterMode = FilterMode.Point;
            texture2D.wrapMode = TextureWrapMode.Clamp;
            texture2D.SetPixels(colorMap);
            texture2D.Apply();
            return texture2D;
        }

        public static Texture2D TexruteFromHeightMap(float[,] heightMap)
        {
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);

            Texture2D texture2D = new Texture2D(width, height);

            Color[] colorMap = new Color[width * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
                }
            }

            return TextureFromColorMap(colorMap, new Vector2Int(width,height));
        }
    }
}