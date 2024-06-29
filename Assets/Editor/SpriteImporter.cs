using UnityEditor;
using UnityEngine;

public class SpriteImporter : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.mipmapEnabled = false;
        textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        textureImporter.filterMode = FilterMode.Point;
        textureImporter.wrapMode = TextureWrapMode.Clamp;
        textureImporter.spritePixelsPerUnit = 16;
    }
    void OnPostprocessTexture(Texture2D texture)
    {

    }
}