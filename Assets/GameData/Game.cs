
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SocialPlatforms;

namespace W
{

    [JsonObject(MemberSerialization.OptOut)]
    public class Game
    {
        public static Game Data { get; private set; }

        // 行
        [JsonProperty]
        public HashSet<string> Showns; // 是否启用。程序自动决定是否展示

        public void Show(string name) => SetShown(name, true);
        public void Hide(string name) => SetShown(name, false);

        private void SetShown(string name, bool shown)
        {
            Showns.MySet(name, shown);
            OnShownsChange(name, shown);
        }
        public Action<string, bool> OnShownsChange { private get; set; }

        [JsonProperty]
        public HashSet<string> Enables; // 是否启用。程序自动决定是否展示
        public void Enable(string name) => Enables.MySet(name, true);
        public void Disable(string name) => Enables.MySet(name, false);


        [JsonProperty]
        private int ActiveStackIndex { get; set; }
        [JsonIgnore]
        public ActionStack ActiveActionStack { get => Stacks[ActiveStackIndex]; }
        [JsonProperty]
        public List<ActionStack> Stacks { get; private set; }


        // 思
        [JsonProperty]
        Dictionary<string, int> GameStatus;

        public void Initialize()
        {
            if (Data != null) { throw new Exception(); }
            Data = this;

            Showns = new HashSet<string>();
            Enables = new HashSet<string>();

            ActiveStackIndex = 0;
            Stacks = new List<ActionStack>();

            Stacks.Add(ActionStack.Create(new 转生()));
            Stacks.Add(ActionStack.Create(new 夏季()));
            Stacks.Add(ActionStack.Create(new 晚上()));

            GameStatus = new Dictionary<string, int>();
        }

    }
}


