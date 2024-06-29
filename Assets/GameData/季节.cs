
namespace W
{
    public class 季节 : ActionStack
    {
        public override bool Visible => false;
        public static 季节 Create()
        {
            季节 stack = Create<季节>(new 夏季());
            stack.Name = nameof(季节);
            return stack;
        }
    }
    public class 季节Node : ActionNode
    {
        public override float Duration => 30;
    }
    public class 夏季 : 季节Node
    {
        public override ActionNode Next => new 冬季();
    }

    public class 冬季 : 季节Node
    {
        public override ActionNode Next => new 夏季();
    }
}
