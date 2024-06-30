
using System.Collections.Generic;
using UnityEngine;

namespace W
{
    public class 探索 : 自我
    {
        public override void EndAction()
        {
        }

        public override ActionNode Next
        {
            get
            {
                return this;
            }
        }

        public override float Duration => base.Duration * 3;

        public override string Title => "探索中...";

        public override string StartText => "探索文案";

        public readonly static List<string> descriptions = new List<string>()
        {
        };
    }

}
