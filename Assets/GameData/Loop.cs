
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace W
{
    public class Loop : MonoBehaviour
    {
        [NonSerialized] private Game game;


        private JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            Formatting = Formatting.Indented,
        };


        private string Path => System.IO.Path.Combine(Application.persistentDataPath, "save.json");
        private void Save()
        {
            string json = JsonConvert.SerializeObject(game, settings);
            Debug.Log("saved");
            Debug.Log(json);
            Debug.Log(Path);
            System.IO.File.WriteAllText(Path, json);

        }
        private void Load()
        {
            string json = System.IO.File.ReadAllText(Path);
            Debug.Log("loaded");
            Debug.Log(json);
            game = JsonConvert.DeserializeObject<Game>(json);
        }

        private void Start()
        {
            if (System.IO.File.Exists(Path))
            {
                Load();
            }
            else
            {
                game = new Game();
                game.Initialize();
            }
            AfterLoadOrInitialize();
        }
        private void AfterLoadOrInitialize()
        {
            foreach (string name in game.Showns)
            {
                AddButtonEntry(name).Visible(game.Enables.Contains(name));
            }
            game.OnShownsChange = OnShownsChange;
            foreach (ActionStack stack in game.Stacks)
            {
                stack.OnStartNode = (ActionNode node) =>
                {
                    if (stack == game.ActiveActionStack)
                    {
                        StartActiveNode(stack, node);
                    }
                };
            }
        }

        [SerializeField] private ButtonEntry ButtonEntryPrefab;
        [SerializeField] private Transform ActionContent;
        [NonSerialized] private Dictionary<string, ButtonEntry> shownActionPrefabs = new Dictionary<string, ButtonEntry>();
        private void OnShownsChange(string name, bool shown)
        {
            bool has = shownActionPrefabs.TryGetValue(name, out ButtonEntry buttonEntry);
            if (shown && !has)
            {
                buttonEntry = AddButtonEntry(name);
            }
            buttonEntry.Visible(game.Enables.Contains(name));
            buttonEntry.gameObject.SetActive(shown);
        }
        private ButtonEntry AddButtonEntry(string name)
        {
            ButtonEntry entry = Instantiate(ButtonEntryPrefab, ActionContent);
            shownActionPrefabs.Add(name, entry);
            entry.text.text = name;
            entry.gameObject.SetActive(true);
            entry.button.onClick.AddListener(() =>
            {
                bool newState = !entry.Visible();
                entry.Visible(newState);
                game.Enables.MySet(name, newState);
            });
            return entry;
        }


        [SerializeField] private Text ProgressTextPrefab;
        [SerializeField] private Transform ProgressContent;
        [SerializeField] private Slider ProgressSlider;
        [SerializeField] private Text ProgressText;
        [SerializeField] private Text ProgressTextExtra;
        void Update()
        {
            float dt = Math.Min(Time.deltaTime, 0.125f);
            foreach (ActionStack stack in game.Stacks)
            {
                stack.Simulate(dt);
            }
            ProgressSlider.value = game.ActiveActionStack.Progress;
        }

        private void StartActiveNode(ActionStack stack, ActionNode node)
        {
            ProgressText.text = node.Title;
            SyncMessages(stack);
        }

        private void SyncMessages(ActionStack stack)
        {
            DestroyAllChildren(ProgressContent);
            int i = 0;
            foreach (string message in stack.Messages)
            {
                Text text = Instantiate(ProgressTextPrefab, ProgressContent);
                text.text = message;
                text.transform.SetAsFirstSibling();
                text.name = text.text;
                i++;
                if (i >= 10)
                {
                    break;
                }
            }
            FadeChildren(ProgressContent);
        }

        private void FadeChildren(Transform trans)
        {
            int childCount = trans.childCount;
            int i = 0;
            foreach (Transform t in trans)
            {
                float v = 0.875f * Mathf.Pow(0.5f, i);
                Text text = t.GetComponent<Text>();
                if (text != null)
                {
                    text.color = new Color(1, 1, 1, v);
                }
                i++;
            }
        }

        private void DestroyAllChildren(Transform trans)
        {
            foreach (Transform t in trans)
            {
                Destroy(t.gameObject);
            }
        }

        private void DestroryExcessChildren(Transform trans, int count)
        {
            int childCount = trans.childCount;

            if (childCount > count)
            {
                for (int i = childCount - 1; i >= count; i--)
                {
                    Transform child = trans.GetChild(i);
                    child.SetParent(null);
                    Destroy(child.gameObject);
                }
            }
        }


    }
}
