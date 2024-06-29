
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace W
{

    [JsonObject(MemberSerialization.OptOut)]
    public class ActionStack
    {
        [JsonProperty]
        public string Name { get; protected set; }

        [JsonIgnore]
        public virtual bool Visible { get => false; }

        public static T Create<T>(ActionNode node) where T : ActionStack, new()
        {
            T stack = new T();
            stack.Nodes = new List<ActionNode> { node };
            stack.Messages = new List<string>();
            return stack;
        }


        [JsonProperty]
        public float Progress { get; private set; }

        [JsonProperty]
        public List<string> Messages { get; private set; }


        [JsonProperty]
        public List<ActionNode> Nodes { get; private set; }
        [JsonIgnore]
        public ActionNode LastNode { get => Nodes[Nodes.Count - 1]; }



        public Action<ActionNode> OnStartNode { private get; set; }

        public void Simulate(float seconds)
        {
            ActionNode node = LastNode;

            bool start = Progress == 0;
            Progress += seconds / node.Duration;
            if (start)
            {
                node.StartAction();
                Messages.AddFilterNull(node.StartText);

                OnStartNode?.Invoke(node);
            }
            else if (Progress >= 1)
            {
                Progress = 0;
                node.TimesDone += 1;

                node.EndAction();
                Messages.AddFilterNull(node.EndText);


                // 下推?
                ActionNode next = node.Push;
                if (next != null)
                {
                    Nodes.Add(next);
                }
                else
                {
                    // 上推
                    next = node.Next;
                    Nodes.RemoveAt(Nodes.Count - 1);
                    // 下推?
                    if (next != null)
                    {
                        Nodes.Add(next);
                    }
                }
            }
        }
    }
}
