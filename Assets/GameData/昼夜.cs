
namespace W
{
    public class 昼夜 : ActionStack
    {
        public override bool Visible => true;
        public static 昼夜 Create()
        {
            昼夜 stack = Create<昼夜>(new 晚上());
            stack.Name = nameof(昼夜);
            return stack;
        }
    }
    public class 昼夜Node : ActionNode
    {
        public override float Duration => 8;
    }
    public class 白天 : ActionNode
    {
        public override ActionNode Next => new 晚上();
    }

    public class 晚上 : ActionNode
    {
        public override ActionNode Next => new 白天();
    }
}
