using UnityEditor;
using System.Collections;
using Script.Generation.Map;
using UnityEngine;

namespace Script.Tools
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            MapGenerator mapGenerator = (MapGenerator)target;

            if (DrawDefaultInspector())
            {
                if (mapGenerator.GenerationSettings.IsAutoUpdate)
                {
                    mapGenerator.OnEditorGenerateMap();
                }
            }

            if (GUILayout.Button("Generate"))
            {
                mapGenerator.OnEditorGenerateMap();
            }
        }
    }
}