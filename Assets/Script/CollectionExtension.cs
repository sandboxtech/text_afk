
using System.Collections.Generic;
using UnityEngine;

namespace W
{
    public static class CollectionExtension
    {
        public static void MySet(this HashSet<string> set, string key, bool b)
        {
            if (set.Contains(key))
            {
                if (!b)
                {
                    set.Remove(key);
                }
            }
            else
            {
                if (b)
                {
                    set.Add(key);
                }
            }
        }
        public static void AddFilterNull(this List<string> list, string str)
        {
            if (str == null)
            {
                return;
            }
            list.Add(str);
        }
    }
}
