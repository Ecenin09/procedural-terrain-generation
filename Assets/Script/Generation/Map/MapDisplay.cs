using System;
using UnityEngine;

namespace Script.Generation.Map
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public void DrawTexture(Texture2D texture2D)
        {
            _renderer.sharedMaterial.mainTexture = texture2D;
            _renderer.transform.localScale = new Vector3(texture2D.width, 1, texture2D.height);
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