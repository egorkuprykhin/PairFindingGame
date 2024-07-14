using Editor;
using Infrastructure.Common;
using Infrastructure.Core;
using PairFindingGame.Services;
using UnityEditor;
using UnityEngine;
using Logger = Editor.Logger;

namespace PairFindingGame.Editor.Tools
{
    public static class BuildGameTool
    {
        [MenuItem(Constants.PairFinding.Tools.BuildGameLogic)]
        public static void Build()
        {
            var gameGo = new GameObject("PairFindingGame");
            
            var registrationGo = new GameObject("GameRegistration");
            registrationGo.transform.SetParent(gameGo.transform);
            
            var gameConfigurationGo = new GameObject("GameConfiguration");
            gameConfigurationGo.transform.SetParent(registrationGo.transform);
            
            var factoryGo = new GameObject("Factory");
            factoryGo.transform.SetParent(registrationGo.transform);
            
            var sceneDataGo = new GameObject("SceneData");
            sceneDataGo.transform.SetParent(registrationGo.transform);

            var registration = registrationGo.GetOrAddComponent<PairFindingGameRegistration>();
            var gameConfiguration = gameConfigurationGo.GetOrAddComponent<GameConfigurationService>();
            var factory = factoryGo.GetOrAddComponent<PairFindingGameFactory>();
            var sceneData = sceneDataGo.GetOrAddComponent<GameSceneDataService>();
            
            registration.CollectMonoServices();
            registration.MonoServices.Remove(gameConfiguration);
            registration.GameConfigurationService = gameConfiguration;
            
            gameConfiguration.GameConfiguration =
                EditorExtensions.GetSingleByName<Configuration>(Constants.PairFinding.GameConfiguration);

            var registrationsBinder = Object.FindObjectOfType<RegistrationsBinder>();
            registrationsBinder.CollectRegistrations();

            Logger.LogColored("Done", Color.green);
        }
    }
}