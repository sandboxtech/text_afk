
namespace W
{
    public class 昼夜 : ActionStack
    {
        public override bool Visible => true;
        public static 昼夜 Create()
        {
            return Create<昼夜>(new 晚上(), nameof(昼夜));
        }
    }
    public class 昼夜Node : ActionNode
    {
        public override float Duration => GameTime.Day / 2;
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
