
namespace W
{
    public class 白天 : ActionNode
    {
        public override ActionNode Next => new 晚上();
    }

    public class 晚上 : ActionNode
    {
        public override ActionNode Next => new 白天();
    }
}
