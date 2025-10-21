using UnityEngine;

namespace PAT
{
    [
        CreateAssetMenu(
            fileName = PAT_Const.Strings.CreateAssetMenu.fileName,
            menuName = PAT_Const.Strings.CreateAssetMenu.menuName
        )
    ]
    public class PATSettings : ScriptableObject
    {
        [HideInInspector]
        public bool isActive = false;

        [Header(header: PAT_Const.Strings.Headers.baseSettings)]
        public int PPU = 32;
        public int minTextureSize = 32;
        public bool isReadable = true;
        public int postProcessOrder;

        [Header(header: PAT_Const.Strings.Headers.mainPaths)]
        public string[] includePaths;
        public string[] excludePaths;

        [Header(header: PAT_Const.Strings.Headers.fullRectMeshType)]
        public string[] fullRectMeshSubstrings;
        public string[] fullRectMeshPaths;

        [Header(header: PAT_Const.Strings.Headers.multipleSpriteMode)]
        public string[] multipleSpriteModeSubstrings;
        public string[] multipleSpriteModePaths;
    }
}
