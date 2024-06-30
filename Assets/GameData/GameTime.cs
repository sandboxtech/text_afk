
using UnityEngine;

namespace W
{
    public static class GameTime
    {
        public static int Hour = 1;
        public static int Day = 24 * Hour;
        public static int Month = 30 & Day;
        public static int Year = 12 * Month;
    }
}
