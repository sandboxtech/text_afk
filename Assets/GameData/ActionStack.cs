
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace W
{

    [JsonObject(MemberSerialization.OptOut)]
    public class ActionStack
    {

        [JsonProperty]
        public string Name { get; private set; }

        [JsonIgnore]
        public virtual bool Visible { get => true; }

        public static T Create<T>(ActionNode node, string name) where T : ActionStack, new()
        {
            T stack = new T();
            stack.Nodes = new List<ActionNode> { node };
            stack.Messages = new List<string>();
            stack.Name = name;
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




        public void Simulate(float seconds)
        {
            ActionNode node = LastNode;

            float duration = node.Duration;
            Progress += duration <= 0 ? 1 : seconds / duration;

            if (Progress >= 1)
            {
                Progress = 0;
                node.TimesDone += 1;

                const int maxTimes = 100;
                int i;
                for (i = 0; i < maxTimes; i++)
                {
                    node = LastNode;

                    _EndNode();

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
                        if (next != node)
                        {
                            Nodes.RemoveAt(Nodes.Count - 1);
                            // 下推?
                            if (next != null)
                            {
                                Nodes.Add(next);
                            }
                        }
                    }

                    _StartNode();

                    if (LastNode.Duration != 0)
                    {
                        break;
                    }
                }
                if (i == maxTimes) throw new Exception();
            }
            OptimizeMessage();
        }

        public Action<ActionNode> OnStartNode { private get; set; }
        // public Action<ActionNode> OnEndNode { private get; set; }

        public void _EndNode()
        {
            ActionNode node = LastNode;
            node.EndAction();
            Messages.AddFilterNull(node.EndText);
            // OnEndNode?.Invoke(node);
        }
        public void _StartNode()
        {
            ActionNode node = LastNode;
            node.StartAction();
            Messages.AddFilterNull(node.StartText);
            OnStartNode?.Invoke(node); // refresh message
        }


        private void OptimizeMessage()
        {
            const int min = 16;
            const int max = 128;
            if (Messages.Count >= max)
            {
                Messages.RemoveRange(0, max - min);
            }
        }
    }
}
