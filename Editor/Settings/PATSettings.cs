using UnityEngine;

namespace PAT
{
    [
        CreateAssetMenu(
            fileName = "PixelArtTextureSettings",
            menuName = "PixelArtPostProcessor/Settings"
        )
    ]
    public class PATSettings : ScriptableObject
    {
        [HideInInspector]
        public bool isActive = false;

        [Header(header: "Base Settings")]
        public int PPU = 32;
        public int minTextureSize = 32;
        public bool isReadable = true;
        public int postProcessOrder;

        [Header(header: "Main Paths")]
        public string[] includePaths;
        public string[] excludePaths;

        [Header(header: "Full Rect Mesh Type")]
        public string[] fullRectMeshSubstrings;
        public string[] fullRectMeshPaths;

        [Header(header: "Multiple Sprite Mode")]
        public string[] multipleSpriteModeSubstrings;
        public string[] multipleSpriteModePaths;
    }
}
