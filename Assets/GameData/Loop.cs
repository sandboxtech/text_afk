
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Experimental.GraphView;
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
            game.OnEnterState = EnterState;
            game.OnExitState = ExitState;
            EnterState(game.UIState);

            foreach (ActionStack stack in game.Stacks)
            {
                stack.OnStartNode = (ActionNode node) =>
                {
                    if (stack == game.ActiveActionStack)
                    {
                        SyncMessages();
                    }
                };
            }
            SyncMessages();
        }

        private void EnterState(UIState state)
        {
            EnterOrExitState(state, true);
        }
        private void ExitState(UIState state)
        {
            EnterOrExitState(state, false);
        }
        private void EnterOrExitState(UIState state, bool enter)
        {
            switch (state)
            {
                case UIState.ÐÐ:
                    if (enter)
                    {
                        game.OnShownActionsChange = SyncActions;
                        game.ActiveActionStackIndex = 0;
                        SyncActions();
                        SyncMessages();
                    }
                    else
                    {
                        game.OnShownActionsChange = null;
                    }
                    break;
                case UIState.¹Û:
                    if (enter)
                    {
                        SyncStacks();
                    }
                    else
                    {

                    }
                    break;
                default:
                    throw new Exception();
            }
        }
        [SerializeField] private ButtonEntry ButtonEntryPrefab;
        [SerializeField] private Transform ButtonContent;

        private void SyncActions()
        {
            ButtonContent.DestroyAllChildren();
            foreach (string name in game.ShownActions)
            {
                ButtonEntry entry = Instantiate(ButtonEntryPrefab, ButtonContent);
                entry.text.text = name;
                entry.gameObject.SetActive(true);
                entry.button.onClick.AddListener(() =>
                {
                    bool newState = !entry.Visible();
                    Audio.Play.Click(newState);
                    entry.Visible(newState);
                    game.EnabledActions.MySet(name, newState);
                });
                entry.Visible(game.EnabledActions.Contains(name));
            }
        }

        private void SyncStacks()
        {
            ButtonContent.DestroyAllChildren();

            int i = 0;
            foreach (ActionStack stack in game.Stacks)
            {
                if (stack.Visible)
                {
                    ButtonEntry entry = Instantiate(ButtonEntryPrefab, ButtonContent);
                    entry.text.text = stack.Name;
                    int t = i;
                    entry.button.onClick.AddListener(() =>
                    {
                        Audio.Play.Click();
                        Game.Data.ActiveActionStackIndex = t;
                        SyncMessages();
                    });
                }
                i++;
            }
        }

        private void SyncMessages()
        {
            ActionStack stack = game.ActiveActionStack;
            ProgressText.text = stack.LastNode.Title;
            ProgressContent.DestroyAllChildren();
            for (int i = stack.Messages.Count - 1; i >= 0; i--)
            {
                string message = stack.Messages[i];
                Text text = Instantiate(ProgressTextPrefab, ProgressContent);
                text.text = message;
                text.name = text.text;
            }
            ProgressContent.FadeChildren();
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
            {
                ActionStack stack = game.ActiveActionStack;
                if (stack != null)
                {
                    ProgressSlider.value = stack.Progress;
                }
            }
        }
    }
}
