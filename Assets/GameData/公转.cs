
namespace W
{
    public class 夏季 : ActionNode
    {
        public override ActionNode Next => new 冬季();
    }

    public class 冬季 : ActionNode
    {
        public override ActionNode Next => new 夏季();
    }
}
