using Editor;
using Infrastructure.Common;
using UnityEditor;
using UnityEngine;
using Logger = Editor.Logger;

namespace PairFindingGame.Editor.Tools
{
    public static class BuildGameConfigurationTool
    {
        [MenuItem(Constants.PairFinding.Tools.BuildGameConfiguration)]
        public static void CollectPairFindingGameConfiguration()
        {
            var configuration = EditorExtensions.GetSingleByName<Configuration>(Constants.PairFinding.GameConfiguration);
            if (configuration)
            {
                var assetPath = AssetDatabase.GetAssetPath(configuration);
                configuration.CollectSettings(assetPath);
                
                Logger.LogColored("Done", Color.green);
            }
        }
    }
}