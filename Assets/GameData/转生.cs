
using System.Collections.Generic;
using System.Diagnostics;
namespace W
{
    public class 转生 : 自我
    {
        public override void StartAction()
        {
            if (TimesDone >= 3)
            {
                Game.Data.Show(nameof(苏醒));
            }
        }

        public override ActionNode Next
        {
            get
            {
                if (Game.Data.EnabledActions.Contains(nameof(苏醒)))
                {
                    return new 苏醒();
                }
                return this;
            }
        }

        public override string Title => "转生中...";

        public override string StartText => descriptions[UnityEngine.Random.Range(0, descriptions.Count)];

        public readonly static List<string> descriptions = new List<string>()
    {
"世界仿佛变得不真实，所有事物都变得模糊。",
"世界变得模糊，所有事物都变得不再真实。",
"世界变得虚幻，所有事物都不再真实。",
"世界变得虚幻而不真实。",
"仿佛置身于一个无边无际的黑暗中，找不到方向。",
"仿佛进入了一个新世界，每一步都充满陌生。",
"仿佛进入了一个永无止境的梦境，无法醒来。",
"像是在水中漂浮，身体变得轻盈而无力。",
"像是进入了一个新世界，每一步都充满陌生。",
"像是进入了一个永无止境的梦魇，无法挣脱。",
"内心充满了不安，仿佛随时会发生什么。",
"内心充满了对现状的疑惑。",
"内心充满了挣扎，试图找回失去的记忆。",
"内心充满了挣扎。",
"内心充满了焦虑，不知未来会发生什么。",
"内心充满困惑，不知何处是归宿，何处是陌生。",
"内心涌起无尽的空虚，找不到存在的意义。",
"内心深处有一种被遗弃的感觉。",
"内心深处涌起一种无尽的孤独。",
"内心深处涌起一种无尽的悲伤。",
"内心深处涌起一种莫名的恐惧，无法摆脱。",
"内心深处涌起一阵阵莫名的悲伤。",
"双眼失去焦点，眼前一片模糊。",
"双眼迷蒙，光影交错，找不到现实与梦境的界限。",
"双脚似乎触碰不到地面，一种飘浮的感觉挥之不去。",
"周围一片黑暗，仿佛世界都消失了。",
"四周寂静，耳畔只余心跳，脑海一片空白。",
"四肢仿佛被锁住，无法自由活动。",
"失重感袭来，仿佛失去了地心引力，无处安放自己。",
"尝试移动身体，却发现四肢僵硬，无法动弹。",
"心中充满了对未来的未知与恐惧。",
"心中充满了对现状的疑惑，找不到答案。",
"心中充满了无尽的疑问，却找不到答案。",
"心中充满了无尽的疑问。",
"心中充满了未解的谜团，找不到答案。",
"心中涌起无尽的迷茫，仿佛失去了方向。",
"心中涌起莫名的孤独，仿佛置身于无尽的虚空。",
"心头涌起一阵阵寒意，仿佛有未知的危险在靠近。",
"心跳加速，不安感蔓延全身，似乎缺少归属。",
"思绪仿佛被困住，无法集中注意力。",
"思绪仿佛被困住。",
"思绪混乱，仿佛身处梦境，无法分辨真假。",
"思绪被一种无形的力量牵引，无法集中。",
"思绪被一种无形的力量牵引。",
"恐慌渐起，四肢无力，渴望抓住什么却空无一物。",
"感到一种莫名的力量在操控。",
"感到一股强烈的孤独，仿佛全世界只剩下自己。",
"感到一股无法名状的力量在操控自己。",
"感到一阵阵寒意从心底升起，无法驱散。",
"感到一阵阵寒意从脚底升起。",
"感到一阵阵无力，仿佛身体被掏空。",
"感到一阵阵的无力，仿佛身体被掏空。",
"感到一阵阵的晕眩，仿佛失去了平衡。",
"感到周围的一切都在远离，自己孤身一人。",
"感到心跳加速，无法平复。",
"感到自己在一个无尽的隧道中，找不到出口。",
"感到自己在一个无尽的黑暗中。",
"感到自己在一个无边无际的梦境中。",
"感到自己在不断下沉，仿佛被黑暗吞噬。",
"感到自己在不断下沉。",
"感到身体失去了控制，无法自由活动。",
"感到身体失去了控制。",
"感到身体被一种无形的力量拉扯，无法挣脱。",
"感觉自己在一个无尽的隧道中，找不到出口。",
"感觉自己在一个陌生的环境中。",
"感觉自己的意识在逐渐消散，无法掌控。",
"感觉自己的意识在逐渐消散。",
"感觉身体被一种力量控制。",
"感觉身体被一种无形的力量牵引，无法自主行动。",
"所有声音仿佛都消失了，只剩下自己孤独的心跳。",
"所有声音仿佛都消失了。",
"所有记忆仿佛被抹去，脑海一片空白。",
"无声的世界，耳边响起自己呼吸声。",
"时间仿佛静止，周围一切都在慢慢解体与重组。",
"每一秒都变得漫长，仿佛时间停滞不前。",
"眼前景象如幻影般变换，无法抓住任何实物。",
"眼前模糊，仿佛蒙上了一层迷雾，无法看清。",
"眼前的世界不断变换，无法适应。",
"耳边传来低语声，无法分辨来源。",
"耳边传来奇异的低语，无法辨别内容。",
"耳边传来奇怪的低语，无法分辨来源。",
"耳边传来奇怪的低语声，无法辨别内容。",
"耳边传来奇怪的声音，仿佛有人在低语。",
"耳边传来奇怪的声音。",
"耳边传来细微的声音，仿佛有人在耳语。",
"脑海中闪过无数模糊的影像，却无法记起。",
"脑海中闪过无数模糊的影像，却无法记起任何细节。",
"脑海中闪过无数模糊的影像。",
"记忆如同被风吹散，无法集中。",
"记忆模糊，过去的影像若隐若现，难以捉摸。",
"试图呼吸，却感到空气稀薄，难以为继。",
"试图呼喊，却发不出声音。",
"试图呼喊，却发现声音无法发出，喉咙仿佛被堵住。",
"试图寻找答案，却找不到任何线索。",
"试图移动，却发现身体僵硬。",
"身体仿佛漂浮在空中，无处依靠。",
"身体仿佛被冻住，感到彻骨的寒冷。",
"身体仿佛被束缚住，无法自由活动。",
"身体轻盈，仿佛飘浮在空气中，无法辨别方向。",
"迷茫无助，陌生环境包围，内心充满疑惑。",
    };

    }

}