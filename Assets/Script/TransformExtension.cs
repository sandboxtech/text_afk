
using UnityEngine;
using UnityEngine.UI;

namespace W
{
    public static class TransformExtension
    {

        public static void FadeChildren(this Transform trans)
        {
            int childCount = trans.childCount;
            int i = 0;
            foreach (Transform t in trans)
            {
                float v = 0.875f * Mathf.Pow(0.5f, i);
                Text text = t.GetComponent<Text>();
                if (text != null)
                {
                    text.color = new Color(1, 1, 1, v);
                    i++;
                }
            }
        }

        public static void DestroyAllChildren(this Transform trans)
        {
            foreach (Transform t in trans)
            {
                UnityEngine.Object.Destroy(t.gameObject);
            }
            trans.DetachChildren();
        }

        public static void DestroryExcessChildren(this Transform trans, int count)
        {
            int childCount = trans.childCount;

            if (childCount > count)
            {
                for (int i = childCount - 1; i >= count; i--)
                {
                    Transform child = trans.GetChild(i);
                    child.SetParent(null);
                    UnityEngine.Object.Destroy(child.gameObject);
                }
            }
        }

    }
}
