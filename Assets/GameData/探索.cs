
using System.Collections.Generic;
using UnityEngine;

namespace W
{
    public class ̽�� : ����
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

        public override string Title => "̽����...";

        public override string StartText => "̽���İ�";

        public readonly static List<string> descriptions = new List<string>()
        {
        };
    }

}
