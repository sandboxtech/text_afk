
using System.Collections.Generic;
using UnityEngine;

namespace W
{
    public class 苏醒 : 自我
    {

        public override void StartAction()
        {
            Game.Data.Hide(nameof(苏醒));
        }
        public override void EndAction()
        {
        }

        public override ActionNode Next
        {
            get
            {
                return new 探索();
            }
        }

        public override float Duration => base.Duration * 4;

        public override string Title => "苏醒中...";

        public override string StartText => RandomTest();

        private static string RandomTest()
        {
            int step = descriptions.Count / 3;

            return $"{descriptions[UnityEngine.Random.Range(0, step)]}\n{descriptions[UnityEngine.Random.Range(step, step * 2)]}\n{descriptions[UnityEngine.Random.Range(step * 2, step * 3)]}";
        }

        public readonly static List<string> descriptions = new List<string>()
    {
"眼前一片模糊，脑海中充满了朦胧的思绪，仿佛仍在梦境中游荡。",
"身体逐渐恢复知觉，四肢微微酸痛，感觉像是经过了一场漫长的旅途。",
"意识逐渐清晰，耳边传来微弱的声音，仿佛风在低声细语。",
"感到一阵轻微的眩晕，四周环境逐渐明朗，仿佛刚从深渊中浮现。",
"心跳加速，呼吸逐渐平稳，仿佛身体重新启动，回到了现实。",
"肌肉僵硬，试图伸展四肢，感觉像是从漫长的冬眠中苏醒。",
"头脑逐渐清醒，周围的景象变得清晰，仿佛重获新生般。",
"感受到温暖的阳光洒在身上，四周充满了自然的气息，仿佛新生。",
"身体微微颤抖，意识逐渐恢复，仿佛从深沉的梦境中挣脱出来。",
"眼前的世界逐渐清晰，心中充满奇异的感觉，仿佛经历了一场神秘的冒险。",
"意识渐渐苏醒，四周环境朦胧不清，仿佛刚从梦境中脱离。",
"肌肉微微酸痛，感到身体重新获得控制，像是从深睡中复苏。",
"呼吸渐渐变得平稳，心跳声清晰可闻，仿佛经历了一场漫长的沉眠。",
"眼前的光线逐渐明亮，感受到一股暖意，仿佛重见天日。",
"脑海一片混沌，思绪缓慢聚拢，身体感受到久违的存在感。",
"感到一阵轻微的眩晕，四肢逐渐恢复知觉，仿佛重生一般。",
"耳边传来细微的声音，仿佛世界重新苏醒，感受到一丝清凉。",
"眼前一片模糊，逐渐看清周围，仿佛从深渊中浮现。",
"身体逐渐恢复温度，感到一阵温暖的包围，仿佛回到了现实。",
"感到一阵寒意，身体微微颤抖，仿佛经历了一场漫长的寒冬。",
"意识逐渐清晰，感受到四周的气息，仿佛重新回到现实世界。",
"感觉自己从深沉的梦境中脱离，四周变得明亮起来。",
"身体微微颤动，肌肉恢复活力，仿佛从长时间的沉睡中苏醒。",
"思绪逐渐聚拢，眼前的景象变得清晰，仿佛重新获得了生命。",
"感到一阵轻微的眩晕，耳边传来微弱的声音，仿佛重新感受到世界的存在。",
"四肢逐渐恢复知觉，感受到温暖的光线，仿佛经历了一场新生。",
"脑海中充满朦胧的记忆，思绪逐渐清晰，感到身体重新获得控制。",
"感到一阵清新的气息，意识逐渐苏醒，仿佛重新回到了现实。",
"眼前的景象逐渐明朗，感到一股暖流涌上心头，仿佛重获新生。",
"身体微微颤抖，感到一阵寒意，意识逐渐恢复，仿佛从梦境中脱离。",
    };
    }

}
