
using UnityEditor;
using UnityEngine;
using System.IO;

namespace W
{
    public class RenameFile : MonoBehaviour
    {
        public string prefix;

        public Object[] objects;

        [ContextMenu("Rename")]
        public void Rename()
        {
            if (string.IsNullOrEmpty(prefix))
            {
                Debug.LogWarning("null");
                return;
            }
            for (int i = 0; i < objects.Length; i++)
            {
                string fullPath = AssetDatabase.GetAssetPath(objects[i]);
                string name = Path.GetFileName(fullPath);
                string path = Path.GetDirectoryName(fullPath);

                string newName = $"{prefix}_{name}";

                AssetDatabase.RenameAsset(fullPath, newName);
            }

            objects = null;
            prefix = null;
        }
    }
}
