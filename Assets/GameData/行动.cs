
using UnityEngine;

namespace W
{
    public class 行动 : ActionStack
    {
        public override bool Visible => false;
        public static 行动 Create()
        {
            行动 stack = Create<行动>(new 转生());
            stack.Name = nameof(行动);
            return stack;
        }
    }
}
