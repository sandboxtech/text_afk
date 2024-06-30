
namespace W
{
    public class 季节 : ActionStack
    {
        public override bool Visible => true;
        public static 季节 Create()
        {
            return Create<季节>(new 夏季(), nameof(季节));
        }
    }
    public class 季节Node : ActionNode
    {
        public override float Duration => GameTime.Year / 2;
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
