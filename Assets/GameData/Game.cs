
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace W
{
    public enum UIState
    {
        无 = 0,
        行 = 1,
        观 = 2,
        思 = 3,
        眠 = 4,
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Game
    {
        public static Game Data { get; private set; }

        [JsonProperty]
        private UIState uiState { get; set; }
        [JsonIgnore]
        public UIState UIState
        {
            get => uiState; set
            {
                OnExitState?.Invoke(uiState);
                uiState = value;
                OnEnterState?.Invoke(uiState);
            }
        }


        [JsonIgnore]
        public Action<UIState> OnEnterState { private get; set; }
        [JsonIgnore]
        public Action<UIState> OnExitState { private get; set; }

        // 行
        [JsonProperty]
        public HashSet<string> ShownActions; // 是否启用。程序自动决定是否展示

        public void Show(string name) => SetShown(name, true);
        public void Hide(string name) => SetShown(name, false);

        private void SetShown(string name, bool shown)
        {
            ShownActions.MySet(name, shown);
            OnShownActionsChange?.Invoke(name, shown);
        }
        public Action<string, bool> OnShownActionsChange { private get; set; }

        [JsonProperty]
        public HashSet<string> EnabledActions; // 是否启用。程序自动决定是否展示
        public void Enable(string name) => EnabledActions.MySet(name, true);
        public void Disable(string name) => EnabledActions.MySet(name, false);


        [JsonProperty]
        public int ActiveActionStackIndex { get; set; }
        [JsonIgnore]
        public ActionStack ActiveActionStack
        {
            get
            {
                if (UIState == UIState.行 || UIState == UIState.观)
                {
                    return Stacks[ActiveActionStackIndex];
                }
                else
                {
                    return null;
                }
            }
        }
        [JsonProperty]
        public List<ActionStack> Stacks { get; private set; }


        // 思
        [JsonProperty]
        Dictionary<string, int> GameStatus;

        public void Initialize()
        {
            if (Data != null) { throw new Exception(); }
            Data = this;

            uiState = UIState.行;

            ShownActions = new HashSet<string>();
            EnabledActions = new HashSet<string>();

            ActiveActionStackIndex = 0;
            Stacks = new List<ActionStack>
            {
                行动.Create(),
                季节.Create(),
                昼夜.Create()
            };

            GameStatus = new Dictionary<string, int>();
        }

    }
}


