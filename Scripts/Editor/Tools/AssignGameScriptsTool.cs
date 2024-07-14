using Editor;
using Infrastructure.Common;
using UnityEditor;
using UnityEngine;
using Logger = Editor.Logger;

namespace PairFindingGame.Editor.Tools
{
    public static class AssignGameScriptsTool
    {
        [MenuItem(Constants.Tools.AssignPairFindingGameScripts)]
        public static void AssignScriptsToConfigs()
        {
            AssignScriptsProcessor.ProcessAsset<Configuration>(Constants.Configurations.PairFindingGameConfiguration);
            AssignScriptsProcessor.ProcessAsset<PairFindingGameSettings>();
            AssignScriptsProcessor.ProcessAsset<PairFindingAnimationSettings>();
            AssignScriptsProcessor.ProcessAsset<PairFindingScoresSettings>();
            AssignScriptsProcessor.ProcessAsset<PairFindingSoundSettings>();
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Logger.LogColored("Done", Color.green);
        }
    }
}