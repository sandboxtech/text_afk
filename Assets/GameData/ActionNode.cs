
using Newtonsoft.Json;
using UnityEngine;

namespace W
{
    public abstract class ActionNode
    {
        [JsonProperty]
        public long TimesDone { get; set; }

        [JsonIgnore]
        public virtual string Title { get => GetType().Name; }

        [JsonIgnore]
        public virtual string StartText { get => null; }
        [JsonIgnore]
        public virtual string EndText { get => null; }

        public virtual void EndAction() { }
        public virtual void StartAction() { }

        [JsonIgnore]
        public virtual float Duration => 4;

        [JsonIgnore]
        public virtual ActionNode Push => null;

        [JsonIgnore]
        public virtual ActionNode Next => null;
    }
}
