
using UnityEngine;

namespace W
{
    public class 月相 : ActionStack
    {
        public static 月相 Create()
        {
            return Create<月相>(new 上弦(), nameof(月相));
        }
    }
    public class 月相Node : ActionNode
    {
        public override float Duration => GameTime.Month / 2;
    }
    public class 上弦 : 季节Node
    {
        public override ActionNode Next => new 下弦();
    }

    public class 下弦 : 季节Node
    {
        public override ActionNode Next => new 上弦();
    }
}
